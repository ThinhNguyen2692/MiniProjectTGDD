using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using Microsoft.EntityFrameworkCore;
using ModelProject.Models;
using DAL.DataModel;


namespace DAL
{
    public interface IDalProductPhoto
    {
        public bool DalAddProductPhoto(ProductPhoto productPhoto);
        public void DelPhoto(string id);
        public List<ProductPhoto> GetProductPhotos();
        public List<ProductPhoto> GetProductPhoto(string VersionId);
        public void DelPhotoProduct(ProductPhoto photo);
        public ProductPhoto GetById(int id);
    }
    public class Dal_productphotos : IDalProductPhoto
    {
        private IRepository<ProductPhoto> repository;
        private IUnitOfWork _uniOfWork;

        public Dal_productphotos(IUnitOfWork _uniOfWork)
        {
           this._uniOfWork = _uniOfWork;
            repository = _uniOfWork.Repository<ProductPhoto>();
        }

        public List<ProductPhoto> GetProductPhoto(string VersionId)
        {
            var data = repository.GetAll(predicate: p => p.VersionId == VersionId, include: p => p.Include(p => p.Photo)).ToList();
            return data;
        }



        /// <summary>
        /// Thêm liên kết ảnh và sản phẩm
        /// </summary>
        /// <param name="productPhoto">dữ liệu cần thêm (mã version sản phẩm, mã hình)</param>
        /// <returns></returns>
        public bool DalAddProductPhoto(ProductPhoto productPhoto)
        {
            repository.Add(productPhoto);
            _uniOfWork.SaveChanges();
            return true;
        }
        /// <summary>
        /// lấy toàn bộ dữ liệu productPhoto
        /// </summary>
        /// <returns></returns>
        public List<ProductPhoto> GetProductPhotos()
        {
            var GetProductPhotos = repository.List().ToList();
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
            var data = repository.GetAll(predicate: c => c.VersionId == id);
            if(data == null) return;
            repository.RemoveRange(data);
            _uniOfWork.SaveChanges();
        }

        /// <summary>
        /// Xóa hình sản phẩm
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public void DelPhotoProduct(ProductPhoto photo)
        { 
            repository.Delete(photo);
            _uniOfWork.SaveChanges();
        }

        public ProductPhoto GetById(int id)
        {
             var data = repository.GetAll(predicate: c => c.ProductPhotoId == id).FirstOrDefault();
            if (data == null) return null;
            return data;
        }

    }
}
