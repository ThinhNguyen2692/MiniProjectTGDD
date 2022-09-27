using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelProject.ViewModel
{
    public class ListUserViewModel
    {
        public ListUserViewModel() { }
        public string UserName { get; set; }
        public string UserPhoto { get; set; }
        public int RoleId { get; set; }
        public int UserId { get; set; }

        public Role role { get; set; } = new Role();

    }
}
