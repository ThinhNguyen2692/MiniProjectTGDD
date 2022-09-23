using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Microsoft.EntityFrameworkCore;
using ModelProject.Models;


namespace DAL
{
    public interface IDalProductPhoto
    {
        public bool DalAddProductPhoto(ProductPhoto productPhoto);
        public void DelPhoto(string id);
        public List<ProductPhoto> GetProductPhotos();
        public List<ProductPhoto> GetProductPhoto(string VersionId);
    }
    public class Dal_productphotos : IDalProductPhoto
    {
        private MiniProjectTGDDContext context;

        public Dal_productphotos(MiniProjectTGDDContext context)
        {
            this.context = context;
        }

        public List<ProductPhoto> GetProductPhoto(string VersionId)
        {
            var data = context.ProductPhotos.Where(p => p.VersionId == VersionId).Include(p => p.Photo).ToList();
            return data;
        }



        /// <summary>
        /// Thêm liên kết ảnh và sản phẩm
        /// </summary>
        /// <param name="productPhoto">dữ liệu cần thêm (mã version sản phẩm, mã hình)</param>
        /// <returns></returns>
        public bool DalAddProductPhoto(ProductPhoto productPhoto)
        {
            context.Photos.Add(productPhoto.Photo);
            context.ProductPhotos.Add(productPhoto);
            context.SaveChanges();
            return true;
        }
        /// <summary>
        /// lấy toàn bộ dữ liệu productPhoto
        /// </summary>
        /// <returns></returns>
        public List<ProductPhoto> GetProductPhotos()
        {
            var GetProductPhotos = context.ProductPhotos.ToList();
            return GetProductPhotos;
        }
        /// <summary>
        /// Xóa hình sản phẩm
        /// </summary>
        /// <param name="id">Mã version sản phẩm</param>
        /// <returns></returns>
        public void DelPhoto(string id)
        {

            //lấy danh sách hình sản phẩm cần xóa
            var data = context.ProductPhotos.Where(c => c.VersionId == id);
            context.ProductPhotos.RemoveRange(data);
            context.SaveChanges();
        }
    }
}
