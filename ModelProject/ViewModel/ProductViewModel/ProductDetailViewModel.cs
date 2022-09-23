﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ModelProject.Models;

namespace ModelProject.ViewModel
{
    
    
    public class ProductDetailViewModel
    {
        public ProductDetailViewModel() { }

        public string ProductId { get; set; } = null!;
        public string ProuctName { get; set; } = null!;
        public string ProductType { get; set; } = null!;
        public string ProductTypeName { get; set; } = null!;
        public string ProductBrand { get; set; } = null!;
        public string ProductBrandName { get; set; } = null!;
        public string ProductPhoto { get; set; } = null!;
        public IFormFile fileImage { get; set; } = null!;
        public string? ProductDescription { get; set; }
        public DateTime? ReleaseTime { get; set; }
        public string VersionId { get; set; } = null!;
        public string VersionName { get; set; } = null!;
        public int? ProductPrice { get; set; }
        public int? ProductStatus { get; set; }
        public Status status { get; set; } = new Status();

        public string MessageUpdate { get; set; } = null!;
        public List<QuantityProductVerSion> quantityProductVerSions { get; set; }
        public List<ProductVerSionDetailInformation> productVerSionDetailInformation { get; set; }


        public List<QuantityProductVerSion> GetQuantityProductVerSions(List<VersionQuantity> listVersionQuantity)
        {
            var listQuantityProductVerSions = new List<QuantityProductVerSion>();
            foreach (var item in listVersionQuantity)
            {
                var verSionQuantity = new QuantityProductVerSion();
                verSionQuantity.idQuantity = item.Id;
                verSionQuantity.color = item.Color.ColorDescription;
                verSionQuantity.Quantity = (int)item.Quantity;
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
}