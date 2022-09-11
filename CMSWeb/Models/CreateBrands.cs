using DAL.Models;
using System.ComponentModel.DataAnnotations;

namespace CMSWeb.Models
{
    public class CreateBrands
    {

       
       public ProductBrand _brand { get; set; }
       public IFormFile? fileImage { get; set; }
       public CreateBrands() {}


    }
}
