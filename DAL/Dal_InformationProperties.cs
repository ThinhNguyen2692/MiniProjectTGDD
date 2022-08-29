using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class Dal_InformationProperties
    {
        MiniProjectTGDDContext context = new MiniProjectTGDDContext();

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

            return data;
        }

        //cập nhật thông tin thuộc tính
        public void DalUpdateProperty(InformationProperty property)
        {

            context.InformationProperties.Update(property);
            context.SaveChanges();
        }


        //Xóa thuộc tính
        public bool DalDeleteProperty(int property)
        {

            var item = context.InformationProperties.First(p => p.PropertiesId == property);
            context.InformationProperties.Remove(item);
            return true;
        }

        //Xóa danh sách thông tin thuộc tính khi ngành hàng bị xóa
        public void DalDeletePropertySpecification(int SpecificationID)
        {
            var data = context.InformationProperties.Where(p => p.SpecificationsId == SpecificationID);
            context.InformationProperties.RemoveRange(data);
            context.SaveChanges();

        }


        public bool DeletePropertyType(string id)
        {
            var data = context.ProductSpecifications.Where(s => s.TypeId == id).Join(context.InformationProperties, p => p.SpecificationsId, i => i.SpecificationsId, (p, i) => new InformationProperty
            {
                PropertiesId = i.PropertiesId,
                PropertiesName = i.PropertiesName,
                SpecificationsId = p.SpecificationsId,
                PropertiesDescription = i.PropertiesDescription
            }).ToList();
            context.InformationProperties.RemoveRange(data);
            context.SaveChanges();
            return true;
        }
    }
}
