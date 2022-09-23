using Microsoft.AspNetCore.Http;
using ModelProject.Models;

namespace ModelProject.ViewModel
{
    public class AddColorProduct
    {
        public string ProductId { get; set; }

        public string colorName { get; set; }

        public IFormFile Fileimage { get; set; }

        public string messageAdd { get; set; }

        public AddColorProduct() { }
    }
}
