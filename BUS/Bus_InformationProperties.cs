using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;

namespace BUS
{

    public interface IBusInformationProperties
    {
        public void BusAddInformationProperties(InformationProperty informationProperty);
        public List<InformationProperty> ReadProperty(string id);
        public void UpDateProperty(InformationProperty property);
        public bool DalDeleteProperty(int property);
        public bool DalDeletePropertySpecification(int SpecificationID);
        public bool DeletePropertyType(string id);

    }

    public class Bus_InformationProperties : IBusInformationProperties
    {
        private IDalInformationProperties iDalInformationProperties;

        public Bus_InformationProperties(IDalInformationProperties dalInformationProperties) { iDalInformationProperties = dalInformationProperties; }
        // thêm thuộc tính
        public void BusAddInformationProperties(InformationProperty informationProperty)
        {
            iDalInformationProperties.AddInformationProperties(informationProperty);
        }

        //lấy thuộc tính theo loại
        public List<InformationProperty> ReadProperty(string id)
        {
            return iDalInformationProperties.ReadProperty(id);
        }
        public void UpDateProperty(InformationProperty property)
        {
            iDalInformationProperties.DalUpdateProperty(property);
        }

        public bool DalDeleteProperty(int property) { return iDalInformationProperties.DalDeleteProperty(property); }
        public bool DalDeletePropertySpecification(int SpecificationID) { return iDalInformationProperties.DalDeletePropertySpecification(SpecificationID); }
        public bool DeletePropertyType(string id) { return iDalInformationProperties.DeletePropertyType(id); }
    }
       
}
