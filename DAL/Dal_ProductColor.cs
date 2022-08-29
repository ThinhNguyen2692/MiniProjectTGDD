using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL
{
    public class Dal_ProductColor
    {
        MiniProjectTGDDContext context = new MiniProjectTGDDContext();
        //Thêm màu cho sản phẩm
        public bool AddProductColor(ProductColor Color)
        {
            
                
                context.ProductColors.Add(Color);
                context.SaveChanges();
            
            return true;
        }

       public List<ProductColor> DalReadProductColors(string id)
        {
           
              
                var data = context.ProductColors.Where(c => c.ProductId == id).ToList();
                
               
          
            return data;
        }

        //Xóa màu ra khỏi danh sách
        public bool delColor(string idProduct)
        {
            return true;
        }

    }
}
