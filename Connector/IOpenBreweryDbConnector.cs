using dashmodule.eventorgranizer.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace EventOrganizer.Connector
{
    public interface IOpenBreweryDbConnector
    {
        Task<List<Brewery>> GetBreweriesAsync(int? page, int? pageSize, string filterCity, string filterState, string filterName, string filterType, string filterTag, string sort);
    }
}
