using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelProject.Models;
using Microsoft.EntityFrameworkCore;
using DAL.DataModel;

namespace DAL
{
    public interface IDalPhoto
    {
        public int AddPhoto(Photo photo);
        public List<string> DeletePhoto();
        public List<Photo> ReadAll();
    }
    public class Dal_Photo:IDalPhoto
    {

        private IRepository<Photo> repository;
        private IUnitOfWork _unitOfWork;
        public  Dal_Photo(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
            repository = _unitOfWork.Repository<Photo>();
        }
        
        // Them hinh cho sản phẩm
        public int AddPhoto(Photo photo)
        {
            var data = ReadAll();
            foreach (var item in data)
            {
                if(String.Compare(item.PhotoPath, photo.PhotoPath) == 0)
                {
                    return item.PhotoId;
                }
            }

            repository.Add(photo);
                _unitOfWork.SaveChanges();
             return photo.PhotoId;
        }

        public List<Photo> ReadAll()
        {
            var data = repository.List().ToList();

            return data;
        }

       

        /// <summary>
        /// Xóa hình khi không còn sử dụng
        /// </summary>
        /// <returns>danh sách đường dẫn hình (Xóa hình khỏi thư mục)</returns>
        public List<string> DeletePhoto()
        {
            //List<string> paths = new List<string>();
         
            //var data = context.Photos.Include(p => p.ProductPhotos).Where(p => p.ProductPhotos.Count == 0).ToList();
            //context.Photos.RemoveRange(data);
            //context.SaveChanges();
            //// lấy danh sách path
            //foreach (var item in data)
            //{
            //    paths.Add(item.PhotoPath);
            //}
            return null;
        }
    }
}
