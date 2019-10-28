using DashModule.EventOrgranizer.Convert;
using DashModule.EventOrgranizer.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Logging;
using System;
using DashModule.EventOrganizer.Connector;

namespace DashModule.EventOrgranizer.Service
{
    public class BreweryVenueService : IVenueService
    {
        private ILogger Log { get; set; }

        public BreweryVenueService(ILogger log)
        {
            Log = log;
        }

        public async Task<List<Venue>> GetVenues(int page = 0, int pageSize = 10, string filterCity = null, string filterName = null, string filterType = null, string sortBy = null)
        {
            var breweryConvert = new BreweryConverter();
            var breweryConnector = new OpenBreweryDbConnector(Log);
            var breweries = await breweryConnector.GetBreweriesAsync(page, pageSize, filterCity, null, filterName, filterType, null, sortBy);
            return breweries.Select(b => breweryConvert.Convert(b)).ToList();
        }
    }
}