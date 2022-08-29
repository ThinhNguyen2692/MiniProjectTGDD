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

        public ProductColor( string productId, string colorPath, string? colorDescription)
        {
            ProductId = productId;
            ColorPath = colorPath;
            ColorDescription = colorDescription;
        }

        public virtual Product Product { get; set; } = null!;
        public virtual ICollection<VersionQuantity> VersionQuantities { get; set; }
    }
}
