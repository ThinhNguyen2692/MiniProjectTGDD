using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

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
        private static Dal_ProductColor productColor;
       private  MiniProjectTGDDContext context = new MiniProjectTGDDContext();

        public static Dal_ProductColor GetProductColor()
        {
            if(productColor == null) { productColor = new Dal_ProductColor(); }
            return productColor;
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
