using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public interface IDalInformationProperties
    {
        void AddInformationProperties(InformationProperty informationProperty);
      
        bool DalDeleteProperty(int property);
      
    
        public bool CheckInformationProperty(int SpecificationId);
    }
    public class Dal_InformationProperties:IDalInformationProperties
    {


        public MiniProjectTGDDContext context;

        public Dal_InformationProperties (MiniProjectTGDDContext miniProjectTGDDContext)
        {
               context = miniProjectTGDDContext;
        }

        //Thêm thông tin thuộc tính
        public void AddInformationProperties(InformationProperty informationProperty)
        {
            context.InformationProperties.Add(informationProperty);
            context.SaveChanges();
        }

   

        //cập nhật thông tin thuộc tính
       


        //Xóa thuộc tính
        public bool DalDeleteProperty(int property)
        {
            
            var item = context.PropertiesValues.Where(p => p.PropertiesId == property).ToList();
            if (item.Count == 0)
            {
                var data = context.InformationProperties.FirstOrDefault(p => p.PropertiesId == property);
                context.InformationProperties.Remove(data);
                context.SaveChanges();
                return true;
            }
            return false;
        }

        //Xóa danh sách thông tin thuộc tính khi ngành hàng bị xóa
        
      


        public bool CheckInformationProperty(int SpecificationId)
        {
            var data = context.InformationProperties.Where(s => s.SpecificationsId == SpecificationId).ToList();
            if (data.Count == 0) return true;
            else return false;
        }
    }
}
