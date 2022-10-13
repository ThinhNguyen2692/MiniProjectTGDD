using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS;
using Microsoft.AspNetCore.Http;
using ModelProject.Models;
using ModelProject.ViewModel;

namespace BUS.Services
{
    public interface IBusProduct
    {
        public AddProductViewModel AddProduct(AddProductViewModel productViewModel);
        public ProductVersionViewModel BusReadProduct(string productId);
        public ProductVersionViewModel AddProductVersion(ProductVersionViewModel productVersionViewModel);
        public bool CheckProduct(string ProductId);
    
        public bool AddProductColor(AddColorProduct productCaddColorProductolor);
        public List<ProductType> ReadAll();
        public List<ProductBrand> DalGetbrandsByStatus();
        public ProductDetailViewModel DalReadProductDetail(string id);
        public bool DelProductVerion(string id, string productID);
        public List<ListProductViewModel> DalReadProductAll();
        public string UpdateProduct(ProductDetailViewModel productDetailViewModel);
        public bool CheckProductVersion(string versionID);

        public PhotoViewModel ReadPhotoVerSionProduct(PhotoViewModel PhotoViewModel);

        public void AddImageProduct(PhotoViewModel viewModel);

        public PhotoViewModel GetPhotoViewModel(string versionId);
        public PhotoViewModel DeletePhotoProduct(int photoId);
        public PhotoViewModel DeletePhoto();
        public PhotoViewModel GetPhotoViewModel();
        public void RemoveGift(int giftId);
        public void RemoveEvent(int eventId);
    }
}
