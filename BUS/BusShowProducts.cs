using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelProject.Models;
using ModelProject.ViewModel;
using DAL;
using BUS.Services;
using static ModelProject.ViewModel.ProductDetailViewModel;

namespace BUS
{
    public class BusShowProducts:IBusShowProducts
    {
        private IDalBrands dalBrands;
        private IDaltype daltype;
        private IDalEvent dalEvent;
        private IDalProductVersion dalProductVersion;

       public BusShowProducts( IDalProductVersion dalProductVersion, IDalBrands dalBrands, IDaltype daltype, IDalEvent dalEvent)
        {
            this.dalBrands = dalBrands;
            this.daltype = daltype;
            this.dalProductVersion = dalProductVersion;
            this.dalEvent = dalEvent;
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
            HomeViewModel viewModel = new HomeViewModel();
            foreach (var item in data)
            {
                foreach (var value in item.Product.ProductVersions)
                {
                    if (value.ProductStatus != 0)
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
                    else continue;
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

    }
}
