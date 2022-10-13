using ModelProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataModel;

namespace DAL
{

    public interface IDal_Gift
    {
     
        public void AddGift(Gift gift);
        public void RemoveGift(int IdGift);
        public void RemoveGift(List<Gift> gifts);
    }

    public class Dal_Gift : IDal_Gift
    {
        private IRepository<Gift> repository;
        private IUnitOfWork _unitOfWork;

        public Dal_Gift(IUnitOfWork uniOfWork)
        {
            _unitOfWork = uniOfWork;
            this.repository = _unitOfWork.Repository<Gift>();
           
        }
        public void AddGift(Gift gift)
        {
            repository.Add(gift);
            _unitOfWork.SaveChanges();
        }


        public void RemoveGift(int IdGift)
        {
            var data = repository.GetById(g => g.GiftId == IdGift);
            if (data == null) return;
            repository.Delete(data);
            _unitOfWork.SaveChanges();
        }

        /// <summary>
        /// Xóa danh sách khuyến mãi
        /// </summary>
        /// <param name="gifts"></param>
        public void RemoveGift(List<Gift> gifts)
        {
            
            repository.RemoveRange(gifts);
            _unitOfWork.SaveChanges();
        }
    }
}
