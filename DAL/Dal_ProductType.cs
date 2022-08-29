using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL
{
    public class Dal_ProductType
    {
        MiniProjectTGDDContext context = new MiniProjectTGDDContext();
        public bool DalAddType(ProductType type)
        {  
                context.ProductTypes.Add(type);
                context.SaveChanges();
            return true;
        }

        //Cập nhật thông tin ngành hàng
        public bool DalUpdateType(ProductType type)
        {
            
                context.ProductTypes.Update(type);
                context.SaveChanges();
            return true;
        }


        //lấy 1 loại sản phẩm 
        public ProductType ReadType(string id)
        {
            
                var item = context.ProductTypes.First(t => t.Typeid == id);
                
            return item;
        }

        //lấy danh sách ngành hàng
        public List<ProductType> ReadTypes()
        {
                var context = new MiniProjectTGDDContext();
                var data = context.ProductTypes.ToList();
            return data;
        }

        //Xóa ngành hàng
        public bool deletetype(string typeid)
        {
            
                var item = context.ProductTypes.First(t => t.Typeid == typeid);
                context.ProductTypes.Remove(item);
                context.SaveChanges();
          
            return true;
        }

    }
}
