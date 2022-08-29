using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;

namespace BUS
{
    public class Bus_versionQuantity
    {
        Dal_VersionQuantity dal_VersionQuantity = new Dal_VersionQuantity();

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
    }
}
