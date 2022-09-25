using CMSWeb.Models;
using Microsoft.AspNetCore.Mvc;
using ModelProject.ViewModel;
using System.Diagnostics;
using BUS.Services;

namespace CMSWeb.Controllers
{
    public class UserController : Controller
    {
        private readonly IBusUser iBusUser;
        private readonly ILogger<UserController> _logger;

       


        public UserController(ILogger<UserController> logger, IBusUser iBusUser)
        {
            _logger = logger;
            this.iBusUser = iBusUser;
       
        }
        [Route("FormAddUser")]
        public IActionResult FormAddUser()
        {
            var viewModel = new AddUserViewModel();
            return View("FormAddUser", viewModel);
        }


        public IActionResult AddUser(AddUserViewModel viewModel)
        {
            viewModel = iBusUser.UserAdd(viewModel);
            return View("FormAddUser", viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
