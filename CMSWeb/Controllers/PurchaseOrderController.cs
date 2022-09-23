using Microsoft.AspNetCore.Mvc;
using CMSWeb.Models;
using System.Diagnostics;
using BUS.Services;
using ModelProject.Models;
using Newtonsoft.Json;
using CMSWeb.Models.ProductBrands;
using ModelProject.ViewModel;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace CMSWeb.Controllers
{
    public class PurchaseOrderController : Controller
    {

        private readonly ILogger<PurchaseOrderController> _logger;
        private readonly IBusPurchaseOrder iBusPurchaseOrder;

        public PurchaseOrderController(ILogger<PurchaseOrderController> logger, IBusPurchaseOrder busPurchaseOrder)
        {
            _logger = logger;
            iBusPurchaseOrder = busPurchaseOrder;

        }

        /// <summary>
        /// danh sách hóa đơn
        /// </summary>
        /// <returns></returns>
        public IActionResult Index()
        {
            var viewModel = iBusPurchaseOrder.GetListPurchaseOrderViewModels();
            return View(viewModel);
        }


        /// <summary>
        /// Lấy thông tin chi tiết cho đơn hàng
        /// </summary>
        /// <param name="OrderId">mã đơn hàng</param>
        /// <returns></returns>
        [HttpPost]
        [Route("/PurchaseOrderDetail")]
        public string Details(string OrderId)
        {
            JsonSerializerOptions options = new()
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                WriteIndented = true
            };
            var data = iBusPurchaseOrder.GetPurchaseOrderById(OrderId);
            string tylerJson = System.Text.Json.JsonSerializer.Serialize(data, options);
            return tylerJson;
        }

        [HttpGet]
        [Route("/Delivering")]
        public IActionResult UpdateStatusOrder(string OrderId, int status)
        {
            var viewModel = iBusPurchaseOrder.DeliveringUpdateStatusOrder(OrderId, status);
            return View("Index", viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
