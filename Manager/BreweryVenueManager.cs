using dashmodule.eventorgranizer.Connector;
using dashmodule.eventorgranizer.Convert;
using dashmodule.eventorgranizer.Model;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.Extensions.Logging;

namespace dashmodule.eventorgranizer.Manager
{
    public class BreweryVenueManager : IVenueManager
    {
        private ILogger Log { get; set; }

        public BreweryVenueManager(ILogger log)
        {
            Log = log;
        }

        public async Task<List<Venue>> GetVenues(int page = 0, int pageSize = 10, string filterCity = null, string filterName = null, string filterType = null, string sortBy = null)
        {
            var breweryConvert = new BreweryConverter();
            var connector = new OpenBreweryDbQueryBuilder(Log);
            var breweries = await connector.ByCity(filterCity).ByName(filterName).ByType(filterType).Sort(sortBy, true).Execute();
            return breweries.Select(b => breweryConvert.Convert(b)).ToList();
        }
    }
}