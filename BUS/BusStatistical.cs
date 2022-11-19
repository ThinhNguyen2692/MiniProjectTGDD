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
    public class BusStatistical : IBusStatistical
    {
        private IDalPurchaseOrder dalPurchaseOrder;

        public BusStatistical(IDalPurchaseOrder dalPurchaseOrder) { this.dalPurchaseOrder = dalPurchaseOrder; }

        public StatisticalViewModel GetStatisticalViewModel()
        {
            var data = dalPurchaseOrder.GetPurchaseOrdersMonthProduct();
            var viewModel = new StatisticalViewModel();
            List<PurchaseOrderDetail> listPurchaseOrderDetail = new List<PurchaseOrderDetail>();

            foreach (var item in data)
            {
                if (item.OrderStatus == 2)
                {
                    foreach (var value2 in item.PurchaseOrderDetails)
                    {
                        //lấy danh sách sản phẩm đã bán
                        var index = viewModel.ProductStatistical.FindIndex(p => p.ProductId == value2.OrderProduct);
                        if (index != -1)
                        {
                            viewModel.ProductStatistical[index].ProductQuantity += value2.OrderQuantity;
                            viewModel.ProductStatistical[index].Price += value2.OrderPrice;
                        }
                        else
                        {
                            ProductStatistical productStatistical = new ProductStatistical();
                            productStatistical.ProductId = value2.OrderProduct;
                            productStatistical.ProductName = value2.OrderProudctName;
                            productStatistical.ProductQuantity = value2.OrderQuantity;
                            productStatistical.Price = value2.OrderPrice;
                            viewModel.ProductStatistical.Add(productStatistical);
                        }

                    }

                }

                switch (item.OrderStatus)
                {
                    case 0:
                    case 4:
                        viewModel.purChaseOderStatisticalsProcessing.PurChaseOderQuantity++;
                        viewModel.purChaseOderStatisticalsProcessing.PurChaseOderprice += item.TotalMoney;
                        break;
                    case 1:
                        viewModel.purChaseOderStatisticalsDelivering.PurChaseOderQuantity++;
                        viewModel.purChaseOderStatisticalsDelivering.PurChaseOderprice += item.TotalMoney;
                        break;
                    case 2:
                        viewModel.purChaseOderStatisticalsDelivered.PurChaseOderQuantity++;
                        viewModel.purChaseOderStatisticalsDelivered.PurChaseOderprice += item.TotalMoney;
                        break;
                    case 3:
                        viewModel.purChaseOderStatisticalsCancelled.PurChaseOderQuantity++;
                        viewModel.purChaseOderStatisticalsCancelled.PurChaseOderprice += item.TotalMoney;
                        break;
                    default:
                        break;
                }

            }
            return viewModel;
        }
    }
}
