using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelProject.ViewModel
{
    public class GiftProduct
    {
        public GiftProduct() { }

        public string ProductName { get; set; }
        public int ProductPrice { get; set; }
        public string ProductPhoto { get; set; }
        public int Quantity { get; set; }
    }
   
    public class PurchaseOrderDetailViewModel
    {
        public PurchaseOrderDetailViewModel() { }

        public string OrderId { get; set; }
        public string CustomerPhone { get; set; }
    }
}
