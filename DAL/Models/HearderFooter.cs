using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class HearderFooter
    {
        public int Id { get; set; }
        public string InformationName { get; set; } = null!;
        public string Information { get; set; } = null!;
    }
}
