using DAL.Models;

namespace CMSWeb.ViewModels.ProductTypeViewModel
{
    
    public class ArrayProductSpectification
    {
        public ArrayProductSpectification() { }
        public ProductSpecification createProductSpectification { get; set; }
        public List<InformationProperty> createArrayInformationProperty { get; set; }

        ~ArrayProductSpectification() { }

    }


    public class ProductTypeDetail
    {
        public ProductTypeDetail() { }
        public ProductType createProductType { get; set; }

        public List<ArrayProductSpectification> createListProductSpecification { get; set; }
        
        public string messageDelete { get; set; } 

        public string messageUpdate { get; set; } 

        public void GetProductTypeNew()
        {
            
            foreach (var item in createProductType.ProductSpecifications)
            {
                ArrayProductSpectification arrayProductSpectification = new ArrayProductSpectification();
                arrayProductSpectification.createArrayInformationProperty = new List<InformationProperty>();
                arrayProductSpectification.createArrayInformationProperty.AddRange(item.InformationProperties);
                arrayProductSpectification.createProductSpectification = item;
                createListProductSpecification.Add(arrayProductSpectification);
            }
            
        }

        ~ProductTypeDetail() { }
    }
}
