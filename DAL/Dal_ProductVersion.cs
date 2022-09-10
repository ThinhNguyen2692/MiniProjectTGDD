using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public interface IDalProductVersion
    {
        public bool AddProductVerion(ProductVersion productVersion);
        public void DelProductVerion(string id);
        public ProductVersion DalReadProduct(string id);
        public List<ProductVersion> DalReadProductAll();
    }

    public class Dal_ProductVersion:IDalProductVersion
    {
        private static MiniProjectTGDDContext context = new MiniProjectTGDDContext();
        private static Dal_ProductVersion _instance;
        public static Dal_ProductVersion GetProductVersion()
        {
            if(_instance == null) { _instance = new Dal_ProductVersion(); }
            return _instance;
        }
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
        public ProductVersion DalReadProduct(string id)
        {
          
            var data2 = context.ProductVersions.Where(p => p.VersionId == id).Include(pv => pv.Product).Include(p => p.PropertiesValues).Include(p => p.VersionQuantities).Include(p => p.Product).FirstOrDefault();
            return data2;
        }

        /// <summary>
        /// Lấy danh sách  tất cả sản phẩm
        /// </summary>
        /// <returns>danh sách sản phẩm</returns>
        public List<ProductVersion> DalReadProductAll()
        {
            var data2 = context.ProductVersions.Include(p => p.Product).ToList();
            return data2;
        }

        /// <summary>
        /// cập nhật phiên bản sản phẩm sản phẩm 
        /// </summary>
        /// <param name="product">thông tin sản phẩm</param>

        public bool UpdateProductVersion(ProductVersion productVersion)
        {
            context = new MiniProjectTGDDContext();
            context.ProductVersions.Update(productVersion);

            return true;
        }


    }
}
