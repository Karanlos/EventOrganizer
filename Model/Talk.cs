using System;

namespace dashmodule.eventorgranizer.Model
{
    public class Talk
    {
        public User Presenter { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
    }
}