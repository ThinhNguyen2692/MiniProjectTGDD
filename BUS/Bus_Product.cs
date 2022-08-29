using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;

namespace BUS
{
    public class Bus_Product
    {
        Dal_Product dal_Product = new Dal_Product();
        public bool AddProduct(string ProductId, string ProductName, string TypeId, string BrandsId, string fileName, string ProductDescription, DateTime ProductDate)
        {
            DateTime dateTime  = new DateTime(0001,01,01);
            if(ProductDate == dateTime)
            {
                ProductDate = DateTime.Now;
            }
            Product product = new Product(ProductId, ProductName, TypeId, BrandsId, fileName,ProductDescription,ProductDate);

            return dal_Product.AddProduct(product);
        }

        // lấy danh sách sản phẩm
        public List<Product> DalReadProductAll()
        {
            return dal_Product.DalReadProductAll();
        }
    }
}
