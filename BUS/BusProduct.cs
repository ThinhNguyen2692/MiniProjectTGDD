using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ModelProject.Models;
using ModelProject.ViewModel;
using BUS.Services;
using Microsoft.AspNetCore.Http;
using static ModelProject.ViewModel.Promation;

namespace BUS
{
    public class BusProduct: IBusProduct
    {
        private readonly IDAlProduct dal_Product;
        private readonly IDalProductVersion dal_ProductVersion;
        private readonly IDalVersionQuantity dal_VersionQuantity;
        private readonly IDalPropertyValue dal_PropertyValue;
        private readonly IDalProductColor dal_ProductColor;
        private readonly IDaltype dal_ProductType;
        private readonly IDalBrands iDalBrands;
        private readonly IDalPhoto iDalPhoto;
        private readonly IDalProductPhoto iDalProductPhoto;
        private readonly IDalEvent iDalEvent;
        private readonly IDal_Gift iDalGift;
        public BusProduct(IDAlProduct product, IDalEvent iDalEvent, IDal_Gift iDalGift, IDalProductPhoto iDalProductPhoto, IDalPhoto iDalPhoto, IDalVersionQuantity dal_VersionQuantity, IDalPropertyValue dal_PropertyValue , IDalProductColor dal_ProductColor, IDaltype dal_ProductType, IDalBrands iDalBrands, IDalProductVersion dal_ProductVersion)
        {
            dal_Product = product;
            this.dal_VersionQuantity = dal_VersionQuantity;
            this.dal_PropertyValue = dal_PropertyValue;
            this.dal_ProductColor = dal_ProductColor;
            this.dal_ProductType = dal_ProductType;
            this.iDalBrands = iDalBrands;
            this.dal_ProductVersion = dal_ProductVersion;
            this.iDalPhoto = iDalPhoto;
            this.iDalProductPhoto = iDalProductPhoto;
            this.iDalEvent = iDalEvent;
            this.iDalGift = iDalGift;
        }

        /// <summary>
        /// hàm thêm hình
        /// </summary>
        /// <param name="fileImage"></param>
        public void AddFileImage(IFormFile fileImage)
        {
            string fileName = fileImage.FileName;
            string upLoad = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\ProductDefault\\", fileName);
            var stream = new FileStream(upLoad, FileMode.OpenOrCreate);
            fileImage.CopyToAsync(stream);
        }

        /// <summary>
        /// Thêm sản phâm mới
        /// </summary>
        /// <param name="productViewModel">thông tin sản phẩm</param>
        public AddProductViewModel AddProduct(AddProductViewModel productViewModel)
        {
            Product product = new Product();
            product.ProductId = productViewModel.ProductId;
            product.ProuctName = productViewModel.ProductName;
            product.ProductBrand = productViewModel.BrandId;
            product.ProductType = productViewModel.TypeId;
            product.ReleaseTime = productViewModel.ReleaseTime;
            product.ProductPhoto = "https://localhost:7079/images/ProductDefault/" + productViewModel.FileImage.FileName;
            product.ProductDescription = productViewModel.ProdutDescription;
            if(dal_Product.DalReadProduct(product.ProductId) == null)
            {
                dal_Product.AddProduct(product);
                AddFileImage(productViewModel.FileImage);
                return null;
            }
            else
            {
                return productViewModel;
            }
            
        }

        /// <summary>
        /// Thêm màu cho sản phẩm
        /// </summary>
        /// <param name="productColor">thông tin màu</param>
        /// <returns>true thêm thành công</returns>
        public bool AddProductColor(AddColorProduct addColorProduct)
        {
           ProductColor productColor = new ProductColor();
            productColor.ProductId = addColorProduct.ProductId;
            productColor.ColorDescription = addColorProduct.colorName;
            productColor.ColorPath = "https://localhost:7079/images/ProductDefault/" + addColorProduct.Fileimage.FileName;
            if (dal_ProductColor.AddProductColor(productColor) == true)
            {
                AddFileImage(addColorProduct.Fileimage);
                return true;
            }
            else return false;
        }

        /// <summary>
        /// đọc thông tin sản phẩm, input view model ProductVersionViewModel
        /// </summary>
        /// <param name="productId">mã sản phẩm</param>
        /// <returns>ProductVersionViewModel</returns>
        public ProductVersionViewModel BusReadProduct(string productId)
        {
            //thông tin sản phẩm
            var Product = dal_Product.DalReadProduct(productId);
            //viewmodel
            var productVersionViewModeal = new ProductVersionViewModel();
            //ngành hàng sản phẩm
            var ProductType = dal_ProductType.ReadType(Product.ProductType);


            productVersionViewModeal.productVersionModel.ProductId = productId;
            productVersionViewModeal.productVersionModel.ProductVersionId = productId;
            productVersionViewModeal.productVersionModel.ProductVersionName = Product.ProuctName;
            productVersionViewModeal.information = productVersionViewModeal.GetProductInformation(ProductType);
            var listcolor = dal_ProductColor.DalReadProductColors(productId);
            if (listcolor != null) productVersionViewModeal.ColorProduct = productVersionViewModeal.GetColors(listcolor);
            return productVersionViewModeal;
        }

        /// <summary>
        /// Thêm thông tin phiên bản sản phẩm
        /// </summary>
        /// <param name="productVersionViewModel">thôn tin chi tiết phiên bản sản phẩm</param>
        /// <returns>ProductVersionViewModel </returns>
        public ProductVersionViewModel AddProductVersion(ProductVersionViewModel productVersionViewModel)
            {
            var ProductVersion = new ProductVersion();
            ProductVersion.ProductId = productVersionViewModel.productVersionModel.ProductId;
            ProductVersion.VersionName = productVersionViewModel.productVersionModel.ProductVersionName;
            ProductVersion.VersionId = productVersionViewModel.productVersionModel.ProductVersionId;
            ProductVersion.ProductPrice = productVersionViewModel.productVersionModel.ProductVersionPrice;
            ProductVersion.ProductStatus = productVersionViewModel.productVersionModel.ProductVersionStatus;
           
            foreach (var item in productVersionViewModel.information)
            {
                PropertiesValue propertiesValue = new PropertiesValue();
                propertiesValue.PropertiesId = item.ProperTyId;
                propertiesValue.VersionId = productVersionViewModel.productVersionModel.ProductVersionId;
                propertiesValue.Value = item.Value + " "+item.Description;
                ProductVersion.PropertiesValues.Add(propertiesValue);
            }
            foreach (var item in productVersionViewModel.ColorProduct)
            {
                VersionQuantity versionQuantity = new VersionQuantity();
                versionQuantity.VersionId = productVersionViewModel.productVersionModel.ProductVersionId;
                versionQuantity.ColorId = item.ColoId;
                versionQuantity.Quantity = item.QuantityProduct;
                ProductVersion.VersionQuantities.Add(versionQuantity);
            }
            if (dal_ProductVersion.AddProductVerion(ProductVersion) == true)
            {
                productVersionViewModel.MessageAdd = "addVersionTrue";

            }
            else { productVersionViewModel.MessageAdd = "addVersionFalse"; }


            return productVersionViewModel;
        }



        /// <summary>
        /// thông tin chi tiết sản phẩm
        /// </summary>
        /// <param name="id">Mã phiên bản sản phẩm</param>
        /// <returns>ProductDetailViewModel</returns>
        public ProductDetailViewModel DalReadProductDetail(string id) {
            var data = dal_ProductVersion.DalReadProduct(id);
            if (data == null) return null;
            var ProductDetail = new ProductDetailViewModel();
            ProductDetail.ProductShow.ProductId = data.ProductId;
            ProductDetail.ProductShow.ProuctName = data.Product.ProuctName;
            ProductDetail.ProductShow.ProductType = data.Product.ProductType;
            ProductDetail.ProductShow.ProductTypeName = data.Product.ProductTypeNavigation.Typename;
            ProductDetail.ProductShow.ProductBrand = data.Product.ProductBrand;
            ProductDetail.ProductShow.ProductBrandName = data.Product.ProductBrandNavigation.BrandName;
            ProductDetail.ProductShow.ProductPhoto = data.Product.ProductPhoto;
            ProductDetail.ProductShow.ProductDescription = data.Product.ProductDescription;
            ProductDetail.ReleaseTime = data.Product.ReleaseTime;
            ProductDetail.ProductShow.VersionId = data.VersionId;
            ProductDetail.ProductShow.VersionName = data.VersionName;
            ProductDetail.ProductShow.ProductStatus = data.ProductStatus;
            ProductDetail.ProductShow.ProductPrice = data.ProductPrice;
            ProductDetail.quantityProductVerSions = ProductDetail.GetQuantityProductVerSions(data.VersionQuantities.ToList());
            ProductDetail.productVerSionDetailInformation = ProductDetail.GetProductVerSionDetailInformation(data.PropertiesValues.ToList());
            ProductDetail.PhotoProduct = new List<InformationPhoto>();
            foreach (var item in data.ProductPhotos)
            {
                InformationPhoto informationPhoto = new InformationPhoto();
                informationPhoto.ProductPhotoId = item.ProductPhotoId;
                informationPhoto.PathImage = item.Photo.PhotoPath;
                ProductDetail.PhotoProduct.Add(informationPhoto);
            }
            foreach (var item in data.Product.Gifts)
            {
                Promation promation = new Promation();
                promation.productVersionId = ProductDetail.ProductShow.VersionId;
                promation.Id = item.GiftId;
                promation.PromationName = item.GiftProductNavigation.VersionName;
                promation.PromationPrice = (int)item.GiftProductNavigation.ProductPrice;
                promation.Status = item.GiftStatus;
                promation.ProductImage = item.GiftProductNavigation.Product.ProductPhoto;
                var gift = dal_ProductVersion.DalReadProduct(item.GiftProduct);
                if (gift != null)
                {
                    var Quantity = 0;
                    foreach (var value in gift.VersionQuantities)
                    {
                        Quantity += (int)value.Quantity;
                    }
                    if(Quantity == 0)
                    {
                        promation.Status = 0;
                        promation.StatusName = "Sản phẩm khuyến mãi hết hàng";
                    }
                }
                ProductDetail.ProductPromation.Add(promation);    
                
            }
            ProductDetail.ProductPromation.OrderBy(x => x.Status);
            foreach (var item in data.Product.EventDetails)
            {
                Promation promation = new Promation();
                promation.productVersionId = ProductDetail.ProductShow.VersionId;
                promation.Id = item.EventId;
                promation.PromationName = item.Event.EventName;
                promation.PromationPrice = item.Event.Promotion;
                promation.StartTime = item.Event.StartTime;
                promation.EndTime = item.Event.EndTime;
                if (promation.EndTime < DateTime.Now) { promation.StatusName = "Hết thời gian khuyến mãi"; promation.Status = 0; }
                else if (promation.StartTime > DateTime.Now) promation.StatusName = "Chưa đến thời gian khuyến mãi";
                ProductDetail.PricePromation.Add(promation);

            }
            ProductDetail.PricePromation.OrderBy(x => x.Status);

            ProductDetail.comments = data.Product.Comments.ToList();

            return ProductDetail;

        }


        /// <summary>
        /// Lấy danh sách  tất cả sản phẩm
        /// </summary>
        /// <returns>danh sách sản phẩm</returns>
        public List<ListProductViewModel> DalReadProductAll() {
            
            
            var data = dal_ProductVersion.DalReadProductAll();
            var listProductViewModel = new List<ListProductViewModel>();
            foreach (var item in data)
            {
                ListProductViewModel value = new ListProductViewModel();
                value.ProductId = item.ProductId;
                value.ProductVersionId = item.VersionId;
                value.ProductName = item.VersionName;
                value.Price = (int) item.ProductPrice;
                value.status = (int) item.ProductStatus;
                value.path = item.Product.ProductPhoto;
                listProductViewModel.Add(value);
            }
            return listProductViewModel;
        }

        /// <summary>
        /// Xóa phiên bản sản phẩm
        /// </summary>
        /// <param name="id">mã phien bản sản phẩm</param>
        /// <returns></returns>
        public bool DelProductVerion(string id, string productID)
        {
            var productversinDetail = dal_ProductVersion.DalReadProduct(id);
            //kiểm tra số lượng phiên bản sản phẩm còn lại

            foreach (var item in productversinDetail.VersionQuantities)
            {
                if(item.Quantity != 0) { return false; }
            }
            //số lượng > 0 không đc xóa phiên bản sản phẩm
          
            //Xóa khuyến mãi
            iDalEvent.RemoveEvent(productversinDetail.Product.EventDetails.ToList());
            iDalGift.RemoveGift(productversinDetail.Gifts.ToList());
            foreach (var item in productversinDetail.VersionQuantities)
            {
                dal_VersionQuantity.Delete(item.Id);
            }
            foreach (var item in productversinDetail.PropertiesValues)
            {
                dal_PropertyValue.Delete(item.ValueId);
            }
            //checkDelete nhận kết quả xóa phiên bản sản phẩm
            var checkDelete = dal_ProductVersion.DelProductVerion(id);
            //kiểm tra có xóa thông tin sản phẩm chung
            var checkDeleteProduct = dal_Product.DeleteProductAuto(id);
            //nếu cần xóa thông tin chung của sản phẩm, trả về danh sách hình cần xóa
            if (checkDeleteProduct != null)
            {
                //xóa hình sản phẩm nếu xóa sản phẩm
                foreach (var item in checkDeleteProduct)
                {
                    System.IO.File.Delete("wwwroot\\images\\ProductDefaul\\" + item);
                }
            }
            return checkDelete;
        }

        /// <summary>
        /// lấy dách ngành hàng
        /// </summary>
        /// <returns>dánh sách ngành hàng</returns>
        public List<ProductType> ReadAll()
        {
            return dal_ProductType.ReadTypes();
        }

        /// <summary>
        /// Lấy danh sách thương hiệu đang kinh doanh sản phẩm
        /// </summary>
        /// <returns></returns>
        public List<ProductBrand> DalGetbrandsByStatus()
        {
            return iDalBrands.DalGetbrandsByStatus();
        }
        /// <summary>
        /// Kiểm tra mã sản phẩm, thông tin sản đã tồn tại chưa
        /// </summary>
        /// <param name="ProductId">mã sản phẩm</param>
        /// <returns>true sản phẩm được thêm</returns>
        /// <returns>false sản phẩm không được thêm</returns>
        public bool CheckProduct(string ProductId)
        {
            if(dal_Product.DalReadProduct(ProductId) == null)
            {
                return false;
            }

            return true;
        }

        /// <summary>
        /// kiểm tra phiên bản sản phẩm còn tồn tại
        /// </summary>
        /// <param name="versionID"></param>
        /// <returns></returns>
        public bool CheckProductVersion(string versionID)
        {
            if(dal_ProductVersion.DalReadProduct(versionID) == null)
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// kiểm tra số lượng phiên bản còn tồn tại
        /// </summary>
        /// <param name="id">id phiên bản tồn tại</param>
        /// <returns>true: số lượng sản phảm = 0</returns>
        /// <returns>false: số lượng sản phảm > 0</returns>
       
        /// <summary>
        /// cập nhật sản phẩm
        /// </summary>
        /// <param name="product">thông tin sản phẩm</param>
        public string UpdateProduct(ProductDetailViewModel productDetailViewModel)
        {
            Product product = new Product();
            product.ProductId = productDetailViewModel.ProductShow.ProductId;
            product.ProuctName = productDetailViewModel.ProductShow.ProuctName;
            product.ProductBrand = productDetailViewModel.ProductShow.ProductBrand;
            product.ProductType = productDetailViewModel.ProductShow.ProductType;
            product.ReleaseTime = productDetailViewModel.ReleaseTime;
            product.ProductDescription = productDetailViewModel.ProductShow.ProductDescription;
            if (productDetailViewModel.fileImage != null)
            {
                product.ProductPhoto = "https://localhost:7079/images/ProductDefault/" + productDetailViewModel.fileImage.FileName;
            }
            else
            {
                product.ProductPhoto = dal_Product.DalReadProduct(product.ProductId).ProductPhoto;
            }
            var productVersion = new ProductVersion();
            productVersion.Product = product;
            productVersion.ProductId = product.ProductId;
            productVersion.VersionId = productDetailViewModel.ProductShow.VersionId;
            productVersion.VersionName = productDetailViewModel.ProductShow.VersionName;
            productVersion.ProductPrice = productDetailViewModel.ProductShow.ProductPrice;
            productVersion.ProductStatus = productDetailViewModel.ProductShow.ProductStatus;
            
            dal_ProductVersion.UpdateProductVersion(productVersion);
            foreach (var item in productDetailViewModel.productVerSionDetailInformation)
            {
                if(dal_PropertyValue.Update(item) == false)
                {
                    return "UpdatePropertyValueFale";
                }
                
            }
            foreach (var item in productDetailViewModel.quantityProductVerSions)
            {
                if(dal_VersionQuantity.Update(item) == false)
                return "UpdateVersionQuantityFale";
            }
            return null;
        }


        /// <summary>
        /// Lấy hình ảnh mô tả của phiên bản sản phẩm
        /// </summary>
        /// <param name="VersionID">mã phiên bản sản phẩm</param>
        /// <returns>Phôtoviewmodel</returns>
        public PhotoViewModel ReadPhotoVerSionProduct(PhotoViewModel PhotoViewModel)
        {
            List<Photo> photo = new List<Photo>();

            //tạo và thêm đối tượng hình vào bảng
            //foreach (var item in PhotoViewModel.photos)
            //{
            //    ProductPhoto productPhoto = new ProductPhoto();
            //    productPhoto.VersionId = PhotoViewModel.VersionId;
            //    Photo p = new Photo();
            //    p.PhotoPath = item.FileName;
            //    productPhoto.Photo = p;
            //    iDalProductPhoto.DalAddProductPhoto(productPhoto);
            //    PhotoViewModel.pathImage.Add(p.PhotoPath);
            //}

            //thêm hình vào folder

            return PhotoViewModel;
        }

        public void AddImageProduct(PhotoViewModel viewModel)
        {
            foreach (var item in  viewModel.photos)
            {
                Photo photo = new Photo();
                photo.PhotoPath = "https://localhost:7079/images/Products/" + item.FileName;
                var idPhoto = iDalPhoto.AddPhoto(photo);
                string fileName = item.FileName;
                ProductPhoto productPhoto = new ProductPhoto();
                productPhoto.PhotoId = idPhoto;
                productPhoto.VersionId = viewModel.ProductVersionId;
                iDalProductPhoto.DalAddProductPhoto(productPhoto);
                try
                {
                    string upLoad = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\Products\\", fileName);
                    var stream = new FileStream(upLoad, FileMode.Create);
                    item.CopyToAsync(stream);
                }
                catch (Exception)
                {
                    continue;
                }
            }
        }


        /// <summary>
        /// Đọc ảnh trong database Photo
        /// </summary>
        /// <returns>PhotoViewModel</returns>
        public PhotoViewModel GetPhotoViewModel(string versionId)
        {
            var data = iDalPhoto.ReadProductPhoto(versionId);
            PhotoViewModel photoViewModel = new PhotoViewModel();
            foreach (var item in data)
            {
                InformationPhoto photo = new InformationPhoto();
                photo.ProductPhotoId = item.ProductPhotoId;
                photo.PathImage = item.Photo.PhotoPath;
                photoViewModel.informationPhoto.Add(photo);
            }

            return photoViewModel;
        }

        /// <summary>
        /// lay ds hình trong bang photo
        /// </summary>
        /// <returns></returns>
        public PhotoViewModel GetPhotoViewModel()
        {
            var data = iDalPhoto.ReadAll();
            PhotoViewModel photoViewModel = new PhotoViewModel();
            foreach (var item in data)
            {
                InformationPhoto photo = new InformationPhoto();
                photo.ProductPhotoId = item.PhotoId;
                photo.PathImage = item.PhotoPath;
                photoViewModel.informationPhoto.Add(photo);
            }

            return photoViewModel;
        }

        /// <summary>
        /// Xóa hình
        /// </summary>
        /// <returns></returns>
        public PhotoViewModel DeletePhoto()
        {
            iDalPhoto.DeletePhoto();
            return GetPhotoViewModel();
        }


        /// <summary>
        /// Xóa  hình cho sản phẩm
        /// </summary>
        /// <param name="photoId"></param>
        /// <returns></returns>
        public PhotoViewModel DeletePhotoProduct(int photoId)
        {
            var data = iDalProductPhoto.GetById(photoId);
            if(data == null) { return new PhotoViewModel(); }
            var versionId = data.VersionId;
            iDalProductPhoto.DelPhotoProduct(data);

            return GetPhotoViewModel(versionId);
        }



        /// <summary>
        /// Xóa Khuyến mãi
        /// </summary>
        /// <param name="photoId"></param>
        /// <returns></returns>
        public void RemoveEvent(int eventId)
        {
            iDalEvent.Remove(eventId);
        }

        /// <summary>
        /// Xóa Khuyến mãi
        /// </summary>
        /// <param name="photoId"></param>
        /// <returns></returns>
        public void RemoveGift(int giftId)
        {
            iDalGift.RemoveGift(giftId);
        }

    }
}
