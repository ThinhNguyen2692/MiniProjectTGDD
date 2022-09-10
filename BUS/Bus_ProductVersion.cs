using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;

namespace BUS
{
    public interface IBusProductVersion
    {
        public bool AddProductVersion(ProductVersion productVersion);
        public ProductVersion DalReadProduct(string id);
        public void DelProductVerion(string id);
        public List<ProductVersion> DalReadProductAll();
    }
    public class Bus_ProductVersion:IBusProductVersion
    {
       public static IDalProductVersion dal_ProductVersion;
        private static Bus_ProductVersion bus_Product;

        public static Bus_ProductVersion GetBusProduct(IDalProductVersion dalProductVersion)
        {
            dal_ProductVersion = dalProductVersion;
            if(bus_Product == null) { bus_Product = new Bus_ProductVersion(); }
            return bus_Product;

        }
        
        // Thêm phiên bản sản phẩm
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

    }
}
