using System;
using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;

namespace DashModule.EventOrganizer.Manager
{
    public static class AuthHelper
    {
        public static bool IsAuthorized(HttpContext HttpContext, params string[] permissions)
        {
            string accessToken = HttpContext.Request.Headers["Authorization"];
            var jwtToken = new JwtSecurityToken(accessToken.Replace("Bearer ", string.Empty));

            var claims = jwtToken.Claims.ToList();

            // if you need to check the Access Token expiration time, use this value
            // provided on the authorization response and stored.
            // do not attempt to inspect/decode the access token
            if (!claims.Any(c => c.Type == "scope" && c.Issuer == "https://dashmodule.eu.auth0.com/"))
                return false;

            // Split the scopes string into an array
            var scopes = claims?.FirstOrDefault(c => c.Type == "scope" && c.Issuer == "https://dashmodule.eu.auth0.com/")?.Value?.Split(' ');

            if (scopes != null)
            {
                foreach (var permission in permissions)
                {
                    if (!scopes.Any(s => s == permission))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}