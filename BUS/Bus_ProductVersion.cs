using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;

namespace BUS
{
    public class Bus_ProductVersion
    {
        Dal_ProductVersion dal_ProductVersion = new Dal_ProductVersion();
        Dal_ProductColor Dal_ProductColor = new Dal_ProductColor();
        Dal_Product Dal_Product = new Dal_Product();   
        Dal_PropertyValue Dal_PropertyValue = new Dal_PropertyValue();
        Dal_VersionQuantity Dal_VersionQuantity = new Dal_VersionQuantity();
        Dal_productphotos Dal_productphotos = new Dal_productphotos(); 
        
        // Thêm phiên bản sản phẩm
        public bool AddProductVersion(ProductVersion productVersion)
        {
            
            return dal_ProductVersion.AddProductVerion(productVersion);
        }

       

        //lấy chi tiết thông tin sản phẩm
        public Product DalReadProduct(string id) { return dal_ProductVersion.DalReadProduct(id); }
    }
}
