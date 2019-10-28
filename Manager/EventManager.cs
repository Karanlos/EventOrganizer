using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DashModule.EventOrgranizer.Model;
using Microsoft.Extensions.Logging;

namespace DashModule.EventOrgranizer.Manager
{
    public class EventManager : IEventManager
    {

        private ILogger Log { get; set; }

        public EventManager(ILogger log)
        {
            Log = log;
        }

        public Task<IEnumerable<Event>> GetEvents() => throw new System.NotImplementedException();

        public Task<Guid> CreateEvent(string name, string description, DateTime startDate, DateTime endDate) => throw new System.NotImplementedException();

        public Task UpdateEvent(Guid id, string name, string description, DateTime startDate, DateTime endDate) => throw new NotImplementedException();

        public Task DeleteEvent(Guid id) => throw new NotImplementedException();
    }
}