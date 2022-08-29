using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Product
    {
        public Product()
        {
            Comments = new HashSet<Comment>();
            EventDetails = new HashSet<EventDetail>();
            GiftGiftProductNavigations = new HashSet<Gift>();
            GiftProducts = new HashSet<Gift>();
            ProductColors = new HashSet<ProductColor>();
            ProductVersions = new HashSet<ProductVersion>();
        }

        public string ProductId { get; set; } = null!;
        public string ProuctName { get; set; } = null!;
        public string ProductType { get; set; } = null!;
        public string ProductBrand { get; set; } = null!;
        public string ProductPhoto { get; set; } = null!;
        public string? ProductDescription { get; set; }
        public DateTime? ReleaseTime { get; set; }

        public Product(string productId, string prouctName, string productType, string productBrand, string productPhoto, string? productDescription, DateTime? releaseTime)
        {
            ProductId = productId;
            ProuctName = prouctName;
            ProductType = productType;
            ProductBrand = productBrand;
            ProductPhoto = productPhoto;
            ProductDescription = productDescription;
            ReleaseTime = releaseTime;
           
        }

        public virtual ProductBrand ProductBrandNavigation { get; set; } = null!;
        public virtual ProductType ProductTypeNavigation { get; set; } = null!;
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<EventDetail> EventDetails { get; set; }
        public virtual ICollection<Gift> GiftGiftProductNavigations { get; set; }
        public virtual ICollection<Gift> GiftProducts { get; set; }
        public virtual ICollection<ProductColor> ProductColors { get; set; }
        public virtual ICollection<ProductVersion> ProductVersions { get; set; }
    }
}
