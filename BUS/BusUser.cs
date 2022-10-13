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
            string upLoad = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\User\\", fileName);
            var stream = new FileStream(upLoad, FileMode.OpenOrCreate);
            fileImage.CopyToAsync(stream);
        }


        /// <summary>
        /// Add user mới
        /// </summary>
        /// <param name="viewModel">thông tin user cần thêm</param>
        /// <returns>addviewmodel = new AddUserViewModel();</returns>
        public AddUserViewModel UserAdd(AddUserViewModel viewModel)
        {
            var user = new User() {
                Email = viewModel.Email,
                UserName = viewModel.UserName,
                UserPhone = viewModel.UserPhone,
                Password = viewModel.Password,
                UserPhoto = "https://localhost:7079/images/User/" + viewModel.UserPhoto.FileName,
                RoleId = viewModel.roleID
            };
            var userID = iDalUser.UserAdd(user);
            if ( userID!= 0) {
                AddFileImage(viewModel.UserPhoto);
                viewModel.UserId = userID;
                viewModel.Message = "addTrue";
                        
            }

            return viewModel;
        }


        /// <summary>
        /// lấy thông tin nhân viên cho viewModel
        /// </summary>
        /// <returns>ListUserViewModel</returns>
        public List<ListUserViewModel> GetUsers()
        {
            var users = new List<ListUserViewModel>();
            var data = iDalUser.GetUser();
            foreach (var item in data)
            {
                var user = new ListUserViewModel();
                user.UserName = item.UserName;
                user.UserId = item.UserId;
                user.UserPhoto = item.UserPhoto;
                user.RoleId = (int)item.RoleId;
                users.Add(user);
            }
            return users;
        }

        /// <summary>
        /// lấy thông tin chi tiết nhân viên(không nhân password)
        /// </summary>
        /// <param name="UserId">mã nhân viên</param>
        /// <returns>EditUserViewModel</returns>
        public EditUserViewModel GetEditUserViewModel(int UserId)
        {
            var data = iDalUser.GetUserById(UserId);
            EditUserViewModel viewModel = new EditUserViewModel();
            viewModel = UserToEditViewModel(data);
            return viewModel;
        }
    
        
        /// <summary>
        /// Cập nhật thông tim user
        /// </summary>
        /// <param name="editUserViewModel">thông tin user cần cập nhật</param>
        /// <returns></returns>
        public EditUserViewModel UpdateUser(EditUserViewModel editUserViewModel)
        {
            User user = new User();
            user.UserName = editUserViewModel.UserName;
            user.UserId = editUserViewModel.UserId;
            user.UserPhone = editUserViewModel.UserPhone;
            user.RoleId = editUserViewModel.RoleId;
            user.Email = editUserViewModel.Email;
            if(editUserViewModel.FileImage != null)
            {
                user.UserPhoto = "https://localhost:7079/images/User/" + editUserViewModel.FileImage.FileName;
                AddFileImage(editUserViewModel.FileImage);
            }
            user = iDalUser.UpdateUser(user);
            if (user == null) {
                editUserViewModel.Message = "UpdateFalse";
            }
            else {
                editUserViewModel.Message = "UpdateTrue"; 
                editUserViewModel.UserPhoto = user.UserPhoto;
            }
            return editUserViewModel;   
        }
    
        /// <summary>
        /// Cập nhật pass
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public EditUserViewModel UpdatePassword(int UserId)
        {
            var data = iDalUser.UpdatePassword(UserId);
            EditUserViewModel viewModel = new EditUserViewModel();
            if (data != null) { 
                viewModel.Message = "UpdatePassTrue";
                viewModel = UserToEditViewModel(data);

            }
            else { viewModel.Message = "UpdatePassFalse";}
           
            return viewModel;
        }

        public User UserLogin(int Userid, string Password)
        {
            var data = iDalUser.Login(Password, Userid);
            if (data == null) return null;

            return data;
        }


        /// <summary>
        /// lấy thông tin user chuyển qua viewmodel
        /// </summary>
        /// <param name="data">thông tin user</param>
        /// <returns>EditUserViewModel</returns>
        private EditUserViewModel UserToEditViewModel(User data)
        {
            EditUserViewModel viewModel = new EditUserViewModel();
            viewModel.UserPhone = data.UserPhone;
            viewModel.UserPhoto = data.UserPhoto;
            viewModel.UserName = data.UserName;
            viewModel.UserId = data.UserId;
            viewModel.RoleId = (int)data.RoleId;
            viewModel.Email = data.Email;

            return viewModel;
        }

    }


}
