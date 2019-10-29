using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Hosting;
using Swashbuckle.AspNetCore.Swagger;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Logging;

namespace eventorganizer2
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            string domain = $"https://{Configuration["Auth0:Domain"]}/";
            // Add authentication services
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddCookie(options =>
            {
                options.Events.OnRedirectToLogin = ctx =>
                    {
                        // if it is an ajax/api request, don't redirect
                        // to login page.
                        if (!(IsAjaxRequest(ctx.Request) || IsApiRequest(ctx.Request)))
                        {
                            ctx.Response.Redirect(ctx.RedirectUri);
                            return Task.CompletedTask;
                        }
                        ctx.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        return ctx.Response.WriteAsync("Unauthorized");
                    };
            })
            .AddJwtBearer(options =>
            {
                options.Authority = $"https://localhost:5001/";
                options.Audience = Configuration["Auth0:ApiIdentifier"];
            });
            services.AddAuthorization(options =>
            {
                options.AddPolicy("create:event", policy => policy.Requirements.Add(new HasScopeRequirement("create:event", domain)));
                options.AddPolicy("update:event", policy => policy.Requirements.Add(new HasScopeRequirement("update:event", domain)));
                options.AddPolicy("create:talk", policy => policy.Requirements.Add(new HasScopeRequirement("create:talk", domain)));
                options.AddPolicy("delete:talk", policy => policy.Requirements.Add(new HasScopeRequirement("delete:talk", domain)));
            });
            services.AddSingleton<IConfiguration>(Configuration); 
            services.AddSingleton<IAuthorizationHandler, HasScopeHandler>();
            services.AddApiVersioning(o =>
            {
                o.ReportApiVersions = true;
                o.AssumeDefaultVersionWhenUnspecified = true;
                o.DefaultApiVersion = new Microsoft.AspNetCore.Mvc.ApiVersion(1, 0);
            });
            services.AddSwaggerGen(c =>
                {
                    c.SwaggerDoc("v1", new OpenApiInfo { Title = "Event Organizer", Version = "1" });
                });
            services.AddMvc();
        }

        private static bool IsAjaxRequest(HttpRequest request)
        {
            var query = request.Query;
            if ((query != null) && (query["X-Requested-With"] == "XMLHttpRequest"))
            {
                return true;
            }
            IHeaderDictionary headers = request.Headers;
            return ((headers != null) && (headers["X-Requested-With"] == "XMLHttpRequest"));
        }

        private static bool IsApiRequest(HttpRequest request)
        {
            return request.Path.StartsWithSegments(new PathString("/api"));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostEnvironment env)
        {
            IdentityModelEventSource.ShowPII = true;
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();

            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Event Organizer V1.0");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }


    public class HasScopeRequirement : IAuthorizationRequirement
    {
        public string Issuer { get; }
        public string Scope { get; }

        public HasScopeRequirement(string scope, string issuer)
        {
            Scope = scope ?? throw new ArgumentNullException(nameof(scope));
            Issuer = issuer ?? throw new ArgumentNullException(nameof(issuer));
        }
    }

    public class HasScopeHandler : AuthorizationHandler<HasScopeRequirement>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, HasScopeRequirement requirement)
        {

            var claims = context.User.Claims.ToList();
            // If user does not have the scope claim, get out of here
            if (!context.User.HasClaim(c => c.Type == "scope" && c.Issuer == requirement.Issuer))
                return Task.CompletedTask;

            // Split the scopes string into an array
            var scopes = context.User.FindFirst(c => c.Type == "scope" && c.Issuer == requirement.Issuer).Value.Split(' ');

            // Succeed if the scope array contains the required scope
            if (scopes.Any(s => s == requirement.Scope))
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}
