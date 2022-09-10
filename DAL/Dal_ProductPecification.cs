using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public interface IDalProductPecification
    {
        int DalAddProductPecification(ProductSpecification type);
        List<ProductSpecification> ReadSpecification(string id);
        bool UpdateSpecificatio(ProductSpecification specification);
        bool DeleteSpecification(int specification);
        public void DeleteSpecificationType(string typeid);
    }

    public class Dal_ProductPecification : IDalProductPecification
    {
        private static Dal_ProductPecification ProductSpecification;
        private static MiniProjectTGDDContext context = new MiniProjectTGDDContext();
        public static Dal_ProductPecification GetsPecification()
        {
            if (ProductSpecification == null) { ProductSpecification = new Dal_ProductPecification(); }
            return ProductSpecification;
        }
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
            context = new MiniProjectTGDDContext();
            context.ProductSpecifications.Update(specification);
            context.SaveChanges();
            return true;
        }

        public bool DeleteSpecification(int specification)
        {
            var itemCheck = context.InformationProperties.FirstOrDefault(i => i.SpecificationsId == specification);
            if (itemCheck == null) {
                var data = context.ProductSpecifications.FirstOrDefault(s => s.SpecificationsId == specification);
                if (data != null)
                {
                    context.ProductSpecifications.Remove(data);
                    context.SaveChanges();
                    return true;
                }
            }
            return false;
        }

        public void DeleteSpecificationType(string typeid)
        {
            var data = context.ProductSpecifications.Where(s => s.TypeId == typeid);
            context.RemoveRange(data);
            context.SaveChanges();
        }


    }
}
