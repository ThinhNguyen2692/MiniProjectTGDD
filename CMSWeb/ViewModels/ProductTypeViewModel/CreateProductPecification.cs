using DAL.Models;

namespace CMSWeb.ViewModels.ProductTypeViewModel
{
    public class CreateProductPecification
    {
        public string typeId { get; set; }
        public string ProductPecificationName  { get; set; }
        public string ProductPecificationDrecription  { get; set; }
        public bool message { get; set; }

       public CreateProductPecification() { }
    }
}
