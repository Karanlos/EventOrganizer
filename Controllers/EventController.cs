using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using dashmodule.eventorgranizer.Model;
using dashmodule.eventorgranizer.Manager;

namespace dashmodule.eventorgranizer.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EventController : ControllerBase
    {
        private readonly ILogger<EventController> _logger;

        public EventController(ILogger<EventController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Event> Get()
        {
            var venueManager = new EventManager(_logger);

            return venueManager.GetEvents();
        }
    }
}
