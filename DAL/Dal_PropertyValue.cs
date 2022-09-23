using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public interface IDalPropertyValue
    {
        public bool Update(ProductVerSionDetailInformation productVerSionDetailInformation);
        public List<PropertiesValue> ReadValue(string id);
        public void DeletePropertyValue(string id);
    }
    public class Dal_PropertyValue:IDalPropertyValue
    {
        private MiniProjectTGDDContext context;

        public Dal_PropertyValue(MiniProjectTGDDContext context)
        {
             this.context = context;
        }

        //Cập nhật
        public bool Update(ProductVerSionDetailInformation productVerSionDetailInformation)
        {
            var data = context.PropertiesValues.First(p => p.ValueId == productVerSionDetailInformation.vauleId);
            if (data == null) return false;
            data.Value = productVerSionDetailInformation.Value;
            context.SaveChanges();
            return true;
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
