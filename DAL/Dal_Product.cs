using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public interface IDAlProduct
    {
        public void AddProduct(Product product);
        public List<Product> DalReadProductAll();
        public Product DalReadProduct(string productId);
        public int CheckVersionQuantity(string id);
        public string DeleteProduct(string id);
        public bool CheckProduct(string ProductId);

        public bool UpdateProduct(Product product);

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
        /// <returns>true sản phẩm được thêm</returns>
        /// <returns>false sản phẩm không được thêm</returns>
        public bool CheckProduct(string ProductId)
        {
           
            var data = context.Products.FirstOrDefault(p => p.ProductId == ProductId);
            if (data == null) return true;
            return false;
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
        public int CheckVersionQuantity(string id)
        {
           
            var data = context.ProductVersions.Where(p => p.ProductId == id).ToList();
            var Quantity = data.Count;

            return Quantity;
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


        /// <summary>
        /// cập nhật sản phẩm
        /// </summary>
        /// <param name="product">thông tin sản phẩm</param>
        
        public bool UpdateProduct(Product product)
        {
            
            context = new MiniProjectTGDDContext();
            context.Products.Update(product);
            context.SaveChanges();
            return true;
        }

    }
}
