using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using BUS.Services;
using DAL;
using ModelProject.ViewModel;
using ModelProject.Models;
using Microsoft.Extensions.Options;
using System.Xml;

namespace BUS
{
	public class BusCart:IBusCart
	{
        private IDalBrands dalBrands;
        private IDalVersionQuantity dalVersionQuantity;
        private IDalPurchaseOrder dalPurchaseOrder;
        private IDAlProduct dAlProduct;
        private IDaltype daltype;
        private IDalEvent dalEvent;
        private IDalCustomer dalCustomer;
        private IDalProductVersion dalProductVersion;
        private IBusProduct busProduct;
        private IBusShowProducts busShowProducts;

        public BusCart(IDalProductVersion dalProductVersion, IDalBrands dalBrands, IDaltype daltype, IDalEvent dalEvent, IBusProduct busProduct, IDAlProduct dAlProduct, IBusShowProducts busShowProducts, IDalCustomer dalCustomer, IDalPurchaseOrder dalPurchaseOrder, IDalVersionQuantity dalVersionQuantity)
        {
            this.dalBrands = dalBrands;
            this.daltype = daltype;
            this.dalProductVersion = dalProductVersion;
            this.dalEvent = dalEvent;
            this.busProduct = busProduct;
            this.dAlProduct = dAlProduct;
            this.busShowProducts = busShowProducts;
            this.dalCustomer = dalCustomer;
            this.dalPurchaseOrder = dalPurchaseOrder;
            this.dalVersionQuantity = dalVersionQuantity;
        }

        public string AddCart(string? json, CartModel cartModel)
        {
            var listCartModel = new List<CartModel>();
            if(json != null)
            {
                var options = new JsonSerializerOptions
                {
                    IncludeFields = true,
                };
                listCartModel = JsonSerializer.Deserialize<List<CartModel>>(json, options)!;
            }
            if(listCartModel.Where(x => x.QuantityColorId == cartModel.QuantityColorId).ToList().Count != 0) listCartModel.Where(x => x.QuantityColorId == cartModel.QuantityColorId).First().Quantity++;
            else listCartModel.Add(cartModel);
            json = JsonSerializer.Serialize(listCartModel);
            return json;
        }


        public CartsViewModel GetCart(string? json)
        {
            CartsViewModel carts = new CartsViewModel();
            if (json == null) return carts;
            var options = new JsonSerializerOptions
            {
                IncludeFields = true,
            };
            var listCartModel = JsonSerializer.Deserialize<List<CartModel>>(json, options)!;
            foreach (var item in listCartModel)
            {
                var product = busProduct.DalReadProductDetail(item.ProductId);
                if (product == null) { listCartModel.Remove(item);  continue; }
                product.PricePromation = product.PricePromation.Where(x => x.Status != 0).ToList();
                product.ProductPromation = product.ProductPromation.Where(x => x.Status != 0).ToList();
                var cart = new CartViewModel();
                cart.ProductShow = product.ProductShow;
                cart.PricePromation = product.PricePromation;
                cart.ProductPromation = product.ProductPromation;
                cart.quantityProductVerSion = product.quantityProductVerSions.Where(x => x.idQuantity == item.QuantityColorId).First();
                if (cart.quantityProductVerSion.Quantity < item.Quantity) cart.status = 1;
                cart.quantityProductVerSion.Quantity = item.Quantity;
                cart.money.TotalMoney = (float)cart.ProductShow.ProductPrice * cart.quantityProductVerSion.Quantity;

                foreach (var item1 in cart.PricePromation)
                {
                    cart.ProductShow.ProductSale += item1.PromationPrice;

                }

                double sale = (double)cart.ProductShow.ProductSale / 100;
                sale = (double)cart.ProductShow.ProductPrice * sale;
                cart.ProductShow.ProductPriceSale = (int)sale;
                cart.money.PromationMoney = (float)cart.ProductShow.ProductPriceSale * cart.quantityProductVerSion.Quantity;
                cart.money.IntoMoney = cart.money.TotalMoney - cart.money.PromationMoney;
                if(cart.status == 0)
                {
                    carts.money.TotalMoney += cart.money.TotalMoney;
                    carts.money.PromationMoney += cart.money.PromationMoney;
                    carts.money.IntoMoney += cart.money.IntoMoney;
                }
                

                carts.cartViewModels.Add(cart);
            }
            return carts;
        }

        public string DeleteCartitem(string json, int quantyticolorId)
        {
            var options = new JsonSerializerOptions
            {
                IncludeFields = true,
            };
           var listCartModel = new List<CartModel>();
            listCartModel = JsonSerializer.Deserialize<List<CartModel>>(json, options)!;
            CartModel item = new CartModel();
            try
            {
                item = listCartModel.Where(x => x.QuantityColorId == quantyticolorId).First();
            }
            catch (Exception)
            {
                return json;
                throw;
            }
            if (item == null) return json;
            listCartModel.Remove(item);
            json = JsonSerializer.Serialize(listCartModel);
            return json;
        }


        public void Oder(Customer customer, string json)
        {
            var ViewModel = GetCart(json);
            var Oder = new PurchaseOrder();
            Oder.OrderId = RandomString(10);
            Oder.OrderStatus = 4;
            Oder.CustomerPhone = customer.CustomerPhone;
            Oder.CustomerAddress = customer.CustomerAddress;
            Oder.CommuneWard = customer.CommuneWard;
            Oder.ProvinceCity = customer.ProvinceCity;
            Oder.District = customer.District;
            Oder.SetupTime = DateTime.Now;
            Oder.BillingInformation = "paypal";
            Oder.TotalMoney = (int)ViewModel.money.TotalMoney;
            Oder.IntoMoney = (int)ViewModel.money.IntoMoney;
            Oder.TotalPromotionalPrice = (int)ViewModel.money.PromationMoney;
            foreach (var item in ViewModel.cartViewModels)
            {
                var oderDetailItem = new PurchaseOrderDetail();
                oderDetailItem.OrderId = Oder.OrderId;
                oderDetailItem.OrderProduct = item.ProductShow.VersionId;
                oderDetailItem.OrderProudctName = item.ProductShow.VersionName;
                oderDetailItem.OrderProductPhoto = item.ProductShow.ProductPhoto;
                oderDetailItem.OrderPrice = (int)item.ProductShow.ProductPrice;
                oderDetailItem.OrderPromotion = (int)item.ProductShow.ProductSale;
                oderDetailItem.ColorId = item.quantityProductVerSion.idQuantity;
                oderDetailItem.OrderQuantity = item.quantityProductVerSion.Quantity;
                oderDetailItem.Total = (int)item.money.TotalMoney;
                oderDetailItem.MoneyProduct = (int)item.money.IntoMoney;

                oderDetailItem.MoneyReduced = (int)item.money.PromationMoney;
                dalVersionQuantity.UpdateOrder(item.quantityProductVerSion.idQuantity, item.quantityProductVerSion.Quantity);
                //danh sản phẩm tặng
                foreach (var value in item.ProductPromation)
                {
                    var gift = new GiftDetail();
                    gift.GiftProduct = value.productVersionId;
                    gift.ProuctName = value.PromationName;
                    gift.ProductPrice = value.PromationPrice;
                    gift.ProductPhoto = value.ProductImage;
                    gift.GiftQuantiy = 1;
                    oderDetailItem.GiftDetails.Add(gift);
                }
                Oder.PurchaseOrderDetails.Add(oderDetailItem);

            }

            var customerData = dalCustomer.GetCustomerByphone(customer.CustomerPhone);
            if(customerData == null)
            {
                customer.PurchaseOrders.Add(Oder);
                dalCustomer.AddCustomer(customer);
            }
            else
            {
                dalPurchaseOrder.Add(Oder);
            }
        }


    

        public string RandomString(int length)
        {
            Random random = new Random();
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
        public List<CartModel> GetCartsJson(string? json)
        {
            var options = new JsonSerializerOptions
            {
                IncludeFields = true,
            };
         
            var viewModel = JsonSerializer.Deserialize<List<CartModel>>(json, options)!;
            return viewModel;
        }
    }
}
