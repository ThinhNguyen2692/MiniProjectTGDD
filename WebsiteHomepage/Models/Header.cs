using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace WebsiteHomepage.Models
{
    public class Category
    {
        public int ID { get; set; }

        [Display(Name = "Ngành hàng")]
        public string CategoryName { get; set; }
    }

    public class Brands
    {
        public int ID { get; set; }

        [Display(Name = "Thương hiệu")]
        public string BrandsName { get; set; }
        public int BrandPhoto { get; set; }
    }

}
