using DAL.Models;

namespace CMSWeb.ViewModels.ProductViewModel
{
    public class ProductVersionViewModel
    {
        public ProductVersion ProductVersionItem { get; set; }
        public Product product { get; set; }
        public List<ProductColor> productColor { get; set; }

        public List<InformationProperty> information { get; set; }
        public List<ProductSpecification> productSpecifications { get; set; }

        public bool MessageAdd { get; set; }

        public ProductVersionViewModel() { }

    }
}
