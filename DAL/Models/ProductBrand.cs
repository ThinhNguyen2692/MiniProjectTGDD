using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class ProductBrand
    {
        public ProductBrand()
        {
            Products = new HashSet<Product>();
        }


        public string BrandId { get; set; } = null!;
        public string BrandName { get; set; } = null!;
        public string BrandPhoto { get; set; } = null!;
        public string? BrandDescription { get; set; }
        public int? BrandStatus { get; set; }

        public virtual ICollection<Product> Products { get; set; }

        
    }
}
