using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ModelProject.Models;

namespace BUS
{
    public interface IBusProductPhoto
    {
        public bool BusAddProductPhoto(List<int> listPhotoid, string idVersionProduct);

        public void DelPhoto(string versionID);
    }
    public class Bus_ProductPhotos:IBusProductPhoto
    {
        private static Bus_ProductPhotos _instance ;
        private static IDalProductPhoto dal_Productphotos;
        public static Bus_ProductPhotos GetBus_ProductPhotos(IDalProductPhoto dalProductPhoto) {
            dal_Productphotos = dalProductPhoto;
            if(_instance == null) { _instance = new Bus_ProductPhotos(); }
            return _instance; }
        // ket noi hinh voi san pham

        public bool BusAddProductPhoto(List<int> listPhotoid, string idVersionProduct)
        {
            //foreach (var item in listPhotoid)
            //{
            //    ProductPhoto productPhoto = new ProductPhoto(idVersionProduct, item);
            //    if(dal_Productphotos.DalAddProductPhoto(productPhoto) != true)
            //    {
            //        return false;
            //    }
            //}
            return true;
        }

        /// <summary>
        /// Xóa liên kết hình với sản phẩm
        /// </summary>
        /// <param name="versionID">Mã phiên bản sản phẩm </param>
        /// <returns></returns>
        public void DelPhoto(string versionID)
        {
             dal_Productphotos.DelPhoto(versionID);
        }
    }
}
