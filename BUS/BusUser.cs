using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS.Services;
using ModelProject.ViewModel;
using ModelProject.Models;
using DAL;
using Microsoft.AspNetCore.Http;

namespace BUS
{
    public class BusUser : IBusUser
    {

        private IDAlUser iDalUser;

        public BusUser(IDAlUser iDalUser) { this.iDalUser = iDalUser; }



        /// <summary>
        /// hàm thêm hình
        /// </summary>
        /// <param name="fileImage"></param>
        public void AddFileImage(IFormFile fileImage)
        {
            string fileName = fileImage.FileName;
            string upLoad = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\ProductDefault\\", fileName);
            var stream = new FileStream(upLoad, FileMode.OpenOrCreate);
            fileImage.CopyToAsync(stream);
        }

        public AddUserViewModel UserAdd(AddUserViewModel viewModel)
        {
            var user = new User() {
                Email = viewModel.Email,
                UserName = viewModel.UserName,
                UserPhone = viewModel.UserPhone,
                Password = viewModel.Password,
                UserPhoto = viewModel.UserPhoto.FileName
            };

            if (iDalUser.UserAdd(user) == true) {
                AddFileImage(viewModel.UserPhoto);
                viewModel = new AddUserViewModel();
                viewModel.Message = "addTrue";
                        
            }

            return viewModel;
        }
    }
}
