using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class EventDetail
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public string ProductId { get; set; } = null!;

        public virtual Event Event { get; set; } = null!;
        public virtual Product Product { get; set; } = null!;
    }
}
