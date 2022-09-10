using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL;

namespace BUS
{
    public interface IBusPhoto
    {
        public List<int> AddPhoto(List<string> FileName);
        public List<string> DeletePhoto();

    }
    public class Bus_photo:IBusPhoto
    {
        private static IDalPhoto dal_Photo;
       private static  Bus_photo busPhoto;
        public static Bus_photo GetPhoto(IDalPhoto Photo)
        {
            dal_Photo = Photo;
            if(busPhoto == null) { busPhoto = new Bus_photo(); }
            return busPhoto;
        }
        //Thêm hình
        public List<int> AddPhoto(List<string> FileName) {
            List<int> list = new List<int>();
          
                foreach (var item in FileName)
                {
                    Photo p = new Photo(item);
                    int id = dal_Photo.AddPhoto(p);
                    if (id != -1)
                    {
                        list.Add(id);
                    }
                }
           
            return list;
        }

        /// <summary>
        /// Xóa hình có trong danh sách
        /// </summary>
        /// <returns>danh sách đường dẫn ảnh (Xóa hình ra khỏi thư mục)</returns>
        public List<string> DeletePhoto()
        {
           return dal_Photo.DeletePhoto();
        }

    }
}
