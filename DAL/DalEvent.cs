using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private MiniProjectTGDDContext context;

        public DalEvent(MiniProjectTGDDContext context)
        {
            this.context = context;
        }

        public bool AddEvent(Event EventItem)
        {
            var data = context.Events.Include(e => e.EventDetails).FirstOrDefault();
            if(data != null) {
            
            
            }
            context.Events.Add(EventItem);
            context.SaveChanges();
            return true;
        }
    }
}
