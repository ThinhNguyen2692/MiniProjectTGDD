using System;
using System.Collections.Generic;

namespace ModelProject.Models
{
    public partial class ProductVersion
    {
        public ProductVersion()
        {
            Gifts = new HashSet<Gift>();
            ProductPhotos = new HashSet<ProductPhoto>();
            PropertiesValues = new HashSet<PropertiesValue>();
            VersionQuantities = new HashSet<VersionQuantity>();
        }

        public string VersionId { get; set; } = null!;
        public string ProductId { get; set; } = null!;
        public string VersionName { get; set; } = null!;
        public int? ProductPrice { get; set; }
        public int? ProductStatus { get; set; }

        public virtual Product Product { get; set; } = null!;
        public virtual ICollection<Gift> Gifts { get; set; }
        public virtual ICollection<ProductPhoto> ProductPhotos { get; set; }
        public virtual ICollection<PropertiesValue> PropertiesValues { get; set; }
        public virtual ICollection<VersionQuantity> VersionQuantities { get; set; }
    }
}
