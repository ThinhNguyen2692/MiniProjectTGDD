using DAL.Models;

namespace CMSWeb.ViewModels.ProductTypeViewModel
{
    public class ListProductTypeViewModel
    {
       public List<ProductType> listproductTypes { get; set; }
       public string message { get; set; }

        public ListProductTypeViewModel() { }
    }
}
