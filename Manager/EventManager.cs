using System.Collections.Generic;
using dashmodule.eventorgranizer.Model;
using Microsoft.Extensions.Logging;

namespace dashmodule.eventorgranizer.Manager
{
    public class EventManager : IEventManager
    {

        private ILogger Log { get; set; }

        public EventManager(ILogger log)
        {
            Log = log;
        }

        public List<Event> GetEvents()
        {
            throw new System.NotImplementedException();
        }
    }
}