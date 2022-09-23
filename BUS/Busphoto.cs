using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ModelProject.Models;
using ModelProject.ViewModel;
using BUS.Services;
using Microsoft.AspNetCore.Http;

namespace BUS
{

    public class Busphoto:IBusPhoto
    {
        private static IDalPhoto iDalPhoto;
       private static  Busphoto busPhoto;
        public Busphoto (IDalPhoto Photo)
        {
            iDalPhoto = Photo;
           
        }
        public void AddImageProduct(List<IFormFile> fileImages)
        {
            foreach (var item in fileImages)
            {
                Photo photo = new Photo();
                photo.PhotoPath = item.FileName;
                iDalPhoto.AddPhoto(photo);
                string fileName = item.FileName;
                try
                {
                    string upLoad = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);
                    var stream = new FileStream(upLoad, FileMode.Create);
                    item.CopyToAsync(stream);
                }
                catch (Exception)
                {

                    continue;
                }
            }
        }


        /// <summary>
        /// Đọc ảnh trong database Photo
        /// </summary>
        /// <returns>PhotoViewModel</returns>
        public PhotoViewModel GetPhotoViewModel()
        {
            var data = iDalPhoto.ReadAll();
            PhotoViewModel photoViewModel = new PhotoViewModel();
            foreach (var item in data)
            {
                InformationPhoto photo = new InformationPhoto();
                photo.PhotoId = item.PhotoId;
                photo.PathImage = item.PhotoPath;
                photoViewModel.informationPhoto.Add(photo);
            }

            return photoViewModel;
        }

    }
}
