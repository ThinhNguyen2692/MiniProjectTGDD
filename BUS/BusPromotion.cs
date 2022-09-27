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
    public class BusPromotion : IBusPromotion
    {
        private IDalProductVersion dalProductVersion;
        private IDal_Gift iDalGift;
        private IDAlProduct iDAlProduct;
        private IDalEvent iDalEvent;

        public BusPromotion(IDalProductVersion dalProductVersion, IDal_Gift iDalGift, IDAlProduct iDAlProduct, IDalEvent dalEvent)
        {
            this.dalProductVersion = dalProductVersion;
            this.iDalGift = iDalGift;
            this.iDAlProduct = iDAlProduct;
            iDalEvent = dalEvent;
        }

        public ProductPromotionViewModel GetProductPromotionViewModel()
        {
            var data = dalProductVersion.DalReadProductAll();
            var GetPromotion = data.Where(g => g.ProductPrice < 500000).Where(g => g.ProductStatus != 0).ToList();

            var viewModel = new ProductPromotionViewModel();
            foreach (var item in GetPromotion)
            {
                
                ItemProductPromotion itemProductPromotion = new ItemProductPromotion();
                itemProductPromotion.productId = item.VersionId;
                itemProductPromotion.productName = item.VersionName;
                itemProductPromotion.Price = (int)item.ProductPrice;
                itemProductPromotion.productPhoto = item.Product.ProductPhoto;
                viewModel.listProductPromotions.Add(itemProductPromotion);
            }

            return viewModel;
        }


        public ProductPromotionViewModel AddGift(ProductPromotionViewModel viewModel)
        {
            if (iDAlProduct.CheckProduct(viewModel.ProductId) == false)
            {
                viewModel.Message = "ProductIdFalse";
                return viewModel;
            }
            foreach (var item in viewModel.listProductPromotions)
            {
                if (item.select == true)
                {
                    Gift gift = new Gift();
                    gift.ProductId = viewModel.ProductId;
                    gift.GiftProduct = item.productId;
                    iDalGift.AddGift(gift);
                }
            }
            viewModel.Message = "AddTrue";
            return viewModel;
        }

        public PricePromotionViewModel GetPricePromotionViewModel()
        {
            var data = dalProductVersion.DalReadProductAll();
            var GetPromotion = data.Where(g => g.ProductStatus != 0).ToList();
            var viewModel = new PricePromotionViewModel();
            foreach (var item in GetPromotion)
            {
                ItemProductPromotion itemProductPromotion = new ItemProductPromotion();
                itemProductPromotion.productId = item.ProductId;
                itemProductPromotion.productName = item.VersionName;
                itemProductPromotion.Price = (int)item.ProductPrice;
                itemProductPromotion.productPhoto = item.Product.ProductPhoto;
                viewModel.listProductPromotions.Add(itemProductPromotion);
            }
            return viewModel;
        }

        public PricePromotionViewModel AddEvent(PricePromotionViewModel viewModel)
        {
            var eventItem = new Event();
            eventItem.EventName = viewModel.eventName;
            eventItem.Promotion = viewModel.sale;
            foreach (var item in viewModel.listProductPromotions)
            {
                if (item.select == true)
                {
                    var index = eventItem.EventDetails.FirstOrDefault(p => p.ProductId == item.productId);
                    if(index == null)
                    {
                        EventDetail eventDetail = new EventDetail();
                        eventDetail.ProductId = item.productId;
                        eventItem.EventDetails.Add(eventDetail);
                    }
                    
                }
            }
            if(iDalEvent.AddEvent(eventItem) == true)
            {
                viewModel.Message = "AddTrue";
            }
            else
            {
                viewModel.Message = "AddFalse";
            }
            return viewModel;
        }
    }
    
}
