using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BUS;
using Microsoft.AspNetCore.Http;
using ModelProject.Models;
using ModelProject.ViewModel;

namespace BUS.Services
{
    public interface IBusPhoto
    {

        public void AddImageProduct(List<IFormFile> fileImages);

        public PhotoViewModel GetPhotoViewModel();
    }
}
