using System;

namespace DashModule.EventOrgranizer.Model
{
    public class Venue
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Address Address { get; set; }
        public string Website { get; set; }

    }
}