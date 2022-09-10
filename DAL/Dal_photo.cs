using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public interface IDalPhoto
    {
        public int AddPhoto(Photo photo);
        public List<string> DeletePhoto();
    }
    public class Dal_Photo:IDalPhoto
    {
        private static Dal_Photo dalPhoto;
        private MiniProjectTGDDContext context = new MiniProjectTGDDContext();
       public static Dal_Photo GetDalPhoto()
        {
            if(dalPhoto == null) { dalPhoto = new Dal_Photo(); }
            return dalPhoto;
        }
        
        // Them hinh cho sản phẩm
        public int AddPhoto(Photo photo)
        {
                context.Photos.Add(photo);
                context.SaveChanges();
             return photo.PhotoId;
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
