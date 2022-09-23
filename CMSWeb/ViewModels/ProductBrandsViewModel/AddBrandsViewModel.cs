using ModelProject.Models;
using CMSWeb.Models.ProductBrands;

namespace CMSWeb.ViewModels.ProductBrandsViewModel
{
    public class AddBrandsViewModel
    {
        public ProductBrand createBrands { get; set; }
        public IFormFile fileImage { get; set; }
        public string message { get; set; }
        public string StatusBrands()
        {
            switch (createBrands.BrandStatus)
            {
                case 1: return "Đang kinh doanh"; break;
                case 0: return "Tạm ngưng kinh doanh"; break;
                default:
                    break;
            }
            return "";
        }
        public AddBrandsViewModel() { }
    }
}
