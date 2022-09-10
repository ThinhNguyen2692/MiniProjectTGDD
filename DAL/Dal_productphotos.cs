using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;

namespace DAL
{
    public interface IDalProductPhoto
    {
        public bool DalAddProductPhoto(ProductPhoto productPhoto);
        public void DelPhoto(string id);
        public List<ProductPhoto> GetProductPhotos();
    }
    public class Dal_productphotos:IDalProductPhoto
    {
        private MiniProjectTGDDContext context = new MiniProjectTGDDContext();
        private static Dal_productphotos _instance;

        public static Dal_productphotos Instance
        {
            get {
                if (_instance == null) { _instance = new Dal_productphotos(); }
                return _instance;
            }
        }
        
        /// <summary>
        /// Thêm liên kết ảnh và sản phẩm
        /// </summary>
        /// <param name="productPhoto">dữ liệu cần thêm (mã version sản phẩm, mã hình)</param>
        /// <returns></returns>
        public bool DalAddProductPhoto(ProductPhoto productPhoto)
        {
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
