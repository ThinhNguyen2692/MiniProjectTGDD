using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;

namespace BUS
{
    public interface IBusProduct
    {
        public void AddProduct(Product product);
        public List<Product> DalReadProductAll();
        public Product BusReadProduct(string productId);
        public string DeleteProduct(string id);
        public bool CheckProduct(string ProductId);
        public int CheckVersionQuantity(string id);
    }
    public class Bus_Product: IBusProduct
    {

        public  Bus_Product (IDAlProduct product) {
            
            dal_Product = product;
         }

        private  IDAlProduct dal_Product ;
        public void AddProduct(Product product )
        {
            DateTime dateTime  = new DateTime(0001,01,01);
            if(product.ReleaseTime == dateTime)
            {
                product.ReleaseTime = DateTime.Now;
            }
             dal_Product.AddProduct(product);
        }

        // lấy danh sách sản phẩm
        public List<Product> DalReadProductAll()
        {
            return dal_Product.DalReadProductAll();
        }

        public Product BusReadProduct(string productId)
        {
            return dal_Product.DalReadProduct(productId);
        }


        /// <summary>
        /// Xóa sản phẩm
        /// </summary>
        /// <param name="id">mã sản phẩm</param>
        /// <returns>path hình</returns>
        public string DeleteProduct(string id)
        {
           return dal_Product.DeleteProduct(id);
        }

        /// <summary>
        /// Kiểm tra mã sản phẩm, thông tin sản đã tồn tại chưa
        /// </summary>
        /// <param name="ProductId">mã sản phẩm</param>
        /// <returns>true sản phẩm được thêm</returns>
        /// <returns>false sản phẩm không được thêm</returns>
        public bool CheckProduct(string ProductId)
        {
            return dal_Product.CheckProduct(ProductId);
        }
        public int CheckVersionQuantity(string id)
        {
            return dal_Product.CheckVersionQuantity(id);
        }

        /// <summary>
        /// cập nhật sản phẩm
        /// </summary>
        /// <param name="product">thông tin sản phẩm</param>
        public bool UpdateProduct(Product product)
        {
            return dal_Product.UpdateProduct(product);
        }

    }
}
