using CMSWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BUS;
using DAL.Models;
using Newtonsoft.Json;

namespace CMSWeb.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        Bus_Brands bus_Brands = new Bus_Brands();

        public IActionResult Index()
        {
            return View("index");
        }


        public List<ProductBrand> GetBrandsAll()
        {
            return bus_Brands.ReadBrandsAll();
        }

        //hiện tất cả thương hiệu ra giao diện
        [HttpGet]
        public IActionResult ShowBrands()
        {

            var BrandsAll = GetBrandsAll();
            return View("ShowBrands", BrandsAll);
        }


        public IActionResult Froms()
        {
           
            return View("form/FormBrands");
        }

        [HttpPost]
        public ActionResult AddBrands(string BransId, string BrandsName, IFormFile fileImage, string BrandsDescription, int status)
        {

            string fileName = fileImage.FileName;
                if (bus_Brands.BusAddBrands(BransId, BrandsName, fileName, BrandsDescription, status) == true)
                {
                    try
                    {
                         AddFileImage(fileImage);   
                    }
                    catch (Exception ex)
                    {
                        
                    }
                }
            return View("from/FromBrands");
        }


        public void AddFileImage(IFormFile fileImage)
        {
            string fileName = fileImage.FileName;
            string upLoad = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);
            var stream = new FileStream(upLoad, FileMode.Create);
            fileImage.CopyToAsync(stream);
        }

        //Xóa 1 thương hiệu

        [HttpPost]
        [Route("DeleteBrands")]
        public List<ProductBrand> DeleteBrands(string id)
        {
           

            string path = bus_Brands.DeleteBrands(id);
            if (path != null)
            {
              
                ViewBag.Message = "Xóa thương hiệu Thành công";
                
            }
            else
            {
                ViewBag.Message = "Không thể xóa thương hiệu. Có thể chuyển trạng thái của thương hiệu";
                return null;
            }
            return GetBrandsAll();
        }

        [HttpPost]
        [Route("DeleteImage")]
        public void DeleteImage(string path) {

            try
            {
                System.IO.File.Delete("wwwroot\\images\\" + path);

            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpGet]
        [Route("FromUpdateBrands")]
        public IActionResult ShowDetail(string id)
        {
            ViewBag.DetailBrands = bus_Brands.BrandsDetail(id);
            return View("from/FromUpdateBrands");
        }

        [HttpPost]
        [Route("UpdateBrands")]
        public IActionResult UpdateBrands(string BransId, string BrandsName, IFormFile fileImage, string imageName, string BrandsDescription, int status)
        {
            string fileName = imageName;
            if(fileImage != null)
            {
                fileName = fileImage.FileName;
            }
            if (bus_Brands.BusUpdateBrands(BransId, BrandsName, fileName, BrandsDescription, status) == true)
            {
               
                if (fileImage != null)
                {
                    try
                    {
                        AddFileImage(fileImage);
                        System.IO.File.Delete("wwwroot\\images\\" + imageName);

                    }
                    catch (Exception ex)
                    {
                        
                    }
                    
                }
                
            }
            
            ViewBag.DetailBrands = bus_Brands.BrandsDetail(BransId);
            return View("from/FromUpdateBrands");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}