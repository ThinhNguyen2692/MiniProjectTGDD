﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelProject.ViewModel;
using ModelProject.Models;

namespace BUS.Services
{
    public interface IBusUser
    {
        public AddUserViewModel UserAdd(AddUserViewModel user);
        public List<ListUserViewModel> GetUsers();

        public EditUserViewModel GetEditUserViewModel(int UserId);
        public EditUserViewModel UpdateUser(EditUserViewModel editUserViewModel);
        public EditUserViewModel UpdatePassword(int UserId);
        public User UserLogin(int Userid, string Password);
    }
}
