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
    public class VenueController : ControllerBase
    {
        private readonly ILogger<VenueController> _logger;

        public VenueController(ILogger<VenueController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<Venue> Get()
        {
            var venueManager = new BreweryVenueManager(_logger);

            return venueManager.GetVenues().Result;
        }
    }
}
