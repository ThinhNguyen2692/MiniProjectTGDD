using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS;
using DAL.Models;

namespace BUS.Services
{
    public interface IBusProduct
    {
        public void AddProduct(Product product);
        public Product BusReadProduct(string productId);
        public string DeleteProduct(string id);
        public bool CheckProduct(string ProductId);
        public int CheckVersionQuantity(string id);

        public List<ProductColor> BusReadProductColors(string id);
        public bool AddProductColor(ProductColor productColor);

        public List<string> delColor(string idProduct);

        public bool AddPropertyValue(PropertiesValue[] propertiesValue);
        public List<PropertiesValue> ReadValue(string id);
        public void DeletePropertyValue(string id);
        public bool AddVersionQuantity(VersionQuantity[] versionQuantities);
        public List<VersionQuantity> ReadQuantity(string id);
        public bool DelQuantyti(string id);

        public List<ProductType> ReadAll();
        public List<ProductBrand> DalGetbrandsByStatus();

        public bool AddProductVersion(ProductVersion productVersion);
        public ProductVersion DalReadProduct(string id);
        public void DelProductVerion(string id);
        public List<ProductVersion> DalReadProductAll();


    }
}
