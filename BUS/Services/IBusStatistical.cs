using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelProject.ViewModel;

namespace BUS.Services
{
    public interface IBusStatistical
    {
        public StatisticalViewModel GetStatisticalViewModel();
    }
}
