using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public interface IDAlProduct
    {
        public void AddProduct(Product product);
        public List<Product> DalReadProductAll();
        public Product DalReadProduct(string productId);
        public bool CheckVersionQuantity(string id);
        public string DeleteProduct(string id);
        public bool CheckProduct(string ProductId);
        public List<string> DeleteProductAuto(string id);

    }
    public class Dal_Product:IDAlProduct
    {
        private static Dal_Product dalProduct;

        public MiniProjectTGDDContext context = new MiniProjectTGDDContext();
       public static Dal_Product Instance
        {
            get
            {
                if (dalProduct == null) { dalProduct = new Dal_Product(); }
                return dalProduct;
            }
        }
        /// <summary>
        ///thêm sản phẩm mới
        /// </summary>
        /// <param name="product">thong tin sản phẩm</param>
        /// <returns>true thêm thành công</returns>
        public void AddProduct(Product product)
        {
          
            context.Products.Add(product);
                context.SaveChanges();
        }
        /// <summary>
        /// Kiểm tra mã sản phẩm, thông tin sản đã tồn tại chưa
        /// </summary>
        /// <param name="ProductId">mã sản phẩm</param>
        /// <returns>true sản phẩm chưa tồn tại</returns>
        /// <returns>false sản phẩm đã tồn tại</returns>
        public bool CheckProduct(string ProductId)
        {
            var data = context.Products.FirstOrDefault(p => p.ProductId == ProductId);
            if (data == null) return false;
            return true;
        }

      


        /// <summary>
        /// lấy dánh sách sản phẩm
        /// </summary>
        /// <returns></returns>
        public List<Product> DalReadProductAll()
        {
           
            var data = context.Products.Include(p=>p.ProductVersions).ToList();
            return data;
        }

        /// <summary>
        /// đọc thông tin 1 sản phẩm
        /// </summary>
        /// <param name="productId">mã sản phẩm</param>
        /// <returns></returns>
        public Product DalReadProduct(string productId)
        {
            
            var data = context.Products.FirstOrDefault(p => p.ProductId == productId);
            return data;
        }
        /// <summary>
        /// kiểm tra số lượng phiên bản sản phẩm
        /// </summary>
        /// <param name="id">mã sản phẩm</param>
        /// <returns></returns>
        //kiểm tra số lượng phiên bản của phiên bản
        public bool CheckVersionQuantity(string id)
        {
            context = new MiniProjectTGDDContext();
            var data = context.ProductVersions.Include(v => v.VersionQuantities).First(p => p.VersionId == id);
            foreach (var item in data.VersionQuantities)
            {
                if(item.Quantity != 0)
                {
                    return false;
                }
            }
            return true;
        }


        /// <summary>
        /// Xóa sản phẩm
        /// </summary>
        /// <param name="id">mã sản phẩm</param>
        /// <returns>path hình</returns>
        //Xóa sản phẩm
        public string DeleteProduct(string id)
        {
            //Lưu tên ảnh để xóa
            string path = null;
            context = new MiniProjectTGDDContext();
            var data = context.Products.First(p => p.ProductId == id);
             context.Products.Remove(data);
            
            context.SaveChanges();
                path = data.ProductPhoto;
            return path;
        }

        public List<string> DeleteProductAuto(string id)
        {
            context = new MiniProjectTGDDContext();
            var data = context.ProductVersions.Where(p => p.ProductId == id).ToList();
            if(data.Count == 0)
            {
                //danh sách tên hình cần xóa
                List<string> path = new List<string>();
                var data2 = context.Products.Include(c => c.ProductColors).ThenInclude(p => p.VersionQuantities).First(p => p.ProductId == id);
                path.Add(data2.ProductPhoto);
                foreach (var item in data2.ProductColors)
                {
                    path.Add(item.ColorPath);
                }
                foreach (var item in data2.ProductColors)
                {
                    if(item.VersionQuantities.Count > 0)
                    {
                        context.VersionQuantities.RemoveRange(item.VersionQuantities);
                    }
                }
                context.ProductColors.RemoveRange(data2.ProductColors);
                context.Products.Remove(data2);
                context.SaveChanges();
                return path;
            }
            else
            {
                return null;
            }
           
        }




    }
}
