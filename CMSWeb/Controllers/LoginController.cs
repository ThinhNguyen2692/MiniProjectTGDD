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
        public IActionResult Index()
        
        {
            
            return View("Index");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Index(LoginViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = iBusUser.UserLogin((int) viewModel.UserId, viewModel.Password);
                if(user != null)
                {
                    await SignInUser(user);
                    return Redirect("Home/ShowBrands");
                }
            }
            ModelState.AddModelError("InvalidAuth", "Tên đăng nhập hoặc mật khẩu không chính xác");
            return View("Index", viewModel);
        }




        private async Task SignInUser(User user)
        {
           
            var claims = new List<Claim> {
                 new Claim(ClaimTypes.NameIdentifier, user.UserId.ToString()),
                 new Claim(ClaimTypes.Name, user.UserName.ToString()),
                 new Claim(ClaimTypes.CookiePath, user.UserPhoto.ToString()),
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
