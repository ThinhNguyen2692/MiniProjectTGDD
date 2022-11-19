using ModelProject.Models;
using ModelProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BUS.Services
{
	public interface IBusCart
	{
        public string AddCart(string? json, CartModel cartModel);
        public CartsViewModel GetCart(string? json);
        public string DeleteCartitem(string json, int quantyticolorId);
        public void Oder(Customer customer, string json);
    }
}
