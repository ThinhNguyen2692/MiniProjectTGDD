using CMSWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BUS;
using DAL.Models;
using CMSWeb.ViewModels;
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

       /// <summary>
       /// Hiện tất cả thương hiệu
       /// </summary>
       /// <returns>View: FormBrands.cshtml</returns>
       /// <returns>dánh sách thương hiệu</returns>
        [HttpGet]
        public IActionResult ShowBrands()
        {
            var brandsView = new BrandsViewModel();
           //lấy danh sách thương hiệu
            brandsView.ProductBrands = GetProductBrands();
            return View("ShowBrands", brandsView);
        }


        public IActionResult FormBrands()
        {

            return View("form/FormBrands");
        }

        public IActionResult Index()
        {
           
            return Ok();
        }

        public ProductBrand GetProductBrandById(string BrandId)
        {
          return  bus_Brands.GetBrandById(BrandId);
        }

        //Thêm thương hiệu
        [HttpPost]
        [Route("AddBrands")]
        public IActionResult AddBrands(CreateBrands createBrands)
        {
            AddBrandsViewModel addBrandsViewModel = new AddBrandsViewModel();  
            //Kiểm tra mã sản phẩm đã tồn tại
            if(GetProductBrandById(createBrands._brand.BrandId) != null)
            {
                addBrandsViewModel.createBrands = createBrands;
                addBrandsViewModel.message = "BrandsIdfales";
                return View("form/FormBrands", addBrandsViewModel);
            }
            createBrands._brand.BrandPhoto = createBrands.fileImage.FileName;
            if (bus_Brands.AddBrands(createBrands._brand) == true)
            {
                addBrandsViewModel.message = "BrandsTrue";
                    AddFileImage(createBrands.fileImage);
            }
            
            return View("form/FormBrands", addBrandsViewModel);
        }

        //thêm ảnh vào thư mục
        public void AddFileImage(IFormFile fileImage)
        {
            string fileName = fileImage.FileName;
            string upLoad = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);
            var stream = new FileStream(upLoad, FileMode.Create);
            fileImage.CopyToAsync(stream);

        }

        [HttpGet]
        [Route("RemoveBrands")]
        public IActionResult RemoveBrands(string id)
        {
            var brandsView = new BrandsViewModel();
            if (bus_Brands.CheckProduct(id)== true)
            {
                
                string? path = bus_Brands.RemoveBrand(id);
                System.IO.File.Delete("wwwroot\\images\\" + path);
                //lấy danh sách thương hiệu
                brandsView.message = "BrandRemoveTrue";
            }
            else { brandsView.message = "BrandRemoveFales"; }

            brandsView.ProductBrands = GetProductBrands();
            return View("ShowBrands", brandsView);
        }

        //load form cập nhật ảnh // hiện thông tin chi tiết sản phẩm
        [HttpGet]
        [Route("FormUpdateBrands")]
        public IActionResult ShowDetail(string id)
        {
            AddBrandsViewModel addBrandsViewModel = new AddBrandsViewModel();
           
            addBrandsViewModel.createBrands._brand = GetProductBrandById(id);
            return View("form/FormUpdateBrands", addBrandsViewModel);
        }


        public void DeleteImage(string FileImageName)
        {
            System.IO.File.Delete("wwwroot\\images\\" + FileImageName);
        }


        //cập nhật thông tin thương hiệu
        [HttpPost]
        [Route("UpdateBrands")]
        public IActionResult UpdateBrands(CreateBrands createBrands)
        {
            AddBrandsViewModel addBrandsViewModel = new AddBrandsViewModel();
           
            if (createBrands.fileImage != null)
            {
                //lấy path hình cũ;
                string path = GetProductBrandById(createBrands._brand.BrandId).BrandPhoto;
                DeleteImage(path);
                AddFileImage(createBrands.fileImage);
                createBrands._brand.BrandPhoto = createBrands.fileImage.FileName;
            }
            if (bus_Brands.UpdateBrands(createBrands._brand) != true)
            {
                addBrandsViewModel.message = "BrandsUpdateFalse";
                return View("from/FormUpdateBrands", addBrandsViewModel);
            }
            addBrandsViewModel.message = "BrandsUpdateTrue";
            addBrandsViewModel.createBrands = createBrands;
            return View("form/FormUpdateBrands", addBrandsViewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}