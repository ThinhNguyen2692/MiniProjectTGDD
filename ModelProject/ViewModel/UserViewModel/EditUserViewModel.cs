using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelProject.ViewModel
{
    public class EditUserViewModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string UserPhone { get; set; } = null!;
        public string UserPhoto { get; set; } = null!;
        public IFormFile FileImage { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int? RoleId { get; set; }
        public Role role { get; set; } = new Role();

        public string Message { get; set; } = null!;

        public EditUserViewModel() { }
    }
}
