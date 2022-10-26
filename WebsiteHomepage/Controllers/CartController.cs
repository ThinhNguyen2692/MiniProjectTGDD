using Microsoft.AspNetCore.Mvc;

namespace WebsiteHomepage.Controllers
{
	public class CartController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
