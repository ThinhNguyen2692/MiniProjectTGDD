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

        public ProductBrand(string id, string name, string photo, string des, int status)
        {
            BrandId = id;
            BrandName = name;
            BrandPhoto = photo;
            BrandDescription = des;
            BrandStatus = status;
        }
    }
}
