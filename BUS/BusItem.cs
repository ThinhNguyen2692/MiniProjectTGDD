using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS.Services;
using ModelProject.Models;
using ModelProject.ViewModel;

namespace BUS
{
    public class BusItem : IBusProduct
    {
        public void AddImageProduct(PhotoViewModel viewModel)
        {
            throw new NotImplementedException();
        }

        public AddProductViewModel AddProduct(AddProductViewModel productViewModel)
        {
            throw new NotImplementedException();
        }

        public bool AddProductColor(AddColorProduct productCaddColorProductolor)
        {
            throw new NotImplementedException();
        }

        public ProductVersionViewModel AddProductVersion(ProductVersionViewModel productVersionViewModel)
        {
            throw new NotImplementedException();
        }

        public ProductVersionViewModel BusReadProduct(string productId)
        {
            throw new NotImplementedException();
        }

        public bool CheckProduct(string ProductId)
        {
            throw new NotImplementedException();
        }

        public bool CheckProductVersion(string versionID)
        {
            throw new NotImplementedException();
        }

        public bool CheckVersionQuantity(string id)
        {
            throw new NotImplementedException();
        }

        public List<ProductBrand> DalGetbrandsByStatus()
        {
            throw new NotImplementedException();
        }

        public List<ListProductViewModel> DalReadProductAll()
        {
            throw new NotImplementedException();
        }

        public ProductDetailViewModel DalReadProductDetail(string id)
        {
            throw new NotImplementedException();
        }

        public bool DelProductVerion(string id, string productID)
        {
            throw new NotImplementedException();
        }

        public PhotoViewModel GetPhotoViewModel()
        {
            throw new NotImplementedException();
        }

        public List<ProductType> ReadAll()
        {
            throw new NotImplementedException();
        }

        public PhotoViewModel ReadPhotoVerSionProduct(PhotoViewModel PhotoViewModel)
        {
            throw new NotImplementedException();
        }

        public string UpdateProduct(ProductDetailViewModel productDetailViewModel)
        {
            throw new NotImplementedException();
        }
    }
}
