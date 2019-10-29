using System;

namespace DashModule.EventOrganizer.Model
{
    public class Talk
    {
        public Guid Id { get; set; }
        public User Presenter { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}