using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DashModule.EventOrgranizer.Model;
using DashModule.EventOrgranizer.Manager;
using Microsoft.AspNetCore.Authorization;

namespace DashModule.EventOrgranizer.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly ILogger _logger;

        public UserController(ILogger logger)
        {
            _logger = logger;
        }

        [HttpGet, Route("{id}")]
        [Authorize]
        public async Task<User> Get(Guid userId)
        {
            _logger.LogInformation($"Admin {HttpContext.User.Identity} fetching user {userId}.");
            var userManager = new UserManager(_logger);

            return await userManager.GetUser(userId);
        }

        [HttpPut, Route("{id}")]
        [Authorize]
        public void Update([FromBody] User user)
        {
            //
            _logger.LogInformation($"Admin {HttpContext.User.Identity} updating user.");
            throw new NotImplementedException();
        }

        [HttpDelete, Route("{id}")]
        [Authorize]
        public void Delete(Guid id)
        {
            //Check Token validity

            //Check guid is valid

            var talkManager = new TalkManager(_logger);

            talkManager.DeleteTalk(id);
        }
    }
}
