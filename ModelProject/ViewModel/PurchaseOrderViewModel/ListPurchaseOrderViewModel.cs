using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelProject.Models;

namespace ModelProject.ViewModel
{

    public class PurchaseOrderViewModel
    {
        public PurchaseOrderViewModel() { }

        public string PurchaseOrderId { get; set; }
        public string customer_phone { get; set; }
        public int toltalMoney { get; set; }
        public int toltalPromotionalPrice { get; set; }
        public int IntoMoney { get; set; }
        public int Status { get; set; }

    }

    public class ListPurchaseOrderViewModel
    {

        public ListPurchaseOrderViewModel() { }
       public  List<PurchaseOrderViewModel> ListProcessing { get; set; } = new List<PurchaseOrderViewModel>();
       public List<PurchaseOrderViewModel> ListDelivering { get; set; } = new List<PurchaseOrderViewModel>();
       public List<PurchaseOrderViewModel> ListDelivered { get; set; } = new List<PurchaseOrderViewModel>();
        public List<PurchaseOrderViewModel> ListCancelled { get; set; } = new List<PurchaseOrderViewModel>();



        public string GetStatus(int status) {

            switch (status)
            {
                case 0: return "Đang xử lý"; 
                case 1: return "Đang giao hàng"; 
                case 2: return "Giao thành công"; 
                case 3: return "Đã hủy";
                default: return "";
            }

        }
    }
}
