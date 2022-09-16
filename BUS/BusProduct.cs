using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;
using BUS.Services;

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
        public BusProduct(IDAlProduct product, IDalVersionQuantity dal_VersionQuantity, IDalPropertyValue dal_PropertyValue , IDalProductColor dal_ProductColor, IDaltype dal_ProductType, IDalBrands iDalBrands, IDalProductVersion dal_ProductVersion)
        {
            dal_Product = product;
            this.dal_VersionQuantity = dal_VersionQuantity;
            this.dal_PropertyValue = dal_PropertyValue;
            this.dal_ProductColor = dal_ProductColor;
            this.dal_ProductType = dal_ProductType;
            this.iDalBrands = iDalBrands;
            this.dal_ProductVersion = dal_ProductVersion;
        }

        public bool AddProductVersion(ProductVersion productVersion)
        {

            return dal_ProductVersion.AddProductVerion(productVersion);
        }



        //lấy chi tiết thông tin sản phẩm
        public ProductVersion DalReadProduct(string id) { return dal_ProductVersion.DalReadProduct(id); }


        /// <summary>
        /// Lấy danh sách  tất cả sản phẩm
        /// </summary>
        /// <returns>danh sách sản phẩm</returns>
        public List<ProductVersion> DalReadProductAll() { return dal_ProductVersion.DalReadProductAll(); }


        public void DelProductVerion(string id)
        {
            dal_ProductVersion.DelProductVerion(id);
        }

        public List<ProductType> ReadAll()
        {
            return dal_ProductType.ReadTypes();
        }

        public List<ProductBrand> DalGetbrandsByStatus()
        {
            return iDalBrands.DalGetbrandsByStatus();
        }

        public void AddProduct(Product product)
        {
            DateTime dateTime = new DateTime(0001, 01, 01);
            if (product.ReleaseTime == dateTime)
            {
                product.ReleaseTime = DateTime.Now;
            }
            dal_Product.AddProduct(product);
        }

        // lấy danh sách sản phẩm
      

        public Product BusReadProduct(string productId)
        {
            return dal_Product.DalReadProduct(productId);
        }


        /// <summary>
        /// Xóa sản phẩm
        /// </summary>
        /// <param name="id">mã sản phẩm</param>
        /// <returns>path hình</returns>
        public string DeleteProduct(string id)
        {
            return dal_Product.DeleteProduct(id);
        }

        /// <summary>
        /// Kiểm tra mã sản phẩm, thông tin sản đã tồn tại chưa
        /// </summary>
        /// <param name="ProductId">mã sản phẩm</param>
        /// <returns>true sản phẩm được thêm</returns>
        /// <returns>false sản phẩm không được thêm</returns>
        public bool CheckProduct(string ProductId)
        {
            return dal_Product.CheckProduct(ProductId);
        }
        public int CheckVersionQuantity(string id)
        {
            return dal_Product.CheckVersionQuantity(id);
        }

        /// <summary>
        /// cập nhật sản phẩm
        /// </summary>
        /// <param name="product">thông tin sản phẩm</param>
        public bool UpdateProduct(Product product)
        {
            return dal_Product.UpdateProduct(product);
        }

        public bool AddVersionQuantity(VersionQuantity[] versionQuantities)
        {
            foreach (var item in versionQuantities)
            {
                if (dal_VersionQuantity.AddVersionQuantity(item) != true)
                {
                    return false;
                }
            }
            return true;
        }

        //lấy số lượng số san phẩm theo id version sản phẩm
        public List<VersionQuantity> ReadQuantity(string id)
        {
            return dal_VersionQuantity.ReadQuantity(id);
        }

        /// <summary>
        /// dữ liệu số lượng sản phẩm
        /// </summary>
        /// <param name="id">mã version sản phẩm</param>
        /// <returns></returns>
        public bool DelQuantyti(string id)
        {
            return dal_VersionQuantity.DelQuantyti(id);
        }
        public bool AddPropertyValue(PropertiesValue[] propertiesValue)
        {
            foreach (var item in propertiesValue)
            {
                if (dal_PropertyValue.AddPropertyValue(item) != true)
                {
                    return false;
                }
            }
            return true;
        }

        //Lấy thông tin theo id version sản phẩm
        public List<PropertiesValue> ReadValue(string id)
        {
            return dal_PropertyValue.ReadValue(id);
        }

        /// <summary>
        /// Xóa dư liệu thông tin của version
        /// </summary>
        /// <param name="id">Mã phiên bản sản phẩm</param>
        /// <returns>true xóa thành công</returns>
        public void DeletePropertyValue(string id)
        {
            dal_PropertyValue.DeletePropertyValue(id);

        }
        public bool AddProductColor(ProductColor productColor)
        {

            return dal_ProductColor.AddProductColor(productColor);
        }
        public List<ProductColor> BusReadProductColors(string id)
        {
            return dal_ProductColor.DalReadProductColors(id);
        }

        public List<string> delColor(string idProduct)
        {
            return dal_ProductColor.delColor(idProduct);
        }

        
    }
}
