using System.Collections.Generic;

namespace dashmodule.eventorgranizer.Model
{
    public class Event
    {
        public List<User> Participants { get; set; }
        public List<Talk> Talks { get; set; }
        public Venue Venue { get; set; }
    }
}