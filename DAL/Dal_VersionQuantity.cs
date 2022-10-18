using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelProject.Models;
using Microsoft.EntityFrameworkCore;
using DAL.DataModel;

namespace DAL
{
    public interface IDalVersionQuantity
    {
        public bool Update(QuantityProductVerSion quantityProductVerSion);
        public bool AddVersionQuantity(VersionQuantity versionQuantity);
        public List<VersionQuantity> ReadQuantity(string id);
      
        public bool CheckQuantity(List<VersionQuantity> versionQuantities);
        public void UpdateOrderCanned(VersionQuantity versionQuantity);
        public void Delete(int id);
        }
    public class Dal_VersionQuantity : IDalVersionQuantity
    {
        private IRepository<VersionQuantity> repository;
        private IUnitOfWork _unitOfWork;
        public Dal_VersionQuantity(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
            repository = _unitOfWork.Repository<VersionQuantity>();
        }

        /// <summary>
        /// Thêm số lượng sản phẩm cho version
        /// </summary>
        /// <param name="versionQuantity">Dữ liệu thêm</param>
        /// <returns>thêm thành công</returns>
        public bool AddVersionQuantity(VersionQuantity versionQuantity)
        {
                
                repository.Add(versionQuantity);
                _unitOfWork.SaveChanges();
            return true;
        }

        /// <summary>
        /// lấy danh sách số lượng
        /// </summary>
        /// <param name="id">mã phiên bản sản phẩm</param>
        /// <returns></returns>

        public List<VersionQuantity> ReadQuantity(string id)
        {
               
                var data = repository.GetAll(predicate: v => v.VersionId == id, include: vq => vq.Include(q => q.Color)).ToList();
            return data;
        }

        public bool Update(QuantityProductVerSion quantityProductVerSion) {

            var data = repository.GetAll(predicate: v => v.Id == quantityProductVerSion.idQuantity).FirstOrDefault();
            if (data == null) { return false; _unitOfWork.SaveChanges(); }
            repository.Attach(data);
            data.Quantity = quantityProductVerSion.Quantity;
            _unitOfWork.SaveChanges();
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

            var data = repository.GetAll(v => v.VersionId == versionQuantity.VersionId && v.ColorId == versionQuantity.ColorId).FirstOrDefault();
            if (data == null) return;
            data.Quantity = data.Quantity + versionQuantity.Quantity;
            _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// cập nhật số lượng sản phẩm khi dùng lại hóa đơn
        /// </summary>
        /// <param name="quantityProductVerSion">chứa thông tin số lượng sản phẩm</param>
        /// <returns></returns>
        public void UpdateOrder(VersionQuantity versionQuantity)
        {

            var data = repository.GetAll(v => v.VersionId == versionQuantity.VersionId && v.ColorId == versionQuantity.ColorId).FirstOrDefault();
            if (data == null) return;
            data.Quantity = data.Quantity - versionQuantity.Quantity;
            _unitOfWork.SaveChanges();
        }

        public void Delete(int id) {
            var data = repository.GetById(v => v.Id == id);
            if(data != null)
            {
                repository.Delete(data);
                _unitOfWork.SaveChanges();
            }
        }


        
    }
}
