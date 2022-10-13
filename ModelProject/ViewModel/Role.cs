using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelProject.ViewModel
{
    public class Role
    {
        public List<RoleUser> GetRoleUsers()
        {
            List<RoleUser> roleUsers = new List<RoleUser>()
            {
                //Nhân viên
                new RoleUser(){RoleName = "Quản lý sản phẩm, khuyến mãi", RoleId = 1},
                new RoleUser(){RoleName = "Quản lý hóa đơn, khách hàng", RoleId = 2},
                new RoleUser(){RoleName = "Quản lý User", RoleId = 3},
                new RoleUser(){RoleName = "Giao nhận", RoleId = 4},
                new RoleUser(){RoleName = "Quản lý", RoleId = 5},
                new RoleUser(){RoleName = "Thống kê", RoleId = 6},
            };
            

            return roleUsers;
        }

        public string GetRoleUser(int RoleId)
        {

            foreach (var item in GetRoleUsers())
            {
                if (item.RoleId == RoleId) return item.RoleName;
            }
             
            return "";        }

    }
}
