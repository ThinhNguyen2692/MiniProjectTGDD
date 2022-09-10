using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;


namespace BUS
{
    public interface IBusPropertyValue
    {
        public bool AddPropertyValue(PropertiesValue[] propertiesValue);
        public List<PropertiesValue> ReadValue(string id);
        public void DeletePropertyValue(string id);
    }

    public class Bus_PropertyValue:IBusPropertyValue
    {
        private static IDalPropertyValue dal_PropertyValue;
        private static Bus_PropertyValue _instance ;

        public static Bus_PropertyValue GetPropertyValue(IDalPropertyValue propertyValue)
        {
            dal_PropertyValue = propertyValue;
            if(_instance == null) { _instance = new Bus_PropertyValue(); }
            return _instance;
        }

       

        public bool AddPropertyValue(PropertiesValue[] propertiesValue)
        {
            foreach (var item in propertiesValue)
            {
                if(dal_PropertyValue.AddPropertyValue(item) != true)
                {
                    return false;
                }
            }
           return true;
        }

        //Lấy thông tin theo id version sản phẩm
        public List<PropertiesValue> ReadValue(string id)
        {
            return dal_PropertyValue.ReadValue(id);
        }

        /// <summary>
        /// Xóa dư liệu thông tin của version
        /// </summary>
        /// <param name="id">Mã phiên bản sản phẩm</param>
        /// <returns>true xóa thành công</returns>
        public void DeletePropertyValue(string id)
        {
            dal_PropertyValue.DeletePropertyValue(id);

        }
    }
}
