using ModelProject.Models;

namespace ModelProject.ViewModel
{

    public class ProductInformation
    {
        public ProductInformation() {}
        
        public int ProperTyId { get; set; }
        public string SpecificationName { get; set; }
        public string PropertyName { get; set; }
        public string Description { get; set; }
        public string Value { get; set; }

    }

    public class Color
    {
        public Color() { }
        public string ColoName { get; set; }
        public int ColoId { get; set; }

        public int QuantityProduct { get; set; }
    }

    public class ProductVersionViewModel
    {
        public string ProductId { get; set; }
        public string ProductVersionId { get; set; }
        public string ProductVersionName { get; set; }
        public int ProductVersionPrice { get; set; }
        public int ProductVersionStatus { get; set; }
        public List<Color> ColorProduct { get; set; }
        public Status status { get; set; } = new Status();

        public List<ProductInformation> information { get; set; }
       
        public string MessageAdd { get; set; }

        public ProductVersionViewModel() { }

        public List<Color> GetColors(List<ProductColor> color)
        {
            List<Color> colors = new List<Color>(); 
            foreach (var item in color)
            {
                Color value = new Color();
                value.ColoName = item.ColorDescription;
                value.ColoId = item.ColorId;
                colors.Add(value);
            }
            return colors;
        }


        public List<ProductInformation> GetProductInformation(ProductType type)
        {
            var ProductInformationNew = new List<ProductInformation>();
            foreach (var item in type.ProductSpecifications)
            {               
                foreach (var item2 in item.InformationProperties)
                {
                    ProductInformation productInformation = new ProductInformation();
                    productInformation.SpecificationName = item.SpecificationsName;
                    productInformation.ProperTyId = item2.PropertiesId;
                    productInformation.PropertyName = item2.PropertiesName;
                    productInformation.Description = item2.PropertiesDescription;
                    ProductInformationNew.Add(productInformation);
                }
            }
            return ProductInformationNew;

        }

    }
}
