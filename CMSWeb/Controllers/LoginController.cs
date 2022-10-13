using Microsoft.AspNetCore.Mvc;
using ModelProject.ViewModel;
using ModelProject.Models;
using BUS.Services;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace CMSWeb.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        private readonly IBusUser iBusUser;
        private readonly ILogger<LoginController> _logger;

        public LoginController(ILogger<LoginController> logger, IBusUser iBusUser)
        {
            _logger = logger;
            this.iBusUser = iBusUser;
        }
        /// <summary>
        /// hiện trang đăng nhập
        /// </summary>
        /// <param name="returnUrl">đưỡng dẫn trỏ tới</param>
        /// <returns></returns>
        public IActionResult Index(string returnUrl = null)
        {
            var ReturnUrl = returnUrl ?? "/";
            var viewModel = new LoginViewModel() { GetUrl = ReturnUrl };
            return View("Index", viewModel);
        }
        /// <summary>
        /// kiểm tra đăng nhập
        /// </summary>
        /// <param name="viewModel">thông tin đăng nhập</param>
        /// <param name="returnUrl">đường đẫn tới</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginViewModel viewModel)
        {

            if (ModelState.IsValid)
            {
                var user = iBusUser.UserLogin((int)viewModel.UserId, viewModel.Password);
                if (user != null)
                {
                    await SignInUser(user);
                    return Redirect(viewModel.GetUrl);
                }
            }
            ModelState.AddModelError("InvalidAuth", "Tên đăng nhập hoặc mật khẩu không chính xác");
            return View("Index", viewModel);
        }


        [Route("Logout")]
        public async Task<IActionResult> OnGetAsync()
        {
            
            // Clear the existing external cookie
            await HttpContext.SignOutAsync(
                CookieAuthenticationDefaults.AuthenticationScheme);

            return Redirect("login/Index");
        }

        private async Task SignInUser(User user)
        {

            //switch (user.RoleId)
            //{
            //    case 1: break;
            //    default:
            //        break;
            //}

            var claims = new List<Claim> {
                 new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                 new Claim(ClaimTypes.Name, user.UserName.ToString()),
                 new Claim(ClaimTypes.CookiePath, user.UserPhoto.ToString()),
                 new Claim(ClaimTypes.GivenName, user.UserPhoto.ToString()),
                 new Claim(ClaimTypes.Role, user.RoleId.ToString()),
                 new Claim(ClaimTypes.MobilePhone, user.UserPhone),
                 new Claim(ClaimTypes.Email, user.Email),
                 

            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            await HttpContext.SignInAsync(principal);
        }
    }
}
