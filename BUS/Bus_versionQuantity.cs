using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;

namespace BUS
{
    public interface IBusQuanity
    {
        public bool AddVersionQuantity(VersionQuantity[] versionQuantities);
        public List<VersionQuantity> ReadQuantity(string id);
        public bool DelQuantyti(string id);
    }
    public class Bus_versionQuantity:IBusQuanity
    {
        private static IDalVersionQuantity dal_VersionQuantity ;
        private static Bus_versionQuantity busVersionQuantity;

        public static Bus_versionQuantity GetVersionQuantity()
        {
            if(busVersionQuantity == null) { busVersionQuantity = new Bus_versionQuantity(); }
            return busVersionQuantity;
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


    }
}
