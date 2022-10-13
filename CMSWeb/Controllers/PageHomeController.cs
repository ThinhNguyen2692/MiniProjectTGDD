using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CMSWeb.Controllers
{
    [Authorize]
    public class PageHomeController : Controller
    {

        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
