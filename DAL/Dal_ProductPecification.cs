using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL
{
    public class Dal_ProductPecification
    {
        MiniProjectTGDDContext context = new MiniProjectTGDDContext();
        //Thêm thông số ngành hàng
        public int DalAddProductPecification(ProductSpecification type)
        {
            
                
                context.ProductSpecifications.Add(type);
                context.SaveChanges();
            return type.SpecificationsId;
        }

        // lấy danh sách thông số ngành hàng
        public List<ProductSpecification> ReadSpecification(string id)
        {
            
                
                var data = context.ProductSpecifications.Where(t => t.TypeId == id).ToList();
                
            return data;
        }
        //Cập nhật thông tin

        public bool UpdateSpecificatio(ProductSpecification specification)
        {
            
                context.ProductSpecifications.Update(specification);
            context.SaveChanges();
            return true;
        }

        public bool DeleteSpecification(int specification)
        {
               
                var item = context.ProductSpecifications.First(s => s.SpecificationsId == specification);
                context.ProductSpecifications.Remove(item);
            context.SaveChanges();
            return true;
        }

        public bool DeleteSpecificationType(string typeid)
        {
            
                
                var data = context.ProductSpecifications.Where(s => s.TypeId == typeid);
                context.RemoveRange(data);
                context.SaveChanges();
            return true;
        }


    }
}
