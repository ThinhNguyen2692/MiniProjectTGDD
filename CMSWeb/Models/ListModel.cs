using DAL.Models;

namespace CMSWeb.Models
{
    public class ListModel
    {
        public static readonly ListModel listModel = new ListModel();

        public static ListModel GetList() { return listModel; }

        public List<ProductBrand> productBrands { get; set; }
        public ProductBrand productBrand { get; set; }

        public List<ProductType> productType { get; set; }

        public ProductType productTypeDetail { get; set; }

        public List<ProductColor> productColor { get; set; }
        public List<ProductPhoto> productPhoto { get; set; }
        public List<Product> products { get; set; }
        public Product product { get; set; }
        public List<Comment> comments { get; set; }
        public List<Customer> customers { get; set; }
        public Customer customer { get; set; }

        public List<Event> events { get; set; }
        public List<EventDetail> eventDetails { get; set; }
        public List<Gift> gifts { get; set; }
        public List<GiftDetail> GetGiftDetails { get; set; }
        public List<InformationProperty> information { get; set; }
        public List<Photo> photos { get; set; } 
        public List<ProductSpecification> productSpecifications { get; set; } 
        public List<ProductVersion> productVersion { get; set; } 
        public ProductVersion productVersionDetail { get; set; } 

        public List<PropertiesValue> propertiesValues { get; set; }  
        public List<PurchaseOrder> purchaseOrders { get; set; }
        public List<VersionQuantity> versionQuantities { get; set; }

        public List<User> users { get; set; }

        public List<ProductVersionItem> productVersionItems { get; set; }

       public string message { get; set; }

        public ListModel() { }

    }
}
