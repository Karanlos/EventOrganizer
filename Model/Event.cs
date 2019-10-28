using System;
using System.Collections.Generic;

namespace DashModule.EventOrgranizer.Model
{
    public class Event
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public List<User> Participants { get; set; }
        public List<Talk> Talks { get; set; }
        public Venue Venue { get; set; }
    }
}