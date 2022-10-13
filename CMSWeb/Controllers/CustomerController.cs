using Microsoft.AspNetCore.Mvc;
using CMSWeb.Models;
using System.Diagnostics;
using BUS;
using ModelProject.Models;
using CMSWeb.ViewModels.CustomerViewModel;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Authorization;
using X.PagedList;
namespace CMSWeb.Controllers
{
    [Authorize(Roles = "2,5")]
    public class CustomerController : Controller
    {
        private readonly ILogger<CustomerController> _logger;
        private readonly IBusCustomer busCustomer;
        public CustomerController(ILogger<CustomerController> logger, IBusCustomer busCustomer)
        {
            _logger = logger;
            this.busCustomer = busCustomer;
        }

       
        ListModel listModel = ListModel.GetList();

        public void GetListCustomer()
        {
            listModel.customers = busCustomer.GetCustomers();

        }

        [Route("ShowCustomer")]
        public IActionResult ShowCustomer(int page = 1)
        {
            var customers = busCustomer.GetCustomers().ToPagedList(page, 10);

            return View(customers);
        }

        [HttpGet]
        [Route("FormUpdateCustomer")]
        public IActionResult FormUpdateCustomer(string CustomerPhone)
        {
            var Customer = new CustomerDetailViewModel();
            Customer.createCustomer = busCustomer.GetCustomerByphone(CustomerPhone);
            return View(Customer);
        }

        [HttpPost]
        [Route("UpdateCustomer")]
        public IActionResult UpdateCustomer(CustomerDetailViewModel Customer)
        {
            Customer.createCustomer = busCustomer.UpdateCustomer(Customer.createCustomer);
            Customer.message = true;
            return View("FormUpdateCustomer", Customer);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
            public IActionResult Error()
            {
                return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
            }
        }
}
