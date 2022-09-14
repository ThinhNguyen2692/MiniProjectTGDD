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
       private  IDalProductVersion dal_ProductVersion;
        
        public Bus_ProductVersion (IDalProductVersion dalProductVersion)
        {
            dal_ProductVersion = dalProductVersion;
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
