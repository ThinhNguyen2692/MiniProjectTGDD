using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class Dal_ProductVersion
    {
        MiniProjectTGDDContext context = new MiniProjectTGDDContext();
        //Add thông tin phiên bản
        public bool AddProductVerion(ProductVersion productVersion)
        {
            
                context.ProductVersions.Add(productVersion);
                context.SaveChanges();
           
            return true;
        }


        //Xóa phiên bản sản phẩm
        public void DelProductVerion(string id)
        {
                var data = context.ProductVersions.First(v => v.VersionId == id);
                context.ProductVersions.Remove(data);
            context.SaveChanges();
        }

       

        //lấy chi tiết sản phẩm
        public Product DalReadProduct(string id)
        {
            var data = context.Products.Include(pv => pv.ProductVersions).Where(p => p.ProductVersions.Any(pv => pv.VersionId == id)).FirstOrDefault();
            return data;
        }
    }
}
