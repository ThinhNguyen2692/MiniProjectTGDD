using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;

namespace DAL
{
    public class Dal_VersionQuantity
    {
        //Thêm số lượng sản phẩm cho version
        public bool AddVersionQuantity(VersionQuantity versionQuantity)
        {
            try
            {
                var context = new MiniProjectTGDDContext();
                context.VersionQuantities.Add(versionQuantity);
                context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
                throw;
            }
            return true;
        }

        //Lây danh sách số lượng

        public List<VersionQuantity> ReadQuantity(string id)
        {
            List<VersionQuantity> result = new List<VersionQuantity>();
            try
            {
                var context = new MiniProjectTGDDContext();
                var data = context.VersionQuantities.Join(context.ProductColors, q => q.ColorId, i => i.ColorId, (q, i) => new
                {
                    QuantityId = q.Id,
                    VersionID = q.VersionId,
                    colorName = i.ColorDescription,
                    Qauntity = q.Quantity,
                   
                }).Where(p => p.VersionID == id).ToList();

                foreach (var item in data)
                {
                    result.Add(new VersionQuantity(item.QuantityId, item.VersionID, item.colorName, item.Qauntity));
                }

            }
            catch (Exception)
            {
                return null;
                throw;
            }
            return result;
        }

        public bool DelQuantyti(string id)
        {

            try
            {
                var context = new MiniProjectTGDDContext();
                var data = context.VersionQuantities.First(c => c.VersionId == id);
                context.Remove(data);
                context.SaveChanges();
            }
            catch (Exception)
            {

                return false;
            }
            return true;
        }

    }
}
