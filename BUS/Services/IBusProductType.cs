using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace BUS.Services
{
    public interface IBusProductType
    {
        public bool BusAddType(ProductType type);
        public bool BusUpdateType(ProductType type);
        public List<ProductType> ReadAll();
        public ProductType BusReadType(string id);
        public void deletetype(string typeid);

        public void BusAddInformationProperties(InformationProperty informationProperty);
        public List<InformationProperty> ReadProperty(string id);
        public void UpDateProperty(InformationProperty property);
        public bool DalDeleteProperty(int property);
        public bool DalDeletePropertySpecification(int SpecificationID);
        public bool DeletePropertyType(string id);

        public int BusAddProductPecification(ProductSpecification productSpecification);
        public List<ProductSpecification> ReadSpecification(string id);
        public void UpdateSpecificatio(ProductSpecification specification);
        public bool DeleteSpecification(int specification);
        public void DeleteSpecificationType(string typeid);
        public string GetTypeIdBySpecification(int SpecificationId);
    }
}
