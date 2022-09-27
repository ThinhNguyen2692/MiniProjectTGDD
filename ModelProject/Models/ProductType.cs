using System;
using System.Collections.Generic;

namespace ModelProject.Models
{
    public partial class ProductType
    {
        public ProductType()
        {
            ProductSpecifications = new HashSet<ProductSpecification>();
            Products = new HashSet<Product>();
        }

        public string Typeid { get; set; } = null!;
        public string Typename { get; set; } = null!;

        public virtual ICollection<ProductSpecification> ProductSpecifications { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
