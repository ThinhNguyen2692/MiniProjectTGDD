using DAL.Models;

namespace CMSWeb.ViewModels.ProductViewModel
{
    public class AddProductViewModel
    {
        public Product ProductItem { get; set; }
        public List<ProductType> ListproductTypes { get; set; }
        public List<ProductBrand> ListproductBrands { get; set; }
        public IFormFile FileImage { get; set; }
        public bool messageAdd { get; set; }

        public AddProductViewModel() { }
    }
}
