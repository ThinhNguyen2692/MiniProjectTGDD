using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class Dal_Product
    {
        MiniProjectTGDDContext context = new MiniProjectTGDDContext();
        //Thêm sản phẩm
        public bool AddProduct(Product product)
        {
          
               
                context.Products.Add(product);
                context.SaveChanges();
            
            return true;
        }
        //
        public List<Product> DalReadProductAll()
        {
            var data = context.Products.Include(pv => pv.ProductVersions).ToList();
            return data;
        }
    }
}
