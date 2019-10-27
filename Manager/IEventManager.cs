using System.Collections.Generic;
using dashmodule.eventorgranizer.Model;

namespace dashmodule.eventorgranizer.Manager {
    public interface IEventManager {
        public List<Event> GetEvents();
    }
}