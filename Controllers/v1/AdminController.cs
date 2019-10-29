using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DashModule.EventOrganizer.Model;
using DashModule.EventOrganizer.Manager;
using Microsoft.AspNetCore.Authorization;

namespace DashModule.EventOrganizer.Controllers
{
    [ApiVersion("1")]
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AdminController : ControllerBase
    {
        private readonly ILogger<AdminController> _logger;

        public AdminController(ILogger<AdminController> logger)
        {
            _logger = logger;
        }

        #region Events

        [HttpPut, Route("event/{id}")]
        public void UpdateEvent([FromBody] Event e)
        {
            throw new NotImplementedException();
        }

        [HttpDelete, Route("event/{id}")]
        public void Delete(Guid id)
        {
            //Check Token validity

            //Check guid is valid

            var eventManager = new EventManager(_logger);

            eventManager.DeleteEvent(id);
        }
        #endregion Events

        #region Talks
        [HttpPut, Route("talk/{id}")]
        public void UpdateTalk([FromBody] Talk talk)
        {
            throw new NotImplementedException();
        }

        [HttpDelete, Route("talk/{id}")]
        public void DeleteEvent(Guid id)
        {
            //Check Token validity

            //Check guid is valid

            var eventManager = new EventManager(_logger);

            eventManager.DeleteEvent(id);
        }
        #endregion Talks

        #region Users
        [HttpGet, Route("users")]
        [Authorize("user_admin:read")]
        public async Task<IEnumerable<User>> GetUsers()
        {
            _logger.LogInformation($"Admin {HttpContext.User.Identity} fetching users.");
            var userManager = new UserManager(_logger);

            return await userManager.GetUsers();
        }

        [HttpGet, Route("user/{id}")]
        [Authorize("user_admin:read")]
        public async Task<User> GetUser(Guid userId)
        {
            _logger.LogInformation($"Admin {HttpContext.User.Identity} fetching user {userId}.");
            var userManager = new UserManager(_logger);

            return await userManager.GetUser(userId);
        }

        [HttpPut, Route("user/{id}")]
        [Authorize("user_admin:update")]
        public void UpdateUser([FromBody] User user)
        {
            _logger.LogInformation($"Admin {HttpContext.User.Identity} updating user.");
            throw new NotImplementedException();
        }

        [HttpDelete, Route("user/{id}")]
        public void DeleteUser(Guid id)
        {
            //Check Token validity

            //Check guid is valid

            var talkManager = new TalkManager(_logger);

            talkManager.DeleteTalk(id);
        }
        #endregion Users
    }
}
