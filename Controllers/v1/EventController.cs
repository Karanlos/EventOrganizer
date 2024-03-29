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
    public class EventController : ControllerBase
    {
        private readonly ILogger<EventController> _logger;

        public EventController(ILogger<EventController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Event>> Get()
        {
            var eventManager = new EventManager(_logger);

            return await eventManager.GetEvents();
        }

        [HttpGet, Route("{id}")]
        public async Task<Event> GetEvent(Guid id)
        {
            var eventManager = new EventManager(_logger);

            return await eventManager.GetEvent(id);
        }

        [HttpPost]
        [Authorize]
        public void Create([FromBody] Event e)
        {
            throw new NotImplementedException();
        }

        [HttpPut]
        [Authorize]
        public void Update([FromBody] Event e)
        {
            throw new NotImplementedException();
        }

        [HttpDelete, Route("{id}")]
        [Authorize]
        public void Delete(Guid id)
        {
            //Check Token validity

            //Check guid is valid

            var eventManager = new EventManager(_logger);

            eventManager.DeleteEvent(id);
        }
    }
}
