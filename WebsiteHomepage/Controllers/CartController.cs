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
using ModelProject.VNPay;
using Microsoft.Extensions.Options;

namespace WebsiteHomepage.Controllers
{
   
	public class CartController : Controller
	{
		private readonly IBusCart busCart;
        private readonly IBusPurchaseOrder busPurchaseOrder;
        private readonly VNPaySettingModel vnpaySettingModel;
		public CartController(IBusCart busCart, IBusPurchaseOrder busPurchaseOrder, IOptions<VNPaySettingModel> vnpaySettingModel)
		{
			this.busCart = busCart;
            this.busPurchaseOrder = busPurchaseOrder;
            this.vnpaySettingModel = vnpaySettingModel.Value;
		}

        [HttpGet]
        [Route("gio-hang")]
        public IActionResult Index()
		{
            var json = Request.Cookies["cart"];
            var viewModel = busCart.GetCart(json);
            return View("Index",viewModel);
		}

        
        [Route("them-vao-gio-hang")]
        public IActionResult AddCart(CartModel cartModel)
		{
			var json = Request.Cookies["cart"];
            json = busCart.AddCart(json, cartModel);
			CookieOptions cookie = new CookieOptions();
            Response.Cookies.Append("cart",json,cookie);
            var viewModel = busCart.GetCart(json);
            return View("Index", viewModel);
        }

        [Route("cap-nhat-gio-hang")]
        public IActionResult UpdateCart(List<CartModel> CartModels)
		{
            string json = null;
            foreach (var item in CartModels)
			{
                json = busCart.AddCart(json, item);
            }
            CookieOptions cookie = new CookieOptions();
            cookie.HttpOnly = false;
            Response.Cookies.Append("cart", json, cookie);
            var viewModel = busCart.GetCart(json);
            return View("Index", viewModel);
        }

        [Route("xoa-gio-hang")]
        public IActionResult DeleteCartitem(int quantityColorId)
		{
            var json = Request.Cookies["cart"];
            json = busCart.DeleteCartitem(json, quantityColorId);
            CookieOptions cookie = new CookieOptions();
            cookie.HttpOnly = false;
            Response.Cookies.Append("cart", json, cookie);
            var viewModel = busCart.GetCart(json);
            return View("Index", viewModel);
        }

        [Route("CheckOut")]
        public IActionResult CheckOut()
        {
            var json = Request.Cookies["cart"];
            var viewModel = new Checkout();
            viewModel.cartsViewModel = busCart.GetCart(json);
            return View(viewModel);
        }

        [Route("thanh-toan")]
        public IActionResult Order(Customer customer)
        {
            var json = Request.Cookies["cart"];
            var oderID = busCart.Oder(customer, json);
            ViewData["oderID"] = oderID;
            var viewModel = new Checkout();
             viewModel.cartsViewModel = busCart.GetCart(json);
             XmlDocument xml = new XmlDocument();
            xml.Load("https://portal.vietcombank.com.vn/Usercontrols/TVPortal.TyGia/pXML.aspx?b=10");
            var element = xml.GetElementsByTagName("Exrate")[19].Attributes["Transfer"].Value;
            viewModel.usd = element.Replace(",", String.Empty);
            return View("Paypal" ,viewModel);
        }

        public IActionResult PayPal(string oderId)
        {
            busPurchaseOrder.DeliveringUpdateStatusOrder(oderId, 0);
            Response.Cookies.Delete("cart");
            return Redirect("/");
        }

        [Route("VNPayPayMent")]
        public void VNPayPayMent(Customer customer)
        {
            var json = Request.Cookies["cart"];
            var oderID = busCart.Oder(customer, json);
            var viewModel = new Checkout();
            viewModel.cartsViewModel = busCart.GetCart(json);

            VnPayLibrary vnpay = new VnPayLibrary();
			vnpay.AddRequestData("vnp_Version", vnpaySettingModel.vnp_Version);
            vnpay.AddRequestData("vnp_Command", vnpaySettingModel.vnp_Command);
            vnpay.AddRequestData("vnp_TmnCode", vnpaySettingModel.vnp_TmnCode);
            double into = (double)viewModel.cartsViewModel.money.IntoMoney;

			vnpay.AddRequestData("vnp_Amount", (into * 100).ToString()); //Số tiền thanh toán. Số tiền không mang các ký tự phân tách thập phân, phần nghìn, ký tự tiền tệ. Để gửi số tiền thanh toán là 100,000 VND (một trăm nghìn VNĐ) thì merchant cần nhân thêm 100 lần (khử phần thập phân), sau đó gửi sang VNPAY là: 10000000
            //if (bankcode_Vnpayqr.Checked == true)
            //{
            //    vnpay.AddRequestData("vnp_BankCode", "VNPAYQR");
            //}
            //else if (bankcode_Vnbank.Checked == true)
            //{
            //    vnpay.AddRequestData("vnp_BankCode", "VNBANK");
            //}
            //else if (bankcode_Intcard.Checked == true)
            //{
            //    vnpay.AddRequestData("vnp_BankCode", "INTCARD");
            //}
			vnpay.AddRequestData("vnp_CreateDate", DateTime.Now.ToString("yyyyMMddHHmmss"));
            vnpay.AddRequestData("vnp_CurrCode", "VND");
            vnpay.AddRequestData("vnp_IpAddr", Utils.GetIpAddress(Response));
           vnpay.AddRequestData("vnp_Locale", vnpaySettingModel.vnp_Locale);
            vnpay.AddRequestData("vnp_OrderInfo", "Thanh toan don hang:" + oderID.ToString());
            vnpay.AddRequestData("vnp_OrderType", "other"); //default value: other
            vnpay.AddRequestData("vnp_ReturnUrl", vnpaySettingModel.vnp_ReturnUrl);
            vnpay.AddRequestData("vnp_TxnRef", oderID.ToString()); // Mã tham chiếu của giao dịch tại hệ thống của merchant. Mã này là duy nhất dùng để phân biệt các đơn hàng gửi sang VNPAY. Không được trùng lặp trong ngày
            string paymentUrl = vnpay.CreateRequestUrl(vnpaySettingModel.vnp_Url, vnpaySettingModel.vnp_HashSecret);
           Response.Redirect(paymentUrl);
        }

        [HttpGet]
        [Route("CheckOut-success")]
        public IActionResult CheckOutSuccess(VNPayPaymetResponse vnpayPaymetResponse)
        {
            var temp = Request;
			VnPayLibrary vnpay = new VnPayLibrary();
			vnpay.AddResponseData(nameof(vnpayPaymetResponse.vnp_TmnCode).ToString(), vnpayPaymetResponse.vnp_TmnCode);
			vnpay.AddResponseData(nameof(vnpayPaymetResponse.vnp_Amount).ToString(), vnpayPaymetResponse.vnp_Amount);
			vnpay.AddResponseData(nameof(vnpayPaymetResponse.vnp_BankCode).ToString(), vnpayPaymetResponse.vnp_BankCode);
			vnpay.AddResponseData(nameof(vnpayPaymetResponse.vnp_BankTranNo).ToString(), vnpayPaymetResponse.vnp_BankTranNo);
			vnpay.AddResponseData(nameof(vnpayPaymetResponse.vnp_CardType).ToString(), vnpayPaymetResponse.vnp_CardType);
			vnpay.AddResponseData(nameof(vnpayPaymetResponse.vnp_PayDate).ToString(), vnpayPaymetResponse.vnp_PayDate);
			vnpay.AddResponseData(nameof(vnpayPaymetResponse.vnp_OrderInfo).ToString(), vnpayPaymetResponse.vnp_OrderInfo);
			vnpay.AddResponseData(nameof(vnpayPaymetResponse.vnp_TransactionNo).ToString(), vnpayPaymetResponse.vnp_TransactionNo);
			vnpay.AddResponseData(nameof(vnpayPaymetResponse.vnp_ResponseCode).ToString(), vnpayPaymetResponse.vnp_ResponseCode);
			vnpay.AddResponseData(nameof(vnpayPaymetResponse.vnp_TransactionStatus).ToString(), vnpayPaymetResponse.vnp_TransactionStatus);
			vnpay.AddResponseData(nameof(vnpayPaymetResponse.vnp_TxnRef).ToString(), vnpayPaymetResponse.vnp_TxnRef);
			vnpay.AddResponseData(nameof(vnpayPaymetResponse.vnp_SecureHashType).ToString(), vnpayPaymetResponse.vnp_SecureHashType);
			vnpay.AddResponseData(nameof(vnpayPaymetResponse.vnp_SecureHash).ToString(), vnpayPaymetResponse.vnp_SecureHash);
			bool checkSignature = vnpay.ValidateSignature(vnpayPaymetResponse.vnp_SecureHash, vnpaySettingModel.vnp_HashSecret);
            if (checkSignature)
            {
                if (vnpayPaymetResponse.vnp_TransactionStatus == "00")
                {
                    return Ok("thanh cong roi");
                }
                else
                {
                    return Ok("that bai roi");
                }
            }
            else { return Ok("that bai con me no roi");  }
        }

    }
}
	