using CMSWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ModelProject.Models;
using BUS;
using CMSWeb.ViewModels.GiftViewModels;

namespace CMSWeb.Controllers
{
    public class ProductPromotionController : Controller
    {
        private readonly ILogger<ProductPromotionController> _logger;
        private readonly IBus_Gift bus_Gift;
        public ProductPromotionController(ILogger<ProductPromotionController> logge, IBus_Gift bus_Gift)
        {
            this._logger = logge;
            this.bus_Gift = bus_Gift;
        }

        public IActionResult Index()
        {
            

          //  giftViewModel.giftProduct = bus_Gift.GetProductTypeGift();
            return View("ShowPromotion");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
