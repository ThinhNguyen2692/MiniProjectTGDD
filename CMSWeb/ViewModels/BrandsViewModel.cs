using DAL.Models;

namespace CMSWeb.ViewModels
{
    public class BrandsViewModel
    {
        public BrandsViewModel() { }
        public List<ProductBrand> ProductBrands { get; set; }
        public string message { get; set; }
    }
}
