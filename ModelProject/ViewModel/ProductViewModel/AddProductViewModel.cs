using Microsoft.AspNetCore.Http;
using ModelProject.Models;

namespace ModelProject.ViewModel

{
    public class ViewModelBrands
    {
       public ViewModelBrands() { }
       public string BrandsId { get; set; }
        public string BrandsName { get; set; }

    }

    public class ViewModelType
    {
        public ViewModelType() { }
        public string TypeId { get; set; }
        public string TyName { get; set; }
    }

    public class AddProductViewModel
    {        
        public string ProductName { get; set; }
        public string ProductId { get; set; }
        public string ProdutDescription { get; set; }
        public DateTime ReleaseTime { get; set; } = DateTime.Now;
        public string TypeId { get; set; }
        public string BrandId { get; set; }
        public List<ViewModelBrands> ListBrands { get; set; }
        public List<ViewModelType> ListTypes { get; set; }
        public IFormFile FileImage { get; set; }
        public string messageAdd { get; set; }

        public AddProductViewModel() { }

        public List<ViewModelBrands> GetViewModelBrands(List<ProductBrand> brands) 
        {
            var ListviewModelBrands = new List<ViewModelBrands>() { };
            foreach (var item in brands)
            {
                ViewModelBrands viewModelBrands = new ViewModelBrands();
                viewModelBrands.BrandsName = item.BrandName;
                viewModelBrands.BrandsId = item.BrandId;
                ListviewModelBrands.Add(viewModelBrands);
            }
            
            return ListviewModelBrands;
        }
        public List<ViewModelType> GetViewModelTypes(List<ProductType> types)
        {
            var ListViewModelType = new List<ViewModelType>();
            foreach (var item in types)
            {
                ViewModelType viewModelType = new ViewModelType();
                viewModelType.TypeId = item.Typeid;
                viewModelType.TyName = item.Typename;
                ListViewModelType.Add(viewModelType);
            }
            return ListViewModelType;
        }

        public Status status { get; set; }
    }
}
