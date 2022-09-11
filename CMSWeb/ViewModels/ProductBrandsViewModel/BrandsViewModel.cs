using DAL.Models;

namespace CMSWeb.ViewModels.ProductBrandsViewModel
{
    public class BrandsViewModel
    {
        public BrandsViewModel() { }
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
