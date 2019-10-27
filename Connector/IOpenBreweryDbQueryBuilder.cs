using dashmodule.eventorgranizer.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dashmodule.eventorgranizer.Connector {

    public interface IOpenBreweryDbQueryBuilder
    {
        IOpenBreweryDbQueryBuilder ByCity(string city);
        IOpenBreweryDbQueryBuilder ByName(string name);
        IOpenBreweryDbQueryBuilder ByState(string state);
        IOpenBreweryDbQueryBuilder ByType(string type);
        IOpenBreweryDbQueryBuilder ByTag(string tag);
        IOpenBreweryDbQueryBuilder Page(int? page);
        IOpenBreweryDbQueryBuilder PerPage(int? perPage);
        IOpenBreweryDbQueryBuilder Sort(string sortBy, bool ascending = true);
        Task<List<Brewery>> Execute();
    }

}