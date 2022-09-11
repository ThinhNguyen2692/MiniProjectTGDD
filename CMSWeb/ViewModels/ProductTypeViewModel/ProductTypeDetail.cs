using DAL.Models;

namespace CMSWeb.ViewModels.ProductTypeViewModel
{
    public class ProductTypeDetail
    {
        public ProductTypeDetail() { }
        public ProductType productType { get; set; }
        public List<ProductSpecification> productSpecifications { get; set; }
        public List<InformationProperty> informationPropertys { get; set; }
        public bool message { get; set; }
    }
}
