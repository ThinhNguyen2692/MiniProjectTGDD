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
        /// <summary>
        /// load form nhap thong tin nhan vien
        /// </summary>
        /// <returns></returns>
        [Route("FormAddUser")]
        public IActionResult FormAddUser()
        {
            var viewModel = new AddUserViewModel();
            return View("FormAddUser", viewModel);
        }
        /// <summary>
        /// Thêm quản trị vien
        /// </summary>
        /// <param name="viewModel"></param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddUser(AddUserViewModel viewModel)
        {
            viewModel = iBusUser.UserAdd(viewModel);
            return View("FormAddUser", viewModel);
        }
        /// <summary>
        /// show danh sách nhân viên
        /// </summary>
        /// <returns>ShowUsers</returns>
        /// <returns>List ListUserViewModel</returns>
        public IActionResult ShowUsers()
        {
            var viewModel = iBusUser.GetUsers();
            return View("ShowUsers", viewModel);
        }
        /// <summary>
        /// form hiện thông tin chi tiết nhân viên
        /// </summary>
        /// <param name="UserId">mã nhân viên</param>
        /// <returns>Vew ShowUserDetail</returns>
        /// <returns>EditUserViewModel</returns>
        [HttpGet]
        [Route("User/ShowUserDetail")]
        public IActionResult ShowUserDetail(int UserId)
        {
            EditUserViewModel viewModel = iBusUser.GetEditUserViewModel(UserId);
            return View(viewModel);
        }
        /// <summary>
        /// cập nhật thông tin user
        /// </summary>
        /// <param name="viewModel">thông tin chuyển từ view</param>
        /// <returns></returns>
        public IActionResult UpdateUser(EditUserViewModel viewModel)
        {
            viewModel = iBusUser.UpdateUser(viewModel);
            return View("ShowUserDetail", viewModel);
        }
        public IActionResult UpdatePass(int Userid)
        {
            EditUserViewModel viewModel = iBusUser.UpdatePassword(Userid);
            return View("ShowUserDetail", viewModel);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
