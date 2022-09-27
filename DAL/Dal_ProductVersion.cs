using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public interface IDalProductVersion
    {
        public bool AddProductVerion(ProductVersion productVersion);
        public bool DelProductVerion(string id);
        public ProductVersion DalReadProduct(string id);
        public List<ProductVersion> DalReadProductAll();
        public bool UpdateProductVersion(ProductVersion productVersion);
        public bool CheckProductVersion(string versionID);
    }

    public class Dal_ProductVersion:IDalProductVersion
    {
        private  MiniProjectTGDDContext context;
        public  Dal_ProductVersion(MiniProjectTGDDContext context)
        {
            this.context = context;
        }
        //Add thông tin phiên bản
        public bool AddProductVerion(ProductVersion productVersion)
        {
            var data = context.ProductVersions.Where(p => p.VersionId == productVersion.VersionId).FirstOrDefault();
            if(data != null)
            {
                return false;
            }
                context.ProductVersions.Add(productVersion);
                context.SaveChanges();
            return true;
        }


        //Xóa phiên bản sản phẩm
        public bool DelProductVerion(string id)
        {
          var data = context.ProductVersions.Include(pv => pv.PropertiesValues).Include(pv => pv.VersionQuantities).Include(p =>p.ProductPhotos).Include(p => p.ProductPhotos).First(v => v.VersionId == id);
            if (data == null) return false;
            context.PropertiesValues.RemoveRange(data.PropertiesValues);
            context.VersionQuantities.RemoveRange(data.VersionQuantities);
            context.ProductPhotos.RemoveRange(data.ProductPhotos);
            context.ProductVersions.Remove(data);
            context.SaveChanges();
            return true;
        }


       

        //lấy chi tiết sản phẩm
        public ProductVersion DalReadProduct(string id)
        {
            context = new MiniProjectTGDDContext();

            var data2 = context.ProductVersions.Where(p => p.VersionId == id).Include(pv => pv.Product).Include(p => p.PropertiesValues).ThenInclude(p=>p.Properties).ThenInclude(p => p.Specifications).Include(p => p.VersionQuantities).ThenInclude(p => p.Color).Include(p => p.Product).ThenInclude(p => p.ProductBrandNavigation).Include(p => p.Product).ThenInclude(p => p.ProductTypeNavigation).FirstOrDefault();
            if (data2 == null) return null;
            var data = context.Products.Where(p => p.ProductId == data2.ProductId).Include(g => g.ProductVersions).Include(p => p.EventDetails).ThenInclude(p => p.Event).FirstOrDefault();
            if (data == null) return null;
            data2.Product = data;
            return data2;
        }

        /// <summary>
        /// Lấy danh sách  tất cả sản phẩm
        /// </summary>
        /// <returns>danh sách sản phẩm</returns>
        public List<ProductVersion> DalReadProductAll()
        {
            var data = context.ProductVersions.Include(p => p.Product).ToList();
            return data;
        }

        /// <summary>
        /// cập nhật phiên bản sản phẩm sản phẩm 
        /// </summary>
        /// <param name="product">thông tin sản phẩm</param>

        public bool UpdateProductVersion(ProductVersion productVersion)
        {
            context = new MiniProjectTGDDContext();
            context.ProductVersions.Update(productVersion);
            context.SaveChanges();
            return true;
        }

        public bool CheckProductVersion(string versionID)
        {
            var data = context.ProductVersions.First(p => p.VersionId == versionID);
            if (data == null) return false;
            return true;
        }

    }
}
