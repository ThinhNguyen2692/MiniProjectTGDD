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
        public List<EventDetail> GetEventDetails();

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


        public List<EventDetail> GetEventDetails()
        {
            var data = repositoryEventDetail.GetAll(include: e => e.Include(e => e.Product).ThenInclude(e => e.ProductVersions).Include(e => e.Event)).ToList();
            return data;
        }
    }
}
