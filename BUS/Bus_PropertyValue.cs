using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;


namespace BUS
{
    
    public class Bus_PropertyValue
    {
        Dal_PropertyValue dal_PropertyValue = new Dal_PropertyValue();

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
    }
}
