using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ModelProject.Models;

namespace ModelProject.ViewModel
{

    public class ProductColorViewModel
    {
        public ProductColorViewModel() { }
        public string Name { get; set; }
        public string PathImage { get; set; }
    }

    public class Promation
    {
        public Promation() { }
        public int Id { get; set; }
        public string productVersionId { get; set; }
        public string? PromationName { get; set; }
        public string? ProductImage { get; set; }
        public int PromationPrice { get; set; }
        public int Status { get; set; } = 1;
        public string StatusName { get; set; } = "Khuyến mãi";
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        

    }

    public class HomeViewModel
    {
        public HomeViewModel() { }
        public List<ProductShow> ProductSale { get; set; } = new List<ProductShow>();
        public List<ProductShow> ProductApple { get; set; } = new List<ProductShow>();
        public List<ProductShow> Products { get; set; } = new List<ProductShow>();
    }

    public class ProductShow
    {
        public ProductShow() { }
        public string ProductId { get; set; } = null!;
        public string ProuctName { get; set; } = null!;
        public string ProductType { get; set; } = null!;
        public string ProductTypeName { get; set; } = null!;
        public string ProductBrand { get; set; } = null!;
        public string ProductBrandName { get; set; } = null!;
        public string ProductPhoto { get; set; } = null!;
        public string? ProductDescription { get; set; }
        public string VersionId { get; set; } = null!;
        public string VersionName { get; set; } = null!;
        public int? ProductPrice { get; set; } 
        public int? ProductPriceSale { get; set; } = 0;
        public int? ProductStatus { get; set; }
        public int? ProductSale { get; set; } = 0;


    }


    public class ProductDetailViewModel
    {
        public ProductDetailViewModel() { }

        public ProductShow ProductShow { get; set; } = new ProductShow();
        public IFormFile fileImage { get; set; } = null!;
        public DateTime? ReleaseTime { get; set; }
        public IEnumerable<StatusBrands> status { get; set; } = new List<StatusBrands>()
        {
            new StatusBrands(){name = "Tạm ngưng kinh doanh", id = 0},
            new StatusBrands(){name = "kinh doanh", id = 1}
        };
        public List<Promation> ProductPromation { get; set; } = new List<Promation>();
        public List<Promation> PricePromation { get; set; } = new List<Promation>();
        public PhotoViewModel? Photo { get; set; }
        public string MessageUpdate { get; set; } = null!;
        public List<QuantityProductVerSion> quantityProductVerSions { get; set; }
        public List<ProductVerSionDetailInformation> productVerSionDetailInformation { get; set; }
        public List<InformationPhoto>? PhotoProduct { get; set; } = new List<InformationPhoto>();
        public List<Comment> comments { get; set; } = new List<Comment>();
        public List<QuantityProductVerSion> GetQuantityProductVerSions(List<VersionQuantity> listVersionQuantity)
        {
            var listQuantityProductVerSions = new List<QuantityProductVerSion>();
            foreach (var item in listVersionQuantity)
            {
                var verSionQuantity = new QuantityProductVerSion();
                verSionQuantity.idQuantity = item.Id;
                verSionQuantity.color = item.Color.ColorDescription;
                verSionQuantity.Quantity = (int)item.Quantity;
                verSionQuantity.ColorPath = item.Color.ColorPath;
                listQuantityProductVerSions.Add(verSionQuantity);
            }
            return listQuantityProductVerSions;
        }
        public List<ProductVerSionDetailInformation> GetProductVerSionDetailInformation(List<PropertiesValue> propertiesValues)
        {
            var listProductVerSionDetailInformation = new List<ProductVerSionDetailInformation>();
            foreach (var item in propertiesValues)
            {
                var productVerSionDetailInformation = new ProductVerSionDetailInformation();
                productVerSionDetailInformation.vauleId = item.ValueId;
                productVerSionDetailInformation.Value = item.Value;
                productVerSionDetailInformation.PropertyName = item.Properties.PropertiesName;
                productVerSionDetailInformation.SpecificationName = item.Properties.Specifications.SpecificationsName;
                listProductVerSionDetailInformation.Add(productVerSionDetailInformation);
            }
            return listProductVerSionDetailInformation;
        }

    }


    public class ProductCart
    {

    }



}
