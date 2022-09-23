using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelProject.Models;
using Microsoft.EntityFrameworkCore;


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
        private MiniProjectTGDDContext context;
       public  Dal_Photo(MiniProjectTGDDContext context)
        {
        this.context = context;
        }
        
        // Them hinh cho sản phẩm
        public int AddPhoto(Photo photo)
        {
                context.Photos.Add(photo);
                context.SaveChanges();
             return photo.PhotoId;
        }

        public List<Photo> ReadAll()
        {
            var data = context.Photos.ToList();
            
            return data;
        }

       

        /// <summary>
        /// Xóa hình khi không còn sử dụng
        /// </summary>
        /// <returns>danh sách đường dẫn hình (Xóa hình khỏi thư mục)</returns>
        public List<string> DeletePhoto()
        {
            List<string> paths = new List<string>();
         
            var data = context.Photos.Include(p => p.ProductPhotos).Where(p => p.ProductPhotos.Count == 0).ToList();
            context.Photos.RemoveRange(data);
            context.SaveChanges();
            // lấy danh sách path
            foreach (var item in data)
            {
                paths.Add(item.PhotoPath);
            }
            return paths;
        }
    }
}
