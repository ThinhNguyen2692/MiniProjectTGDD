using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelProject.ViewModel;
using ModelProject.Models;

namespace DAL
{
    public interface IDalBrands
    {
        public bool DalAddBrand(ProductBrand productBrand);
        public bool DalRemoveBrand(string id);
        public List<ProductBrand> DalGetBrand();
        public ProductBrand GetBrandById(string id);
        public bool DalUpdateBrands(ProductBrand name);
        public List<ProductBrand> DalGetbrandsByStatus();
       
    }
}
