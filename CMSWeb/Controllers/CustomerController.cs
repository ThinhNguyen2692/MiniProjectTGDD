using Microsoft.AspNetCore.Mvc;
using CMSWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BUS;
using DAL.Models;
using DAL;
using Newtonsoft.Json;


namespace CMSWeb.Controllers
{
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        public CustomerController(ILogger<CustomerController> logger)
        {
            _logger = logger;
        }

        IBusCustomer busCustomer = Bus_Customer.GetCustomer(Dal_Customer.GetCustomer());
        ListModel listModel = ListModel.GetList();

        public void GetListCustomer()
        {
            listModel.customers = busCustomer.GetCustomers();

        }

        [Route("ShowCustomer")]
        public IActionResult ShowCustomer()
        {
            GetListCustomer();
            return View(listModel);
        }

        [HttpGet]
        [Route("FormUpdateCustomer")]
        public IActionResult FormUpdateCustomer(string CustomerPhone)
        {
            listModel.customer = busCustomer.GetCustomerByphone(CustomerPhone);
            return View(listModel);
        }

        [HttpPost]
        [Route("UpdateCustomer")]
        public IActionResult UpdateCustomer(Customer customer)
        {
            listModel.customer = busCustomer.UpdateCustomer(customer);
            listModel.message = "updatecustomertrue";
            return View("FormUpdateCustomer", listModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
}
