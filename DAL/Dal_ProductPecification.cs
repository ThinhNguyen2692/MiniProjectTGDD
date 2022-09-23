using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public interface IDalProductPecification
    {
        int DalAddProductPecification(ProductSpecification type);
        List<ProductSpecification> ReadSpecification(string id);
        void UpdateSpecificatio(ProductSpecification specification);
        bool DeleteSpecification(int specification);
        public void DeleteSpecificationType(string typeid);
        public string GetTypeIdBySpecification(int SpecificationId);
    }

    public class Dal_ProductPecification : IDalProductPecification
    {

        private MiniProjectTGDDContext context;
       public Dal_ProductPecification(MiniProjectTGDDContext miniProjectTGDDContext) { context = miniProjectTGDDContext; }
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

        public void UpdateSpecificatio(ProductSpecification specification)
        {
            context = new MiniProjectTGDDContext();
            context.ProductSpecifications.Update(specification);
            context.SaveChanges();
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

        public string GetTypeIdBySpecification(int SpecificationId)
        {
            var data = context.ProductSpecifications.FirstOrDefault(s => s.SpecificationsId == SpecificationId);
            var TypeId = data.TypeId;
            return TypeId;
        }
    }

}

