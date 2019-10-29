using System;
using System.Threading.Tasks;
using DashModule.EventOrganizer.Model;

namespace DashModule.EventOrganizer.Database {
    public interface IDbContext {
        public Task<Event> GetEvent(Guid id);
    }
}