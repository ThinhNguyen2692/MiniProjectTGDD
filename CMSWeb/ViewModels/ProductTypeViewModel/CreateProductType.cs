using DAL.Models;

namespace CMSWeb.ViewModels.ProductTypeViewModel
{
    public class CreateProductType
    {
        public string typeId { get; set; }
        public string typeName { get; set; }
        public bool message  = false;
        public CreateProductType() { }
    }
}
