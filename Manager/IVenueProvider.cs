using dashmodule.eventorgranizer.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace dashmodule.eventorgranizer.Manager {
    public interface IVenueManager {
        Task<List<Venue>> GetVenues(int page = 0, int pageSize = 10, string filterCity = null, string filterName = null, string filterType = null, string sortBy = null);
    }
}