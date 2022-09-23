using ModelProject.Models;

namespace CMSWeb.ViewModels.ProductBrandsViewModel
{
    public class BrandsViewModel1
    {
        public BrandsViewModel1() { }
        public List<ProductBrand> ProductBrands { get; set; }

        public string GetStatus(int? Status)
        {
            switch (Status)
            {
                case 1: return "Đang kinh doanh"; break;
                case 0: return "Tạm ngưng kinh doanh"; break;
                default:
                    return "";
                    break;
            }
           
        }

        public string message { get; set; }
    }
}
