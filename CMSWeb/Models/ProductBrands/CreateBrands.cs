﻿using ModelProject.Models;
using System.ComponentModel.DataAnnotations;

namespace CMSWeb.Models.ProductBrands
{
    public class CreateBrands
    {


        public ProductBrand _brand { get; set; }
        public IFormFile? fileImage { get; set; }
        public CreateBrands() { }


    }
}
