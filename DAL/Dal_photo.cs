using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL
{
    public class Dal_Photo
    {
        MiniProjectTGDDContext context = new MiniProjectTGDDContext();
        // Them hinh cho sản phẩm
        public int AddPhoto(Photo photo)
        {
                
                context.Photos.Add(photo);
                context.SaveChanges();
             return photo.PhotoId;
        }
    }
}
