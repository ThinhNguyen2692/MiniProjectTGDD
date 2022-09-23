using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelProject.Models;
using ModelProject.ViewModel;

namespace BUS.Services
{
    public interface IBusPurchaseOrder
    {
        public ListPurchaseOrderViewModel GetListPurchaseOrderViewModels();
        public PurchaseOrder GetPurchaseOrderById(string OrderId);
        public ListPurchaseOrderViewModel DeliveringUpdateStatusOrder(string OrderId, int status);
    }
}
