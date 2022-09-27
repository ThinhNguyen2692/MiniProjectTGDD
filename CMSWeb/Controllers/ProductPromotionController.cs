using CMSWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using ModelProject.ViewModel;
using BUS.Services;

namespace CMSWeb.Controllers
{
    public class ProductPromotionController : Controller
    {
        private readonly ILogger<ProductPromotionController> _logger;
        private readonly IBusPromotion iBusPromotion;
        public ProductPromotionController(ILogger<ProductPromotionController> logge, IBusPromotion iBusPromotion)
        {
            this._logger = logge;
            this.iBusPromotion = iBusPromotion;
        }

        public IActionResult Index()
        {
            var viewModel = iBusPromotion.GetProductPromotionViewModel();
            return View("ShowPromotion",viewModel);
        }

        public IActionResult PriceSale()
        {
            var viewModel = iBusPromotion.GetPricePromotionViewModel();
            return View(viewModel);
        }

        [HttpPost]
        [Route("AddPromation")]
        public IActionResult AddPromation(ProductPromotionViewModel viewModel)
        {
             viewModel = iBusPromotion.AddGift(viewModel);
            return View("ShowPromotion", viewModel);
        }

        [HttpPost]
        [Route("AddPriceSale")]
        public IActionResult AddPriceSale(PricePromotionViewModel viewModel)
        {
            viewModel = iBusPromotion.AddEvent(viewModel);
            return View("PriceSale", viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
