using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class Dal_PropertyValue
    {
        MiniProjectTGDDContext context = new MiniProjectTGDDContext();
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
            var data = context.PropertiesValues.Include(p => p.Properties).ToList();
           
            return data;
        }

        // Xóa du 
        public bool DeletePropertyValue(string id)
        {
                var data = context.PropertiesValues.First(c => c.VersionId == id);
                context.Remove(data);
            context.SaveChanges();
          
            return true;
        }
    }
}
