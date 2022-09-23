using ModelProject.Models;
namespace ModelProject.ViewModel
{
    public class CreateInformationProperty
    {
        public string typeId { get; set; }
        
        public string InformationPropertyName { get; set; }
        public int SpecificationId { get; set; }
        public string? Description { get; set; }

        public bool message = true;

        public CreateInformationProperty() { }
    }
}
