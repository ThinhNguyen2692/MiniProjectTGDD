using ModelProject.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ModelProject.ViewModel.ProductDetailViewModel;

namespace BUS.Services
{
    public interface IBusShowProducts
    {
        public HeaderViewModel HeaderViewModel();
        public HomeViewModel GetHomeProduct();
        public ProductDetailViewModel GetProductDetail(string id);
		List<ProductShow> GetProductSuggestions(string brands);
		List<ProductShow> GetListProduct(string id);
        public List<ProductShow> GetListProductSeach(string? Key, int filterPrice = 100000000, string filterBrand = "all", string filterType = "all");

    }
}
