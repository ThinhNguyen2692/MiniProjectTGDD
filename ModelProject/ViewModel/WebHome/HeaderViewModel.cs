using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelProject.ViewModel
{
    public class HeaderViewModel
    {
        public List<ListProductTypeViewModel> listProductTypeViewModels { get; set; } = new List<ListProductTypeViewModel>();
        public List<ShowBrandsViewModel> showBrandsViewModels { get; set; } = new List<ShowBrandsViewModel>();
    }
}
