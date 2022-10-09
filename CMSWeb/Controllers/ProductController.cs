﻿using CMSWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BUS;
using BUS.Services;
using ModelProject.Models;
using Newtonsoft.Json;
using ModelProject.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace CMSWeb.Controllers
{
    [Authorize]
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;

        private readonly IBusProduct IBusProduct;
        private readonly IBusPhoto iBusPhoto;
        private readonly IBusProductType iBusProductType;
        public ProductController(ILogger<ProductController> logger, IBusProduct IBusProduct, IBusProductType iBusProductType, IBusPhoto iBusPhoto)
        {
            _logger = logger;
            this.IBusProduct = IBusProduct;
            this.iBusProductType = iBusProductType;
            this.iBusPhoto = iBusPhoto;
        }
        /// <summary>
        /// load form nhập sản phẩm mới
        /// </summary>
        /// <returns></returns>
        public IActionResult FormAddProduct()
        {
            var addProductViewModel = new AddProductViewModel();
            addProductViewModel.ListBrands = addProductViewModel.GetViewModelBrands(IBusProduct.DalGetbrandsByStatus());
            addProductViewModel.ListTypes = addProductViewModel.GetViewModelTypes(IBusProduct.ReadAll());
            return View("form/FormAddProduct", addProductViewModel);
        }

        /// <summary>
        /// Load danh sách sản phẩm 
        /// </summary>
        /// <returns>trả về danh sách tất cả sản phẩm (chỉ lấy dữ liệu cần)</returns>
        public IActionResult ShowProduct()
        {
            
            var listProductVersions = IBusProduct.DalReadProductAll();

            return View(listProductVersions);
        }


        /// <summary>
        /// load form thêm hình cho sản phẩm
        /// </summary>
        /// <param name="ProductIdVersion">mã phiên bản sản phẩm</param>
        /// <param name="ProductNameVersion">tên phiên bản sản phẩm</param>
        /// <returns></returns>



        [HttpGet]
        public IActionResult FormAddPhoto(string ProductIdVersion, string ProductNameVersion)
        {
            var viewModel = IBusProduct.GetPhotoViewModel();
            ProductPhotoViewModel productPhotoViewModel = new ProductPhotoViewModel();
            productPhotoViewModel.photoViewModel = viewModel;
            productPhotoViewModel.ProductVerSionName = ProductNameVersion;
            productPhotoViewModel.ProductVersionId = ProductIdVersion;
            return View("form/AddPhotoProduct", viewModel);
        }

        /// <summary>
        /// Thêm hình cho sản phẩm
        /// </summary>
        /// <param name="ListImage">danh sách file hình cần thêm</param>
        /// <returns></returns>
        [HttpPost]
        public IActionResult AddPhoto(PhotoViewModel viewModel)
        {
            
            IBusProduct.AddImageProduct(viewModel);
             viewModel = IBusProduct.GetPhotoViewModel();
            return View("form/FormAddPhoto", viewModel);
        }


        /// <summary>
        /// lưu ảnh vào folder
        /// </summary>
        /// <param name="fileImage">file hình cần thêm vào</param>
        

        /// <summary>
        /// Thêm product
        /// </summary>
        /// <param name="product">Models sản phẩm cần thêm</param>
        /// <param name="fileImage">file hình của sản phẩm </param>
        /// <returns>load form thêm màu cho sản phẩm nếu thêm hình thành công</returns>
        [HttpPost]
        [Route("AddProduct")]
        public IActionResult AddProduct(AddProductViewModel addProductViewModel)
        {
           var productViewModel = IBusProduct.AddProduct(addProductViewModel);
            if(productViewModel != null)
            {
                addProductViewModel.ListBrands = addProductViewModel.GetViewModelBrands(IBusProduct.DalGetbrandsByStatus());
                addProductViewModel.ListTypes = addProductViewModel.GetViewModelTypes(IBusProduct.ReadAll());

                addProductViewModel.messageAdd = "AddProductFalse";
                return View("form/FormAddProduct", addProductViewModel);
            }
            
            var viewModelColor = new AddColorProduct();
            viewModelColor.ProductId = addProductViewModel.ProductId;
            return View("form/FormAddColor", viewModelColor);
        }


        //[HttpPost]
        //[Route("CheckProductId")]
        //public bool CheckProductId(string ProductId)
        //{
        //    return bus_Product.CheckProduct(ProductId);
        //}

        /// <summary>
        /// Thêm màu cho sản phẩm
        /// </summary>
        /// <param name="productColor">Model dữ liệu màu</param>
        /// <param name="fileImage">file hình màu sản phẩm</param>
        /// <returns>next form thêm phiên bản sản phẩm</returns>
        [HttpPost]
        [Route("AddProductColor")]
        public IActionResult AddProductColor(AddColorProduct addColorProduct)
        {
           
            if (IBusProduct.AddProductColor(addColorProduct) == true)
            {
               
                addColorProduct.messageAdd = "AddcolorTrue";
            }else addColorProduct.messageAdd = "AddcolorFalse";
            return View("form/FormAddColor", addColorProduct);
        }


        /// <summary>
        /// hiện form nhập thông tin sản phẩm version  chuyển qua tử form nhập thông tin màu
        /// </summary>
        /// <param name="productId">mã sản phẩm</param>
        /// <returns></returns>
        [HttpGet]
        [Route("FormAddProductVersion")]
        /// <summary>
        /// Load form nhập thông tin phiên bản sản phẩm
        /// </summary>
        /// <param name="productId">Mã sản phẩm của phiên bản</param>
        /// <returns></returns>
        public IActionResult FormAddProductVersion(string productId)
        {
            var productVersionViewModeal = IBusProduct.BusReadProduct(productId);
            //Lấy thuộc tính ngành hàng cho sản phẩm
            return View("form/FormAddProductVersion", productVersionViewModeal);
        }

       
        ///// <summary>
        ///// ajax thêm sản phâm version
        ///// </summary>
        ///// <param name="productVersion">Model dữ liệu phiên bản sản phẩm cần thêm</param>
        ///// <returns></returns>

        [HttpPost]
        [Route("AddVersionProduct")]
        public IActionResult AddVerSionProduct(ProductVersionViewModel productVersionViewModeal)
        {
            productVersionViewModeal = IBusProduct.AddProductVersion(productVersionViewModeal);
            return View("form/FormAddProductVersion", productVersionViewModeal);
        }


        /// <summary>
        /// hiện thông tin chi tiết sản phẩm theo phiên bản sản phẩm
        /// </summary>
        /// <param name = "id" > mã phiên bản sản phẩm</param>
        /// <returns>thông tin sản phẩm</returns>
        /// <returns>thông tin phiên bản sản phẩm</returns>
        /// <returns>thông tin thông số kỹ thuật sản phẩm</returns>
        /// <returns>thông tin số lượng sản phẩm (có màu)</returns>
        [HttpGet]
        [Route("ShowDetailProduct")]
        public IActionResult ShowDetailProduct(string id)
        {
            var ProductDetailViewModel = IBusProduct.DalReadProductDetail(id);
            return View(ProductDetailViewModel);
        }

        [HttpGet]
        [Route("DeleteProductVerSion")]
        public IActionResult DeleteProduct(string versionId, string productId)
        {
            if( IBusProduct.CheckProductVersion(versionId) == false || IBusProduct.CheckProduct(productId) == false)
            {
                    return View("ShowProduct", IBusProduct.DalReadProductAll());
            }

           if(IBusProduct.DelProductVerion(versionId, productId) == false)
            {
                var ProductDetailViewModel = IBusProduct.DalReadProductDetail(versionId);
                return View("ShowDetailProduct", ProductDetailViewModel);
            }
            var listProductVersions = IBusProduct.DalReadProductAll();

            return View("ShowProduct", listProductVersions);

        }


        ///// <summary>
        ///// Xóa hình khỏi thư mục
        ///// </summary>
        ///// <param name="paths">dahh sách đường dẫn</param>
        //public void deleteListPhoto(List<string> paths)
        //{
        //    foreach (var item in paths)
        //    {
        //        System.IO.File.Delete("wwwroot\\images\\" + item);
        //    }
        //}



        /// <summary>
        /// Hàm Cập nhật thông tin chi tiết sản phẩm
        /// </summary>
        /// <param name="productDetailViewModel">chưa thông tin chi tiết sản phẩm</param>
        /// <returns>productDetailViewModel: chứa các thông tin chi sản phẩm vừa cập nhật</returns>
        [HttpPost]
        [Route("UpdateProduct")]
        public IActionResult UpdateProduct(ProductDetailViewModel productDetailViewModel)
        {


            var ProductDetailViewModelNew = IBusProduct.DalReadProductDetail(productDetailViewModel.VersionId);
            productDetailViewModel.MessageUpdate = IBusProduct.UpdateProduct(productDetailViewModel);
            return View("ShowDetailProduct", ProductDetailViewModelNew);
        }

        [HttpGet]
        [Route("FormAddPhoto")]
        public IActionResult FormAddPhoto(string ProductIdVersion)
        {
            var viewModel = iBusPhoto.GetPhotoViewModel();
            viewModel.ProductVersionId = ProductIdVersion;
            return View("form/FormAddPhoto", viewModel);
        }


       
        
        public IActionResult ShowDetailProductJson()
        {
            var ProductDetailViewModel = IBusProduct.DalReadProductDetail("IP12");
            return Ok(ProductDetailViewModel);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}

