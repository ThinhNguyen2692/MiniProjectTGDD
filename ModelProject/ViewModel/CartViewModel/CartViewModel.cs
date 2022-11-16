using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelProject.Models;

namespace ModelProject.ViewModel
{
	public class CartViewModel
	{
	 public	CartViewModel() { }

		public ProductShow ProductShow { get; set; } = new ProductShow();

        public List<Promation> ProductPromation { get; set; } = new List<Promation>();
        public List<Promation> PricePromation { get; set; } = new List<Promation>();
        public QuantityProductVerSion quantityProductVerSion { get; set; } = new QuantityProductVerSion();

        public int status { get; set; } = 0;

        public Money money { get; set; } = new Money();
    }

    public class Money
    {
        public Money() { }
        public float TotalMoney { get; set; } = 0;
        public float PromationMoney { get; set; } = 0;
        public float IntoMoney { get; set; } = 0;
    }

    public class CartsViewModel
    {
      public  List<CartViewModel> cartViewModels { get; set; } = new List<CartViewModel>();
        public Money money { get; set; } = new Money();
    }


}
