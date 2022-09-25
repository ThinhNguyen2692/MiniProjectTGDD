using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using ModelProject.Models;
using ModelProject.ViewModel;

namespace DAL
{
    public interface IDAlUser
    {
        public bool UserAdd(User user);
    }
    public class DalUser:IDAlUser
    {
        private MiniProjectTGDDContext context;

        public DalUser(MiniProjectTGDDContext context) { this.context = context; }

        public bool UserAdd(User user)
        {
            user.Password = GenerateMD5(user.Password);
            context.Users.Add(user);
            user.UserId = user.UserId + 1000;
            context.SaveChanges();
            return true;
        }

        private string GenerateMD5(string password)
        {
            return string.Join("", MD5.Create().ComputeHash(Encoding.ASCII.GetBytes(password)).Select(s => s.ToString("x2")));
        }
    }
}
