using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public interface IDalInformationProperties
    {
        void AddInformationProperties(InformationProperty informationProperty);
        List<InformationProperty> ReadProperty(string id);
        void DalUpdateProperty(InformationProperty property);
        bool DalDeleteProperty(int property);
        bool DalDeletePropertySpecification(int SpecificationID);
        bool DeletePropertyType(string id);
    }
    public class Dal_InformationProperties:IDalInformationProperties
    {
        private static Dal_InformationProperties informationProperties;

        public MiniProjectTGDDContext context = new MiniProjectTGDDContext();

        public static Dal_InformationProperties GetInformationProperties()
        {

            if(informationProperties == null) { informationProperties = new Dal_InformationProperties(); }
            return informationProperties;
        }

        //Thêm thông tin thuộc tính
        public void AddInformationProperties(InformationProperty informationProperty)
        {
            context.InformationProperties.Add(informationProperty);
            context.SaveChanges();
        }

        //lây danh sách thông tin thuộc tính
        public List<InformationProperty> ReadProperty(string id)
        {

            var data = context.ProductSpecifications.Where(s => s.TypeId == id).Join(context.InformationProperties, p => p.SpecificationsId, i => i.SpecificationsId, (p, i) => new InformationProperty
            {
                PropertiesId = i.PropertiesId,
                PropertiesName = i.PropertiesName,
                SpecificationsId = p.SpecificationsId,
                PropertiesDescription = i.PropertiesDescription
            }).ToList();

            var data2 = context.InformationProperties.Include(i => i.Specifications).Where(i => i.Specifications.TypeId == id).ToList();

            return data2;
        }

        //cập nhật thông tin thuộc tính
        public void DalUpdateProperty(InformationProperty property)
        {
            context = new MiniProjectTGDDContext();
            context.InformationProperties.Update(property);
            context.SaveChanges();
        }


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
        public bool DalDeletePropertySpecification(int SpecificationID)
        {
                var data = context.InformationProperties.Where(p => p.SpecificationsId == SpecificationID);
                context.InformationProperties.RemoveRange(data);
            context.SaveChanges();
            return true;
        }
        public bool DeletePropertyType(string id)
        {
            var itemCheck = context.Products.Where(p => p.ProductType == id).ToList();
            
            if(itemCheck.Count == 0)
            {
                var data = context.ProductSpecifications.Where(i => i.TypeId == id).Include(i => i.InformationProperties).ToList();
                foreach (var item in data)
                {
                    context.InformationProperties.RemoveRange(item.InformationProperties);
                    context.SaveChanges();
                }
                return true;
            }
            return false;
        }
    }
}
