using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Event
    {
        public Event()
        {
            EventDetails = new HashSet<EventDetail>();
        }

        public int EventId { get; set; }
        public string EventName { get; set; } = null!;
        public int Promotion { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public virtual ICollection<EventDetail> EventDetails { get; set; }
    }
}
