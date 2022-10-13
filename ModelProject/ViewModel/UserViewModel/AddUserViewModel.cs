using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using ModelProject.Models;
namespace ModelProject.ViewModel
{
    public class AddUserViewModel
    {
        public int UserId { get; set; } = 0; 
        public string UserName { get; set; } = null!;
        public string UserPhone { get; set; } = null!;
        public IFormFile UserPhoto { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int roleID { get; set; } 
        public string Message { get; set; }
        public Role role { get; set; } = new Role();


        public AddUserViewModel() { }

       
        


    }

    public class RoleUser
    {
        public RoleUser() { }
        public string RoleName { get; set; }
        public int RoleId { get; set; }
    }
        
        
  }
