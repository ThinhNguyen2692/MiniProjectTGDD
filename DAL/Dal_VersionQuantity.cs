using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public interface IDalVersionQuantity
    {
        public bool Update(QuantityProductVerSion quantityProductVerSion);
        public bool AddVersionQuantity(VersionQuantity versionQuantity);
        public List<VersionQuantity> ReadQuantity(string id);
        public bool DelQuantyti(string id);
        public bool CheckQuantity(List<VersionQuantity> versionQuantities);
        public void UpdateOrderCanned(VersionQuantity versionQuantity);
    }
    public class Dal_VersionQuantity : IDalVersionQuantity
    {
        private MiniProjectTGDDContext context ;
        public Dal_VersionQuantity(MiniProjectTGDDContext context)
        {
           this.context = context;
        }

        /// <summary>
        /// Thêm số lượng sản phẩm cho version
        /// </summary>
        /// <param name="versionQuantity">Dữ liệu thêm</param>
        /// <returns>thêm thành công</returns>
        public bool AddVersionQuantity(VersionQuantity versionQuantity)
        {
                var context = new MiniProjectTGDDContext();
                context.VersionQuantities.Add(versionQuantity);
                context.SaveChanges();
            return true;
        }

        /// <summary>
        /// lấy danh sách số lượng
        /// </summary>
        /// <param name="id">mã phiên bản sản phẩm</param>
        /// <returns></returns>

        public List<VersionQuantity> ReadQuantity(string id)
        {
               
                var data = context.VersionQuantities.Where(v => v.VersionId == id).Include(q => q.Color).ToList(); 
            return data;
        }

        public bool Update(QuantityProductVerSion quantityProductVerSion) {

            var data = context.VersionQuantities.First(v => v.Id == quantityProductVerSion.idQuantity);
            if (data == null) return false;
            data.Quantity = quantityProductVerSion.Quantity;
            context.SaveChanges();
            return true;
        }

        /// <summary>
        /// Hàm xóa thông tin số lượng sản phẩm
        /// </summary>
        /// <param name="id">mã phiên bản sản phẩm</param>
        /// <returns>true xóa thành công</returns>
        /// <returns>true không thể xóa</returns>
        public bool DelQuantyti(string id)
        {
          
            var data = context.VersionQuantities.Where(c => c.VersionId == id).ToList();

            if(CheckQuantity(data) == false || data.Count == 0) { return false; }
            context.VersionQuantities.RemoveRange(data);
            context.SaveChanges();
            return true;
        }

        /// <summary>
        /// kiểm tra số lượng sản phẩm
        /// </summary>
        /// <param name="versionQuantities">danh sách cần kiểm tra để xóa</param>
        /// <returns>true được xóa</returns>
        /// <returns>false không được xóa</returns>
        public bool CheckQuantity(List<VersionQuantity> versionQuantities)
        {
            // kiểm tra số lượng còn tồn kho
            foreach (var item in versionQuantities)
            {
                if (item.Quantity > 0)
                {
                    return false;
                }
            }
            return true;
        }

        /// <summary>
        /// cập nhật số lượng sản phẩm khi hủy hóa đơn về
        /// </summary>
        /// <param name="quantityProductVerSion">chứa thông tin số lượng sản phẩm</param>
        /// <returns></returns>
        public void UpdateOrderCanned(VersionQuantity versionQuantity)
        {

            var data = context.VersionQuantities.Where(v => v.VersionId == versionQuantity.VersionId).Where(v => v.ColorId == versionQuantity.ColorId).FirstOrDefault();
            if (data == null) return ;
            data.Quantity = data.Quantity + versionQuantity.Quantity;
            context.SaveChanges();
        }

    }
}
