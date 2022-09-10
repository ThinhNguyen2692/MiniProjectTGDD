using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public interface IDalPropertyValue
    {
        public bool AddPropertyValue(PropertiesValue propertiesValue);
        public List<PropertiesValue> ReadValue(string id);
        public void DeletePropertyValue(string id);
    }
    public class Dal_PropertyValue:IDalPropertyValue
    {
        private static Dal_PropertyValue propertyValue;
        private MiniProjectTGDDContext context = new MiniProjectTGDDContext();

        public static Dal_PropertyValue Instance
        {
            get
            {
                if (propertyValue == null) { propertyValue = new Dal_PropertyValue(); }
                return propertyValue;
            }
        }

        //them thông tin thông số cho sản phẩm
        public bool AddPropertyValue(PropertiesValue propertiesValue)
        {
                context.PropertiesValues.Add(propertiesValue);
                context.SaveChanges();
            return true;
        }

        //lấy thông số chi tiết

        public List<PropertiesValue> ReadValue(string id)
        {
            var data = context.PropertiesValues.Where(pv => pv.VersionId == id).Include(p => p.Properties).ToList();
           
            return data;
        }

        /// <summary>
        /// Xóa dư liệu thông tin của version
        /// </summary>
        /// <param name="id">Mã phiên bản sản phẩm</param>
        /// <returns>true xóa thành công</returns>
        public void DeletePropertyValue(string id)
        {
                var data = context.PropertiesValues.Where(c => c.VersionId == id).ToList();
                context.PropertiesValues.RemoveRange(data);
            context.SaveChanges();
          
        }
    }
}
