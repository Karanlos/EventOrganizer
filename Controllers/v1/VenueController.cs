using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DashModule.EventOrgranizer.Model;
using DashModule.EventOrgranizer.Manager;
using DashModule.EventOrgranizer.Service;

namespace DashModule.EventOrgranizer.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class VenueController : ControllerBase
    {
        private readonly ILogger<VenueController> _logger;

        public VenueController(ILogger<VenueController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IEnumerable<Venue>> GetVenues()
        {
            var venueService = new BreweryVenueService(_logger);

            return await venueService.GetVenues();
        }
    }
}
