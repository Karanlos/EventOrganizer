using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DashModule.EventOrganizer.Model;
using DashModule.EventOrganizer.Manager;
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace DashModule.EventOrgranizer.Controllers
{

    [ApiVersion("1")]
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;

        public UserController(ILogger<UserController> logger)
        {
            _logger = logger;
        }

        [HttpGet, Route("{id}")]
        public async Task<User> Get(Guid userId)
        {
            if (!AuthHelper.IsAuthorized(HttpContext, "create:event"))
            {
                HttpContext.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
                return null;
            }
            //_logger.LogInformation($"Admin {HttpContext.User.Identity} fetching user {userId}.");
            var userManager = new UserManager(_logger);

            return await userManager.GetUser(userId);
        }

        [HttpPut, Route("{id}")]
        [Authorize("user:update")]
        public void Update([FromBody] User user)
        {
            //
            _logger.LogInformation($"Admin {HttpContext.User.Identity} updating user.");
            throw new NotImplementedException();
        }

        [HttpDelete, Route("{id}")]
        [Authorize("user:delete")]
        public void Delete(Guid id)
        {
            //Check Token validity

            //Check guid is valid

            var talkManager = new TalkManager(_logger);

            talkManager.DeleteTalk(id);
        }
    }
}
