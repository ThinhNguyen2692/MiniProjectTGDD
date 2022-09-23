using ModelProject.Models;

namespace CMSWeb.ViewModels.CustomerViewModel
{
    public class CustomerDetailViewModel
    {
        public Customer createCustomer { get; set; }

        public bool message { get; set; }

        public CustomerDetailViewModel() { }
    }
}
