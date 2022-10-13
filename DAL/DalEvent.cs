using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataModel;
using Microsoft.EntityFrameworkCore;
using ModelProject.Models;

namespace DAL
{
    public interface IDalEvent
    {
        public bool AddEvent(Event EventItem);
        public void Remove(int EventId);
        public void RemoveEvent(List<EventDetail> EventDetail);
    }
    public class DalEvent:IDalEvent
    {
        private IRepository<Event> repository;
        private IRepository<EventDetail> repositoryEventDetail;
        private IUnitOfWork _unitOfWork;


        public DalEvent(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
            this.repository = _unitOfWork.Repository<Event>();
            this.repositoryEventDetail = _unitOfWork.Repository<EventDetail>();
        }

        public bool AddEvent(Event EventItem)
        {
            var data = repository.ListIncludes(e => e.EventDetails).FirstOrDefault();
            if(data != null) {

                return false;
            }
            repository.Add(EventItem);
            _unitOfWork.SaveChanges();
            return true;
        }

        /// <summary>
        /// Xóa khuyến mãi sản phẩm
        /// </summary>
        /// <param name="EventId"></param>
        public void Remove(int EventId)
        {
            var data = repositoryEventDetail.GetAll(predicate: e=> e.Id == EventId).FirstOrDefault();
            if (data == null) return;
            repositoryEventDetail.Delete(data);
            _unitOfWork.SaveChanges();
        }

        public void RemoveEvent(List<EventDetail> EventDetail)
        {
            repositoryEventDetail.RemoveRange(EventDetail);
            _unitOfWork.SaveChanges();
        }
    }
}
