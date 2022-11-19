using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelProject.Models;

namespace ModelProject.ViewModel
{
    public class Checkout
    {
        public Checkout() { }

        public CartsViewModel cartsViewModel { get; set; } = new CartsViewModel();
        public Customer Customer { get; set; } = new Customer();
        public string? usd { get; set; } = "0";
        public string email { get; set; } = "";
    }
}
