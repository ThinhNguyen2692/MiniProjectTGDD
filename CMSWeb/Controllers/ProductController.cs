using CMSWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BUS;
using DAL.Models;
using Newtonsoft.Json;


namespace CMSWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }


        Bus_ProductType bus_ProductType = new Bus_ProductType();
        Bus_Brands bus_Brands = new Bus_Brands();
        Bus_Product bus_Product = new Bus_Product();
        Bus_ProductColor bus_ProductColor = new Bus_ProductColor();
        Bus_photo bus_Photo = new Bus_photo();
        Bus_ProductPecification bus_ProductPecification = new Bus_ProductPecification();
        Bus_InformationProperties bus_InformationProperties = new Bus_InformationProperties();
        Bus_ProductVersion bus_ProductVersion = new Bus_ProductVersion();
        Bus_PropertyValue bus_PropertyValue = new Bus_PropertyValue();
        Bus_versionQuantity bus_VersionQuantity = new Bus_versionQuantity();
        Bus_ProductPhotos bus_ProductPhotos = new Bus_ProductPhotos();
        

        //Hiện form
        public IActionResult ShowProduct()
        {
            ////danh sach san pham
            //ViewBag.data = bus_ProductVersion.DalReadProductAll();
            //HttpContext.Session.Remove("ProductId");
            //HttpContext.Session.Remove("ProductName");
            //HttpContext.Session.Remove("TypeId");

            return View();
        }

        public void GetTypeBrands()
        {
            ViewBag.DataBrands = bus_Brands.ReadBrandsStatus();
            ViewBag.DataType = bus_ProductType.ReadAll();
        }

        //load form nhập thương hiệu
        public IActionResult FormAddProduct()
        {
          
            var DataBrands = bus_Brands.ReadBrandsStatus();
            var DataType = bus_ProductType.ReadAll();
            ModelTam modelTam = new ModelTam();
            modelTam.productBrands = DataBrands;
            modelTam.productType = DataType;

             return View("form/FormAddProduct", modelTam);
        }

        //load form nhập hình
        public IActionResult FormAddPhoto()
        {
            
            return View("form/FormAddPhoto");
        }
        // lưu ảnh vào folder
        public void AddFileImage(IFormFile fileImage)
        {
            string fileName = fileImage.FileName;
            string upLoad = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);
            var stream = new FileStream(upLoad, FileMode.Create);
            fileImage.CopyToAsync(stream);
        }
        //Thêm product
        [HttpPost]
        [Route("AddProduct")]
        public IActionResult AddProduct (string ProductId, string ProductName, string TypeId, string BrandsId, IFormFile fileImage, string ProductDescription, DateTime ProductDate)
        {
            string fileName = fileImage.FileName;
            if (bus_Product.AddProduct(ProductId,ProductName,TypeId,BrandsId,fileName,ProductDescription, ProductDate) == true)
            {
                HttpContext.Session.SetString("ProductId", ProductId);
                HttpContext.Session.SetString("ProductName", ProductName);
                HttpContext.Session.SetString("TypeId", TypeId);
                AddFileImage(fileImage);
            }
            else
            {
                GetTypeBrands();
                View("form/FormAddProduct");
            }
            ViewBag.ProductID = HttpContext.Session.GetString("ProductId");
            return View("form/FormAddColor");
        }

        [HttpPost]
        [Route("AddProductColor")]
        public IActionResult AddProductColor(string ProductId, string ColorDescription, IFormFile fileImage)
        {
            string fileName = fileImage.FileName;
            if (bus_ProductColor.AddProductColor(ProductId, ColorDescription, fileName) != true)
            {
                ViewBag.mess = "Loi";
                ViewBag.ProductID = HttpContext.Session.GetString("ProductId");
                return View("form/FormAddColor");
            }
            AddFileImage(fileImage);
            ViewBag.ProductID = HttpContext.Session.GetString("ProductId");
            return View("form/FormAddColor");
        }

        [HttpPost]
        [Route("AddPhoto")]
        public IActionResult AddPhoto(List<IFormFile> ListImage)
        {
            if (ListImage.Count == 0) {
                return View("form/FormAddPhoto");
            }
            List<string> PhotoName = new List<string>();
            foreach (var item in ListImage)
            {
                PhotoName.Add(item.FileName);
                AddFileImage(item);
            }
            List<int> ListPhoto = bus_Photo.AddPhoto(PhotoName);
            if ( ListPhoto != null)
            {
                string json = JsonConvert.SerializeObject(ListPhoto);
                HttpContext.Session.SetString("ListPhoto", json);
            }
            ViewBag.ProductId = HttpContext.Session.GetString("ProductId");
            var typeid = HttpContext.Session.GetString("TypeId");
            ViewBag.Productname = HttpContext.Session.GetString("ProductName");
            ViewBag.DataSpecification = bus_ProductPecification.ReadSpecification(typeid);
            ViewBag.DataProperty = bus_InformationProperties.ReadProperty(typeid);
            ViewBag.ProductColorItem = bus_ProductColor.BusReadProductColors(ViewBag.ProductId);
            return View("form/FormAddProductVersion");
        }


        // ajax thêm sản phâm version
        [HttpPost]
        [Route("AddVersionProduct")]
        public bool AddVerSionProduct(ProductVersion productVersion)
        {
            if (bus_ProductVersion.AddProductVersion(productVersion) != true)
            {
                return false;
            }
             string json = HttpContext.Session.GetString("ListPhoto");
            List<int> photo = JsonConvert.DeserializeObject<List<int>>(json);
            if(bus_ProductPhotos.BusAddProductPhoto(photo, productVersion.VersionId)!= true)
            {
                return false;
            }

            return true;
        }

        // ajax thêm thông sô kỹ thuật sản phâm version
        [HttpPost]
        [Route("AddPropertyValue")]
        public bool AddPropertyValue(PropertiesValue[] valueProperty)
        {

            if (bus_PropertyValue.AddPropertyValue(valueProperty) != true)
            {
                return false;
            }
            return true;
        }


        // ajax thêm thông sô kỹ thuật sản phâm version
        [HttpPost]
        [Route("AddVersionQuantity")]
        public bool AddVersionQuantity(VersionQuantity[] versionQuantity)
        {
            
            if (bus_VersionQuantity.AddVersionQuantity(versionQuantity) != true)
            {
                return false;
            }
            return true;
        }


        [HttpGet]
        
        public IActionResult ShowDetailProduct(string id)
        {
            ViewBag.data = bus_ProductVersion.DalReadProduct(id);
            GetTypeBrands();
           
            ViewBag.ProperyValue = bus_PropertyValue.ReadValue(id);
            ViewBag.DataQuantity = bus_VersionQuantity.ReadQuantity(id);
            
            return View();
        }


        //lưu mã sản phẩm vào session
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}

