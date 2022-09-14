using DAL.Models;

namespace CMSWeb.ViewModels.ProductViewModel
{
    public class AddColorProduct
    {
        public string ProductId { get; set; }
        public ProductColor ProductColorItem { get; set; }

        public IFormFile Fileimage { get; set; }

        public bool messageAdd { get; set; }

        public AddColorProduct() { }
    }
}
