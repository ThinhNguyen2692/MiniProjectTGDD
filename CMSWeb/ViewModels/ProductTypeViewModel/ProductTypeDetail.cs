using DAL.Models;

namespace CMSWeb.ViewModels.ProductTypeViewModel
{
    public class ProductTypeDetail
    {
        public ProductTypeDetail() { }
        public ProductType productType { get; set; }
       
        public bool message { get; set; }
    }
}
