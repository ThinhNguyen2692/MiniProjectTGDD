using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelProject.Models;
using ModelProject.ViewModel;

namespace BUS.Services
{
    public interface IBusBands
    {
        public bool AddBrands(AddBrandViewModel brandViewModel);
        public List<ShowBrandsViewModel> GetProductBrands();
        public AddBrandViewModel GetBrandById(string id);
        public AddBrandViewModel? RemoveBrand(AddBrandViewModel addBrandViewModel);
        public bool UpdateBrands(AddBrandViewModel brandViewModel);
        public List<ProductBrand> DalGetbrandsByStatus();
        public bool CheckProduct(string BrandsId);
    }
}
