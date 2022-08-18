using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class VersionQuantity
    {
        public int Id { get; set; }
        public string VersionId { get; set; } = null!;
        public int ColorId { get; set; }
        public int? Quantity { get; set; }

        public virtual ProductColor Color { get; set; } = null!;
        public virtual ProductVersion Version { get; set; } = null!;
    }
}
