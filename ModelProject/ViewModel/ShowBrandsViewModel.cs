using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelProject.ViewModel
{
    public class ShowBrandsViewModel
    {
        public string BrandId { get; set; } = null!;
        public string BrandName { get; set; } = null!;
        public string BrandPhoto { get; set; } = null!;
        public int? BrandStatus { get; set; }

        public string GetStatus(int? Status)
        {
            switch (Status)
            {
                case 1: return "Đang kinh doanh"; break;
                case 0: return "Tạm ngưng kinh doanh"; break;
                default:
                    return "";
                    break;
            }

        }
    }
}
