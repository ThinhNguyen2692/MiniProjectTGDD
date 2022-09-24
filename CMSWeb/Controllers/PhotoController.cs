using Microsoft.AspNetCore.Mvc;
using CMSWeb.Models;
using System.Diagnostics;
using BUS;
using BUS.Services;
using ModelProject.Models;
using Newtonsoft.Json;
using ModelProject.ViewModel;

namespace CMSWeb.Controllers
{
    public class PhotoController : Controller
    {
        private readonly ILogger<PhotoController> _logger;
        private readonly IBusPhoto iBusPhoto;

        public PhotoController(ILogger<PhotoController> logger, IBusPhoto iBusPhoto)
        {
            _logger = logger;
            this.iBusPhoto = iBusPhoto;
        }

     
        public IActionResult SelectPhoto()
        {
            var viewModel = iBusPhoto.GetPhotoViewModel();
            return View( viewModel);
        }



        public IActionResult FormAddPhoto()
        {
            var viewModel = iBusPhoto.GetPhotoViewModel();
            return View("form/FormAddPhoto", viewModel);
        }

        /// <summary>
        /// Thêm hình cho sản phẩm
        /// </summary>
        /// <param name="ListImage">danh sách file hình cần thêm</param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddPhoto")]
        public IActionResult AddPhoto(PhotoViewModel viewModel)
        {

            iBusPhoto.AddImageProduct(viewModel.photos);
            viewModel = iBusPhoto.GetPhotoViewModel();
            return View("form/FormAddPhoto", viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
