using DashModule.EventOrganizer.Model;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DashModule.EventOrganizer.Service {
    public interface IVenueService {
        Task<List<Venue>> GetVenues(int page = 0, int pageSize = 10, string filterCity = null, string filterName = null, string filterType = null, string sortBy = null);
    }
}