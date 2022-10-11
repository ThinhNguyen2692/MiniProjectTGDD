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
    }
    public class DalEvent:IDalEvent
    {
        private IRepository<Event> repository;
        private IUnitOfWork _unitOfWork;


        public DalEvent(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
            this.repository = _unitOfWork.Repository<Event>();
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
    }
}
