using ModelProject.Models;

namespace ModelProject.ViewModel
{
    
    public class ListProductSpectification
    {
        public ListProductSpectification() { listInformationProperty = new List<ListInformationProperty>(); }

        
        public int SpecificationId { get; set; }
        public string SpecificationName { get; set; }
        
        public List<ListInformationProperty> listInformationProperty { get; set; }

      

    }

    public class ListInformationProperty
    {
        public ListInformationProperty() { }
        public string PropertyName { get; set; }
        public int PropertyId { get; set; }
        public string PropertiesDescription { get; set; }
    }

    public class ProductTypeDetail
    {
        public ProductTypeDetail() { createListProductSpecification = new List<ListProductSpectification>(); }


        public string TypeName { get; set; }
        public string TypeId { get; set;}

        public List<ListProductSpectification> createListProductSpecification { get; set; }
        
        public string messageDelete { get; set; } 

        public string messageUpdate { get; set; } 

        public void GetProductTypeNew()
        {
            
            //foreach (var item in createProductType.ProductSpecifications)
            //{
            //    ArrayProductSpectification arrayProductSpectification = new ArrayProductSpectification();
            //    arrayProductSpectification.createArrayInformationProperty = new List<InformationProperty>();
            //    arrayProductSpectification.createArrayInformationProperty.AddRange(item.InformationProperties);
            //    arrayProductSpectification.createProductSpectification = item;
            //    createListProductSpecification.Add(arrayProductSpectification);
            //}
            
        }

        ~ProductTypeDetail() { }
    }
}
