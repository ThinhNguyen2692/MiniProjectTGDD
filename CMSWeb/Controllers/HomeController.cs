using CMSWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BUS;
using DAL.Models;
using DAL;
using Newtonsoft.Json;

namespace CMSWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBrands bus_Brands;

        public HomeController(ILogger<HomeController> logger, IBrands brands)
        {
            _logger = logger;
            bus_Brands = brands;
           
        }
        ListModel listModel = new ListModel();
       
        public List<ProductBrand> GetProductBrands()
        {
            return bus_Brands.GetProductBrands();
        }

        //hiện tất cả thương hiệu ra giao diện
        [HttpGet]
        public IActionResult ShowBrands()
        {
           //lấy danh sách thương hiệu
            listModel.productBrands = GetProductBrands();
            return View("ShowBrands", listModel);
        }


        public IActionResult Index()
        {
           
            return Ok();
        }


        //Thêm thương hiệu
        [HttpPost]
        [Route("AddBrands")]
        public IActionResult AddBrands(ProductBrand productBrand, IFormFile fileImage)
        {
            productBrand.BrandPhoto = fileImage.FileName; 
            if(bus_Brands.AddBrands(productBrand) != true)
            {
                ViewData["message"] = "Thêm thương hiệu thất bại";
                return View("form/FormBrands");
            }
            AddFileImage(fileImage);
            return View("form/FormBrands");
        }

        //thêm ảnh vào thư mục
        public void AddFileImage(IFormFile fileImage)
        {
                string fileName = fileImage.FileName;
                string upLoad = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);
                var stream = new FileStream(upLoad, FileMode.Create);
                fileImage.CopyToAsync(stream);
        }

        //Xóa 1 thương hiệu

        [HttpGet]
        [Route("RemoveBrands")]
        public IActionResult RemoveBrands(string id)
        {
            string? path = bus_Brands.RemoveBrand(id);
            if (path != null)
            {
                System.IO.File.Delete("wwwroot\\images\\" + path);
            }
            else
            {
                listModel.message = "RemoveBrandsTrue";
            }
            listModel.productBrands = GetProductBrands();
            return View("", listModel);
        }

        //load form cập nhật ảnh // hiện thông tin chi tiết sản phẩm
        [HttpGet]
        [Route("FormUpdateBrands")]
        public IActionResult ShowDetail(string id)
        {
            listModel.productBrand = bus_Brands.GetBrandById(id);
            return View("form/FormUpdateBrands", listModel);
        }

        //cập nhật thông tin thương hiệu
        [HttpPost]
        [Route("UpdateBrands")]
        public IActionResult UpdateBrands(ProductBrand productBrand, IFormFile fileImage)
        {
            if (fileImage != null)
            {
                System.IO.File.Delete("wwwroot\\images\\" + productBrand.BrandPhoto);
                productBrand.BrandPhoto = fileImage.FileName;
                AddFileImage(fileImage);
            }
            if (bus_Brands.UpdateBrands(productBrand) != true)
            {
                listModel.message = "Brandsfalse";
                return View("from/FormUpdateBrands", listModel);
            }
            listModel.productBrand = bus_Brands.GetBrandById(productBrand.BrandId);
            listModel.message = "BrandsTrue";
            return View("form/FormUpdateBrands", listModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}