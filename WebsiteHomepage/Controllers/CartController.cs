using Microsoft.AspNetCore.Mvc;
using BUS.Services;
using Microsoft.AspNetCore.Http;
using ModelProject.Models;
using ModelProject.ViewModel;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Net.Http.Headers;
using Microsoft.AspNetCore.Cors;
using System.Xml;
using System.Xml.Linq;

namespace WebsiteHomepage.Controllers
{
    [EnableCors("MyPolicy")]
	public class CartController : Controller
	{
		private readonly IBusCart busCart;

		public CartController(IBusCart busCart)
		{
			this.busCart = busCart;
		}

		public IActionResult Index()
		{
            var json = Request.Cookies["cart"];
            var viewModel = busCart.GetCart(json);
			return View("Index",viewModel);
		}

		public IActionResult AddCart(CartModel cartModel)
		{
			var json = Request.Cookies["cart"];
			json = busCart.AddCart(json, cartModel);
			CookieOptions cookie = new CookieOptions();
			cookie.HttpOnly = true;
			Response.Cookies.Append("cart",json,cookie);
            var viewModel = busCart.GetCart(json);
            return View("Index", viewModel);
        }

		public IActionResult UpdateCart(List<CartModel> CartModels)
		{
            string json = null;
            foreach (var item in CartModels)
			{
                json = busCart.AddCart(json, item);
            }
            CookieOptions cookie = new CookieOptions();
            cookie.HttpOnly = true;
            Response.Cookies.Append("cart", json, cookie);
            var viewModel = busCart.GetCart(json);
            return View("Index", viewModel);
        }

		public IActionResult DeleteCartitem(int quantityColorId)
		{
            var json = Request.Cookies["cart"];
            json = busCart.DeleteCartitem(json, quantityColorId);
            CookieOptions cookie = new CookieOptions();
            cookie.HttpOnly = true;
            Response.Cookies.Append("cart", json, cookie);
            var viewModel = busCart.GetCart(json);
            return View("Index", viewModel);
        }

        public IActionResult CheckOut()
        {
            var json = Request.Cookies["cart"];
            var viewModel = new Checkout();
            viewModel.cartsViewModel = busCart.GetCart(json);
            return View(viewModel);
        }

        public IActionResult Order(Customer customer)
        {
            var json = Request.Cookies["cart"];
            busCart.Oder(customer, json);
            var viewModel = new Checkout();
             viewModel.cartsViewModel = busCart.GetCart(json);
             XmlDocument xml = new XmlDocument();
            xml.Load("https://portal.vietcombank.com.vn/Usercontrols/TVPortal.TyGia/pXML.aspx?b=10");
            var element = xml.GetElementsByTagName("Exrate")[19].Attributes["Transfer"].Value;
            viewModel.usd = element.Replace(",", String.Empty);
            return View("Paypal" ,viewModel);
        }
    }
}
	