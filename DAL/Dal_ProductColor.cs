using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelProject.Models;

namespace DAL
{
    public interface IDalProductColor
    {
        public bool AddProductColor(ProductColor Color);
        public List<ProductColor> DalReadProductColors(string id);
        public List<string> delColor(string idProduct);

    }
    public class Dal_ProductColor:IDalProductColor
    {
       private  MiniProjectTGDDContext context;

        public Dal_ProductColor(MiniProjectTGDDContext context)
        {
            this.context = context; 
        }
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
            if (data == null) return null;
            return data;
        }

        //Xóa màu ra khỏi danh sách
        public List<string> delColor(string idProduct)
        {
            List<string> paths = new List<string>();
           
            var data = context.ProductColors.Where(p => p.ProductId == idProduct).ToList();
            //lấy đường dẫn ảnh để xóa
            foreach (var item in data)
            {
                paths.Add(item.ColorPath);
            }
            context.ProductColors.RemoveRange(data);
            context.SaveChanges();
            return paths;
        }

    }
}
