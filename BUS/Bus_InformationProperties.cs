using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;

namespace BUS
{
    public class Bus_InformationProperties
    {
        Dal_InformationProperties informationProperties = new Dal_InformationProperties();  
        
        
        // thêm thuộc tính
        public void BusAddInformationProperties(int SpecificationId, string PropertiesName, string PropertiesDescription)
        {
             informationProperties.AddInformationProperties(new InformationProperty(SpecificationId, PropertiesName,PropertiesDescription));
        }

        //lấy thuộc tính theo loại
        public List<InformationProperty> ReadProperty(string id)
        {
            return informationProperties.ReadProperty(id);
        }
        public void UpDateProperty(InformationProperty property)
        {
             informationProperties.DalUpdateProperty(property);
        }

        public bool DalDeleteProperty(int property) { return informationProperties.DalDeleteProperty(property); }
        public void DalDeletePropertySpecification(int SpecificationID) {  informationProperties.DalDeletePropertySpecification(SpecificationID); }
        public bool DeletePropertyType(string id) { return informationProperties.DeletePropertyType(id); }


    }
}
