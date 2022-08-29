using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;

namespace BUS
{
    public class Bus_ProductPhotos
    {
        Dal_productphotos dal_Productphotos = new Dal_productphotos();
        // ket noi hinh voi san pham

        public bool BusAddProductPhoto(List<int> listPhotoid, string idVersionProduct)
        {
            foreach (var item in listPhotoid)
            {
                ProductPhoto productPhoto = new ProductPhoto(idVersionProduct, item);
                if(dal_Productphotos.DalAddProductPhoto(productPhoto) != true)
                {
                    return false;
                }
            }
            return true;
        }
    }
}
