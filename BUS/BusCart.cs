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

namespace BUS
{
	public class BusCart:IBusCart
	{
        private IDalBrands dalBrands;
        private IDAlProduct dAlProduct;
        private IDaltype daltype;
        private IDalEvent dalEvent;
        private IDalProductVersion dalProductVersion;
        private IBusProduct busProduct;
        private IBusShowProducts busShowProducts;

        public BusCart(IDalProductVersion dalProductVersion, IDalBrands dalBrands, IDaltype daltype, IDalEvent dalEvent, IBusProduct busProduct, IDAlProduct dAlProduct, IBusShowProducts busShowProducts)
        {
            this.dalBrands = dalBrands;
            this.daltype = daltype;
            this.dalProductVersion = dalProductVersion;
            this.dalEvent = dalEvent;
            this.busProduct = busProduct;
            this.dAlProduct = dAlProduct;
            this.busShowProducts = busShowProducts;
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
    }
}
