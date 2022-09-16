using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
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

        public List<string> GetStatus()
        {
            List<string> status = new List<string>
            {
               
                new string("Tạm ngưng doanh"),
                new string("Kinh doanh")
            };
            return status;
        }
    }
}
