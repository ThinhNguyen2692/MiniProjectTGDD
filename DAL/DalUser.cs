using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using ModelProject.Models;
using ModelProject.ViewModel;
using DAL.DataModel;

namespace DAL
{
    public interface IDAlUser
    {
        public int UserAdd(User user);
        public List<User> GetUser();
        public User GetUserById(int UserId);
        public User UpdateUser(User user);
        public User UpdatePassword(int UserId);
        public User Login(string pass, int UserId);

        public User UpdatePassword(string pass, int UserId);
    }
    public class DalUser:IDAlUser
    {
        private IRepository<User> repository;
        private IUnitOfWork _unitOfWork;


        public DalUser(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
            this.repository = _unitOfWork.Repository<User>();
        }

        public int UserAdd(User user)
        {
            user.Password = GenerateMD5(user.Password);
            repository.Add(user);
            _unitOfWork.SaveChanges();
            return user.UserId;
        }
        /// <summary>
        /// Lấy danh sách user
        /// </summary>
        /// <returns>Danh sách user</returns>
        public List<User> GetUser()
        {
            var data = repository.List().ToList();
            return data;
        }


       /// <summary>
       /// lấy thông tin 1 nhân viên
       /// </summary>
       /// <param name="UserId">id nhân viên</param>
       /// <returns>user?</returns>
        public User GetUserById(int UserId) {
        
            var data = repository.GetById(x => x.UserId == UserId);
            if (data == null) return null;
            return data;
        
        }


        /// <summary>
        /// Cập nhật thông tin nhân viên
        /// </summary>
        /// <param name="user">thông tin nhân viên</param>
        /// <returns></returns>
        public User UpdateUser(User user)
        {
            var data = repository.GetById(u => u.UserId == user.UserId);
            if (data == null) return null;
            data.UserName = user.UserName;
            data.UserPhone = user.UserPhone;
            data.Email = user.Email;
            data.RoleId = user.RoleId;
            if(user.UserPhoto != null)
            {
                data.UserPhoto = user.UserPhoto;
            }
            _unitOfWork.SaveChanges();

            return data;
        }


        /// <summary>
        /// Làm mới mật Khẩu
        /// </summary>
        /// <param name="UserId">mã nhân viên</param>
        /// <returns></returns>
        public User UpdatePassword(int UserId)
        {
            string Newpassword = GenerateMD5("123456789");
            var data = repository.GetById(u => u.UserId == UserId);
            if (data == null) return null;
            data.Password = Newpassword;
            _unitOfWork.SaveChanges();

            return data;
        }


        //lấy thông tin cho login
        public User Login(string pass, int UserId)
        {
            string Password = GenerateMD5(pass);
            var data = repository.GetById(u => u.UserId == UserId && u.Password == Password);
            if (data == null) return null;
            return data;
        }

        
        /// <summary>
        /// nhân viên đổi mật khẩu
        /// </summary>
        /// <param name="pass"></param>
        /// <param name="UserId"></param>
        /// <returns></returns>
        public User UpdatePassword(string pass, int UserId)
        {
            string Newpassword = GenerateMD5(pass);
            var data = repository.GetById(u => u.UserId == UserId);
            if (data == null) return null;
            data.Password = Newpassword;
            _unitOfWork.SaveChanges();

            return data;
        }


        /// <summary>
        /// Hàm chuyển MD5
        /// </summary>
        /// <param name="password"></param>
        /// <returns></returns>
        private string GenerateMD5(string password)
        {
            return string.Join("", MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(password)).Select(s => s.ToString("x2")));
        }
    }
}
