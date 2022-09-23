using ModelProject.Models;

namespace ModelProject.ViewModel
{
    public class CreateProductType
    {
        public string typeId { get; set; }
        public string typeName { get; set; }

        public bool message  = false;
        public CreateProductType() { }
    }
}
