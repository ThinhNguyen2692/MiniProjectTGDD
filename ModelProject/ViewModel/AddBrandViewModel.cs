using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelProject.Models;
using ModelProject;
using Microsoft.AspNetCore.Http;

namespace ModelProject.ViewModel
{
    public class AddBrandViewModel
    {
        public AddBrandViewModel() { }
        public string BrandId { get; set; } = null!;
        public string BrandName { get; set; } = null!;
        public string BrandPhoto { get; set; } = null!;
        public string? BrandDescription { get; set; }
        public int BrandStatus { get; set; }
        public IFormFile fileImage { get; set; }
        public string MessageAdd { get; set; }
        public string MessageUpdate { get; set; }
        public IEnumerable<StatusBrands> status { get; set; } = new List<StatusBrands>()
        {
            new StatusBrands(){name = "Tạm ngưng kinh doanh", id = 0},
            new StatusBrands(){name = "kinh doanh", id = 1}
            
        };
      
        
    }


    public class StatusBrands
    {
        public int id { get; set; }
        public string name { get; set; }

        

    }
}
