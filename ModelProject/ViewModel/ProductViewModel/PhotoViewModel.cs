using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelProject.ViewModel
{
    public class InformationPhoto
    {
        public InformationPhoto() { }
        public string PathImage { get; set; }
        public int PhotoId { get; set; }
        public bool IsPhoto { get; set; } = false;
    }
    public class PhotoViewModel
    {

        public List<IFormFile> photos { get; set; } = new List<IFormFile>();
        public List<InformationPhoto> informationPhoto { get; set; } = new List<InformationPhoto>();
        public PhotoViewModel() { }
    }
    public class ProductPhotoViewModel {
        public ProductPhotoViewModel() { }

        public PhotoViewModel photoViewModel { get; set; } = new PhotoViewModel();
        public string ProductVersionId { get; set; }
        public string ProductVerSionName { get; set; }


    }

}
