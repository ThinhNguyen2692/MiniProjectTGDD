using ModelProject.Models;

namespace ModelProject.ViewModel
{

  

    public class ListProductViewModel
    {
        public string ProductId { get; set; }
        public string ProductVersionId { get; set; }
        public string ProductName { get; set; }
        public int Price { get; set; }
        public int status { get; set; }

        public string path { get; set; }

        public ListProductViewModel() {  }

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
