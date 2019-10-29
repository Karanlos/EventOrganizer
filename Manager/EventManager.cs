using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DashModule.EventOrganizer.Database;
using DashModule.EventOrganizer.Model;
using Microsoft.Extensions.Logging;

namespace DashModule.EventOrganizer.Manager
{
    public class EventManager : IEventManager
    {

        private ILogger Log { get; set; }

        public EventManager(ILogger log)
        {
            Log = log;
        }

        public async Task<Event> GetEvent(Guid id) {
            var dbContext = new MockDbContext();

            return await dbContext.GetEvent(id);
        }

        public async Task<User> GetParticipants(Guid eventId) {
            
            var eventManager = new EventManager(Log);
            return await eventManager.GetParticipants(eventId);
        }

        public Task<IEnumerable<Event>> GetEvents() => throw new System.NotImplementedException();

        public Task<Guid> CreateEvent(string name, string description, DateTime startDate, DateTime endDate) => throw new System.NotImplementedException();

        public Task UpdateEvent(Guid id, string name, string description, DateTime startDate, DateTime endDate) => throw new NotImplementedException();

        public Task DeleteEvent(Guid id) => throw new NotImplementedException();
    }
}