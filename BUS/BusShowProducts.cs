using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelProject.Models;
using ModelProject.ViewModel;
using DAL;
using BUS.Services;

namespace BUS
{
    public class BusShowProducts:IBusShowProducts
    {
        private IDalBrands dalBrands;
        private IDAlProduct dAlProduct;
        private IDaltype daltype;
        private IDalEvent dalEvent;
        private IDalProductVersion dalProductVersion;
        private IBusProduct busProduct;

        public BusShowProducts( IDalProductVersion dalProductVersion, IDalBrands dalBrands, IDaltype daltype, IDalEvent dalEvent, IBusProduct busProduct,IDAlProduct dAlProduct)
        {
            this.dalBrands = dalBrands;
            this.daltype = daltype;
            this.dalProductVersion = dalProductVersion;
            this.dalEvent = dalEvent;
            this.busProduct = busProduct;
            this.dAlProduct = dAlProduct;
        }


        public HeaderViewModel HeaderViewModel()
        {
            HeaderViewModel viewModel = new HeaderViewModel();
            //Lấy thông tin thương hiệu trạng thái đang kinh doanh
            var ListBrand = dalBrands.DalGetbrandsByStatus();
            foreach (var item in ListBrand)
            {
                ShowBrandsViewModel model = new ShowBrandsViewModel();
                model.BrandId = item.BrandId;
                model.BrandName = item.BrandName;
                model.BrandPhoto = item.BrandPhoto;
                model.BrandStatus = item.BrandStatus;
                viewModel.showBrandsViewModels.Add(model);
            }


            var listType = daltype.ReadTypes();
            foreach (var item in listType)
            {
                ListProductTypeViewModel model = new ListProductTypeViewModel();
                model.TypeId = item.Typeid;
                model.TypeName = item.Typename;
                viewModel.listProductTypeViewModels.Add(model);
            }

            return viewModel;

        }

        public HomeViewModel GetHomeProduct()
        {
            var data = dalEvent.GetEventDetails();
            var timeNow = DateTime.Now;
            data = data.Where(e => e.Event.EndTime >= timeNow).ToList();
            HomeViewModel viewModel = new HomeViewModel();
            foreach (var item in data)
            {
                foreach (var value in item.Product.ProductVersions)
                {
                    if (value.ProductStatus == 0)
                    {
                        continue;
                    }
                  
                    //Kiểm tra sản phẩm có tồn tại trong viewModel không ? cộng dồn khuyến mãi : thêm mới sản phẩm
                    int index = viewModel.ProductSale.FindIndex(p => p.VersionId == value.VersionId);
                    if (index != -1) { viewModel.ProductSale[index].ProductSale += item.Event.Promotion; continue; }
                    else
                    {
                        var model = new ProductShow();
                        model.ProductId = value.ProductId;
                        model.ProuctName = value.Product.ProuctName;
                        model.VersionName = value.VersionName;
                        model.VersionId = value.VersionId;
                        model.ProductType = item.Product.ProductType;
                        model.ProductBrand = item.Product.ProductBrand;
                        model.ProductPrice = value.ProductPrice;
                        model.ProductStatus = value.ProductStatus;
                        model.ProductDescription = item.Product.ProductDescription;
                        model.ProductPhoto = item.Product.ProductPhoto;
                        model.ProductSale = item.Event.Promotion;
                        viewModel.ProductSale.Add(model);
                    }
                

                }
            }
            var productbrnad = dalBrands.GetProductBrand("APPLE");
            if (productbrnad != null)
            {
                foreach (var item in productbrnad.Products)
                {
                    foreach (var value in item.ProductVersions)
                    {
                        var model = new ProductShow();
                        model.ProductId = value.ProductId;
                        model.ProuctName = value.VersionName;
                        model.VersionId = value.VersionId;
                        model.ProductType = item.ProductType;
                        model.ProductBrand = item.ProductBrand;
                        model.ProductPrice = value.ProductPrice;
                        model.ProductStatus = value.ProductStatus;
                        model.ProductDescription = item.ProductDescription;
                        model.ProductPhoto = item.ProductPhoto;
                        
                        viewModel.ProductApple.Add(model);
                    }
                }
              
            }
            var dataproduct = dalProductVersion.DalReadProductAll();
            if (dataproduct != null)
            {
                dataproduct = dataproduct.Where(p => p.Product.ProductType == "sac" || p.Product.ProductType == "tainghekhongday" || p.Product.ProductType == "tainghe" || p.Product.ProductType == "sacduphong").Where(p => p.ProductStatus != 0).ToList();
                foreach (var item in dataproduct)
                {
                    var model = new ProductShow();
                    model.ProductId = item.ProductId;
                    model.ProuctName = item.VersionName;
                    model.VersionId = item.VersionId;
                    model.ProductType = item.Product.ProductType;
                    model.ProductBrand = item.Product.ProductBrand;
                    model.ProductPrice = item.ProductPrice;
                    model.ProductStatus = item.ProductStatus;
                    model.ProductDescription = item.Product.ProductDescription;
                    model.ProductPhoto = item.Product.ProductPhoto;
                    viewModel.Products.Add(model);
                }
            }
            return viewModel;
        }



        /// <summary>
        /// Lấy chi tiết sản phẩm
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public ProductDetailViewModel GetProductDetail(string id)
        {
            var viewModel = busProduct.DalReadProductDetail(id);
            if (viewModel == null) return null;
            viewModel.PricePromation = viewModel.PricePromation.Where(x => x.Status != 0).ToList();
            viewModel.ProductPromation = viewModel.ProductPromation.Where(x => x.Status != 0).ToList();
            
            foreach (var item in viewModel.PricePromation)
            {
                viewModel.ProductShow.ProductSale += item.PromationPrice;
               
            }

           double sale = (double) viewModel.ProductShow.ProductSale / 100;
           sale = (double) viewModel.ProductShow.ProductPrice * sale;
           viewModel.ProductShow.ProductPriceSale = (int) sale;

            foreach (var item in viewModel.comments)
            {
               item.UserPhone = item.UserPhone.Substring(0,4);
                item.UserPhone = item.UserPhone+"xxxxx";
            }
            return viewModel;
        }

        public List<ProductShow> GetProductSuggestions(string id)
        {
            var viewModel = new List<ProductShow>();
            var productbrnad = dalBrands.GetProductBrand(id);
            
            if (productbrnad != null)
            {
                productbrnad.Products = productbrnad.Products.Take(10).ToList();
                foreach (var item in productbrnad.Products)
                {
                    foreach (var value in item.ProductVersions)
                    {
                        var model = new ProductShow();
                        model.ProductId = value.ProductId;
                        model.ProuctName = value.VersionName;
                        model.VersionId = value.VersionId;
                        model.ProductType = item.ProductType;
                        model.ProductBrand = item.ProductBrand;
                        model.ProductPrice = value.ProductPrice;
                        model.ProductStatus = value.ProductStatus;
                        model.ProductDescription = item.ProductDescription;
                        model.ProductPhoto = item.ProductPhoto;

                        viewModel.Add(model);
                    }
                }
               
            }
            return viewModel;
        }

        public List<ProductShow> GetListProduct(string id)
        {
            var viewModel = new List<ProductShow>();
            var data = dAlProduct.GetProducts();
            data = data.Where(p => p.ProductBrand == id || p.ProductType == id).ToList();

            foreach (var item in data)
            {
                foreach (var value in item.ProductVersions)
                {
                    var model = new ProductShow();
                    model.ProductId = value.ProductId;
                    model.ProuctName = value.VersionName;
                    model.VersionId = value.VersionId;
                    model.ProductType = item.ProductType;
                    model.ProductBrand = item.ProductBrand;
                    model.ProductPrice = value.ProductPrice;
                    model.ProductStatus = value.ProductStatus;
                    model.ProductDescription = item.ProductDescription;
                    model.ProductPhoto = item.ProductPhoto;
                    foreach (var item1 in item.EventDetails)
                    {
                        model.ProductSale += item1.Event.Promotion;
                    }
                    double sale = (double)model.ProductSale / 100;
                    sale = (double)model.ProductPrice * sale;
                    model.ProductPriceSale = (int)sale;
                    viewModel.Add(model);
                }
            }
            return viewModel;
        }

        public List<ProductShow> GetListProductSeach(string? Key, int filterPrice = 100000000, string filterBrand = "all", string filterType = "all")
        {
           
            var data = GetListProduct();
            data = data.Where(p => p.ProductPrice < filterPrice).ToList();
            if (Key != null)    
            {
                data = data.Where(p => p.ProuctName.Contains(Key)).ToList();
                
            }
            if (filterBrand != "all") data = data.Where(p => p.ProductBrand == filterBrand).ToList();
            if (filterType != "all") data = data.Where(p => p.ProductType == filterType).ToList();

            return data;

        }


        public List<ProductShow> GetListProduct()
        {
            var viewModel = new List<ProductShow>();
            var data = dAlProduct.GetProducts();
            foreach (var item in data)
            {
                foreach (var value in item.ProductVersions)
                {
                    var model = new ProductShow();
                    model.ProductId = value.ProductId;
                    model.ProuctName = value.VersionName;
                    model.VersionId = value.VersionId;
                    model.ProductType = item.ProductType;
                    model.ProductBrand = item.ProductBrand;
                    model.ProductPrice = value.ProductPrice;
                    model.ProductStatus = value.ProductStatus;
                    model.ProductDescription = item.ProductDescription;
                    model.ProductPhoto = item.ProductPhoto;
                    foreach (var item1 in item.EventDetails)
                    {
                        model.ProductSale += item1.Event.Promotion;
                    }
                    double sale = (double)model.ProductSale / 100;
                    sale = (double)model.ProductPrice * sale;
                    model.ProductPriceSale = (int)sale;
                    viewModel.Add(model);
                }
            }
            return viewModel;
        }

    }
}
