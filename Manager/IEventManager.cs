using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DashModule.EventOrganizer.Model;

namespace DashModule.EventOrganizer.Manager {
    public interface IEventManager {
        Task<IEnumerable<Event>> GetEvents();
        Task<Guid> CreateEvent(string name, string description, DateTime startDate, DateTime endDate);
        Task UpdateEvent(Guid id, string name, string description, DateTime startDate, DateTime endDate);
        Task DeleteEvent(Guid id);
    }
}