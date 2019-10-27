using System.Linq;
using System.Collections.Generic;
using dashmodule.eventorgranizer.Model;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using EventOrganizer.Connector;

namespace dashmodule.eventorgranizer.Connector
{

    public class OpenBreweryDbQueryBuilder : IOpenBreweryDbQueryBuilder
    {
        private Dictionary<string, bool> sortingMap = new Dictionary<string, bool>();

        private ILogger Log { get; set; }
        public OpenBreweryDbQueryBuilder(ILogger log)
        {
            Log = log;
        }

        private string City { get; set; }
        private string State { get; set; }
        private string Name { get; set; }
        private string Type { get; set; }
        private string Tag { get; set; }
        private int? _Page { get; set; }
        private int? _PerPage { get; set; }

        public IOpenBreweryDbQueryBuilder ByCity(string city)
        {
            City = city;

            return this;
        }

        public IOpenBreweryDbQueryBuilder ByName(string name)
        {
            Name = name;

            return this;
        }

        public IOpenBreweryDbQueryBuilder ByState(string state)
        {
            State = state;
            return this;
        }

        public IOpenBreweryDbQueryBuilder ByTag(string tag)
        {
            Tag = tag;

            return this;
        }

        public IOpenBreweryDbQueryBuilder ByType(string type)
        {
            Type = type;

            return this;
        }

        public async Task<List<Brewery>> Execute()
        {
            var sortBy = string.Join(",", sortingMap.Select(p => $"{(p.Value ? '+' : '-')}{p.Key}"));

            var openBreweryDb = new OpenBreweryDbConnector(Log);

            return await openBreweryDb.GetBreweriesAsync(0, 10, City, State, Name, Type, Tag, sortBy);
        }

        public IOpenBreweryDbQueryBuilder Sort(string sortBy, bool ascending = true)
        {

            return this;
        }

        public IOpenBreweryDbQueryBuilder Page(int? page)
        {
            _Page = page;

            return this;
        }

        public IOpenBreweryDbQueryBuilder PerPage(int? perPage)
        {
            _PerPage = perPage;

            return this;
        }
    }

}