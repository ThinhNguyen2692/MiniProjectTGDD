using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class ProductVersion
    {
        public ProductVersion()
        {
            ProductPhotos = new HashSet<ProductPhoto>();
            PropertiesValues = new HashSet<PropertiesValue>();
            VersionQuantities = new HashSet<VersionQuantity>();
        }

        public string VersionId { get; set; } = null!;
        public string ProductId { get; set; } = null!;
        public string VersionName { get; set; } = null!;
        public int? ProductPrice { get; set; }
        public int? ProductStatus { get; set; }

        public ProductVersion(string versionId, string productId, string versionName, int productPrice, int productStatus)
        {
            VersionId = versionId;
            ProductId = productId;
            VersionName = versionName;
            ProductPrice = productPrice;
            ProductStatus = productStatus; 
        }

        
        public ProductVersion(string versionId, string productId, string versionName, int productPrice, int productStatus, string image)
        {
            VersionId = versionId;
            ProductId = productId;
            VersionName = versionName;
            ProductPrice = productPrice;
            ProductStatus = productStatus;
            Product = new Product();
            this.Product.ProductPhoto = image;
        }


        public ProductVersion(string versionId, string productId, string versionName, int productPrice, int productStatus, Product product)
        {
            VersionId = versionId;
            ProductId = productId;
            VersionName = versionName;
            ProductPrice = productPrice;
            ProductStatus = productStatus;
            Product = product;
            
        }

        public virtual Product Product { get; set; } = null!;
        public virtual ICollection<ProductPhoto> ProductPhotos { get; set; }
        public virtual ICollection<PropertiesValue> PropertiesValues { get; set; }
        public virtual ICollection<VersionQuantity> VersionQuantities { get; set; }
    }
}
