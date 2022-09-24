using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS.Services;
using DAL;
using ModelProject.ViewModel;
using ModelProject.Models;

namespace BUS
{
    public class BusPurchaseOrder:IBusPurchaseOrder
    {
        private IDalPurchaseOrder iDalPurchaseOrder;
        private IDalVersionQuantity iDalVersionQuantity;

        public BusPurchaseOrder(IDalPurchaseOrder iDalPurchaseOrder, IDalVersionQuantity iDalVersionQuantity)
        {
            this.iDalPurchaseOrder = iDalPurchaseOrder;
            this.iDalVersionQuantity = iDalVersionQuantity;
        }

        public ListPurchaseOrderViewModel GetListPurchaseOrderViewModels()
        {
            var data = iDalPurchaseOrder.GetPurchaseOrderAll();
            ListPurchaseOrderViewModel viewModel = new ListPurchaseOrderViewModel();
            foreach (var item in data)
            {
                var model = new PurchaseOrderViewModel();
                model.customer_phone = item.CustomerPhone;
                model.PurchaseOrderId = item.OrderId;
                model.toltalPromotionalPrice = item.TotalPromotionalPrice;
                model.toltalMoney = item.TotalMoney;
                model.IntoMoney = item.IntoMoney;
                model.Status = (int) item.OrderStatus;
                switch (model.Status)
                {
                    case 0: viewModel.ListProcessing.Add(model); break;
                    case 1: viewModel.ListDelivering.Add(model); break;
                    case 2: viewModel.ListDelivered.Add(model); break;
                    case 3: viewModel.ListCancelled.Add(model); break;
                }

            }
            return viewModel;
        }

        /// <summary>
        /// lấy thông tin chi tiết của hóa đơn
        /// </summary>
        /// <param name="OrderId">mã hóa đơn</param>
        /// <returns>PurchaseOrder</returns>
        public PurchaseOrder GetPurchaseOrderById(string OrderId)
        {
            return iDalPurchaseOrder.GetPurchaseOrderById(OrderId);
        }

        /// <summary>
        /// cập nhật trạng thái thành giao hàng
        /// </summary>
        public ListPurchaseOrderViewModel DeliveringUpdateStatusOrder(string OrderId, int status)
        {
            //cập nhật trạng thái
            iDalPurchaseOrder.Update(OrderId, status);
            switch (status)
            {
                case 3: var item = iDalPurchaseOrder.GetPurchaseOrderById(OrderId);
                  
                    foreach (var value in item.PurchaseOrderDetails)
                    {
                        VersionQuantity versionQuantity = new VersionQuantity();
                        //OrderProduct (mã sản phẩm khuyến mãi)
                        versionQuantity.VersionId = value.OrderProduct;
                        //mã màu (EventName)
                        versionQuantity.ColorId = value.EventName;
                        versionQuantity.Quantity = value.OrderQuantity;
                        iDalVersionQuantity.UpdateOrderCanned(versionQuantity);
                    }
                    break;
                default:
                    break;
            }
           
            return GetListPurchaseOrderViewModels();
        }
    }
}
