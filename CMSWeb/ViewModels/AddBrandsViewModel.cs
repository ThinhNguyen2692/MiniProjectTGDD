using DAL.Models;
using CMSWeb.Models;

namespace CMSWeb.ViewModels
{
    public class AddBrandsViewModel
    {
        public CreateBrands createBrands { get; set; }
        public string message { get; set; }

        public AddBrandsViewModel() { createBrands = new CreateBrands(); }
    }
}
