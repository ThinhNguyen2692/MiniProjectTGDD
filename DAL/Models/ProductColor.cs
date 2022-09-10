using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class ProductColor
    {
        public ProductColor()
        {
            VersionQuantities = new HashSet<VersionQuantity>();
        }

        public int ColorId { get; set; }
        public string ProductId { get; set; } = null!;
        public string ColorPath { get; set; } = null!;
        public string? ColorDescription { get; set; }

       
        public virtual Product Product { get; set; } = null!;
        public virtual ICollection<VersionQuantity> VersionQuantities { get; set; }
    }
}
