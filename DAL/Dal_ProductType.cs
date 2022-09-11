using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL
{
    public interface IDaltype
    {
       bool DalAddType(ProductType type);
        bool DalUpdateType(ProductType type);
        ProductType ReadType(string id);
        List<ProductType> ReadTypes();
        public void deletetype(string typeid);

    }
    public class Dal_ProductType:IDaltype
    {

        private MiniProjectTGDDContext context;

        public Dal_ProductType(MiniProjectTGDDContext context)
        {
            this.context = context;
        }


        //Thêm ngành hàng
        public bool DalAddType(ProductType type)
        {
          
            if (ReadType(type.Typeid) != null)
            {
                return false;
            }
            context.ProductTypes.Add(type);
                context.SaveChanges();
            return true;
        }

        //Cập nhật thông tin ngành hàng
        public bool DalUpdateType(ProductType type)
        {
            context = new MiniProjectTGDDContext();
            context.Update(type);
            context.SaveChanges();
            return true;
        }


        //lấy 1 loại sản phẩm 
        public ProductType ReadType(string id)
        {
          
            var item = context.ProductTypes.FirstOrDefault(t => t.Typeid == id);       
            return item;
        }

        //lấy danh sách ngành hàng
        public List<ProductType> ReadTypes()
        {
          
            var data = context.ProductTypes.ToList();
            return data;
        }

        //Xóa ngành hàng
        public void deletetype(string typeid)
        {
            //kiểm tra sản phẩm ngành hàng
                var item = context.ProductTypes.First(t => t.Typeid == typeid);
                context.ProductTypes.Remove(item);
                context.SaveChanges();
             
        }

    }
}
