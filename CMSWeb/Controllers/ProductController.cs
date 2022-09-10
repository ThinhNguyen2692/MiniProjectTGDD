using CMSWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BUS;
using DAL.Models;
using Newtonsoft.Json;
using DAL;

namespace CMSWeb.Controllers
{
    public class ProductController : Controller
    {
        private readonly ILogger<ProductController> _logger;

        public ProductController(ILogger<ProductController> logger)
        {
            _logger = logger;
        }



        //IBusProductType bus_ProductType = Bus_ProductType.GetBus_ProductType(Dal_ProductType.GetType());
        //IBrands bus_Brands = Bus_Brands.GetBrands(Dal_Brands.GetBrands());
        //IBusProduct bus_Product = Bus_Product.GetBus_Product(Dal_Product.GetDalProduct());
        //IBusProductColor bus_ProductColor = Bus_ProductColor.GetBus_ProductColor(Dal_ProductColor.GetProductColor());
        //IBusProductPhoto bus_ProductPhotos = Bus_ProductPhotos.GetBus_ProductPhotos(Dal_productphotos.GetProductPhoto());
        //IBusProductPecification bus_ProductPecification = Bus_ProductPecification.GetBus_ProductPecification(Dal_ProductPecification.GetsPecification());
        //IBusInformationProperties bus_InformationProperties = Bus_InformationProperties.GetBus_InformationProperties(Dal_InformationProperties.GetInformationProperties());
        //IBusProductVersion bus_ProductVersion = Bus_ProductVersion.GetBusProduct(Dal_ProductVersion.GetProductVersion());
        //IBusPropertyValue bus_PropertyValue = Bus_PropertyValue.GetPropertyValue(Dal_PropertyValue.GetPropertyValue());
        //IBusQuanity bus_VersionQuantity = Bus_versionQuantity.GetVersionQuantity(Dal_VersionQuantity.GetVersionQuantity());
        //IBusPhoto bus_Photo = Bus_photo.GetPhoto(Dal_Photo.GetDalPhoto());
        //public ListModel listModel = ListModel.GetList();

        ////Hiện form


        ///// <summary>
        ///// Lấy danh sách thương hiệu đang kinh doanh
        ///// Lấy danh sách ngành hàng
        ///// </summary>
        ///// <param name="listModel"></param>
        //public void GetTypeBrands()
        //{
           
        //    listModel.productBrands = bus_Brands.DalGetbrandsByStatus();
        //    listModel.productType = bus_ProductType.ReadAll();
        //}


        ///// <summary>
        ///// load form nhập sản phẩm mới
        ///// </summary>
        ///// <returns></returns>
        //public IActionResult FormAddProduct()
        //{
        //    listModel = new ListModel();
        //    GetTypeBrands();
        //    return View("form/FormAddProduct", listModel);
        //}

        ///// <summary>
        ///// Load danh sách sản phẩm 
        ///// </summary>
        ///// <returns>trả về danh sách tất cả sản phẩm (chỉ lấy dữ liệu cần)</returns>
        //public IActionResult ShowProduct()
        //{
        //    listModel.productVersion = bus_ProductVersion.DalReadProductAll();
        //    return View(listModel);
        //}
        ///// <summary>
        ///// load form thêm hình cho sản phẩm
        ///// </summary>
        ///// <param name="ProductIdVersion">mã phiên bản sản phẩm</param>
        ///// <param name="ProductNameVersion">tên phiên bản sản phẩm</param>
        ///// <returns></returns>

        //[HttpGet]
        //[Route("FormAddPhoto")]
        //public IActionResult FormAddPhoto(string ProductIdVersion, string ProductNameVersion)
        //{
        //    string[] information = { ProductIdVersion, ProductNameVersion };
        //    return View("form/FormAddPhoto", information);
        //}


        ///// <summary>
        ///// lưu ảnh vào folder
        ///// </summary>
        ///// <param name="fileImage">file hình cần thêm vào</param>
        //public void AddFileImage(IFormFile fileImage)
        //{
        //    string fileName = fileImage.FileName;
        //    string upLoad = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images", fileName);
        //    var stream = new FileStream(upLoad, FileMode.Create);
        //    fileImage.CopyToAsync(stream);
        //}

        ///// <summary>
        ///// Thêm product
        ///// </summary>
        ///// <param name="product">Models sản phẩm cần thêm</param>
        ///// <param name="fileImage">file hình của sản phẩm </param>
        ///// <returns>load form thêm màu cho sản phẩm nếu thêm hình thành công</returns>


        //[HttpPost]
        //[Route("AddProduct")]
        //public IActionResult AddProduct(Product product, IFormFile fileImage)
        //{
        //    product.ProductPhoto = fileImage.FileName;
        //    if (bus_Product.CheckProduct(product.ProductId) == true)
        //    {
        //    bus_Product.AddProduct(product);
        //    AddFileImage(fileImage);
        //    string ProductId = product.ProductId;
        //    return View("form/FormAddColor", ProductId);
        //    }
        //    GetTypeBrands();
        //    listModel.message = "addproductfale";
        //    listModel.product = product;
        //    return View("form/FormAddProduct", listModel);
        //}

        //[HttpPost]
        //[Route("CheckProductId")]
        //public bool CheckProductId(string ProductId)
        //{
        //    return bus_Product.CheckProduct(ProductId);
        //}


        ///// <summary>
        ///// Thêm màu cho sản phẩm
        ///// </summary>
        ///// <param name="productColor">Model dữ liệu màu</param>
        ///// <param name="fileImage">file hình màu sản phẩm</param>
        ///// <returns>next form thêm phiên bản sản phẩm</returns>
        //[HttpPost]
        //[Route("AddProductColor")]
        //public IActionResult AddProductColor(ProductColor productColor, IFormFile fileImage)
        //{
        //    productColor.ColorPath = fileImage.FileName;
        //    if (bus_ProductColor.AddProductColor(productColor) == true)
        //    {
        //        AddFileImage(fileImage);

        //    }
        //    string ProductId = productColor.ProductId;
        //    return View("form/FormAddColor", ProductId);
        //}

        //[HttpGet]
        //[Route("FormAddProductVersion")]
        //public IActionResult FormAddProductVersion(string productId)
        //{
        //    var Product = bus_Product.BusReadProduct(productId);

        //    listModel.productSpecifications = bus_ProductPecification.ReadSpecification(Product.ProductType);
        //    listModel.information = bus_InformationProperties.ReadProperty(Product.ProductType);
        //    listModel.productColor = bus_ProductColor.BusReadProductColors(Product.ProductId);
        //    listModel.product = Product;
        //    return View("form/FormAddProductVersion", listModel);
        //}

        ///// <summary>
        ///// Thêm hình cho sản phẩm
        ///// </summary>
        ///// <param name="VersionId">mã phiên bản sản phẩm</param>
        ///// <param name="ListImage">danh sách file hình cần thêm</param>
        ///// <returns></returns>
        //[HttpPost]
        //[Route("AddPhoto")]
        //public IActionResult AddPhoto(string VersionId, List<IFormFile> ListImage)
        //{
        //    List<string> PhotoName = new List<string>();
        //    foreach (var item in ListImage)
        //    {
        //        PhotoName.Add(item.FileName);
        //        AddFileImage(item);
        //    }
        //    //Lấy danh sách id hình vừa thêm
        //    List<int> ListPhoto = bus_Photo.AddPhoto(PhotoName);
        //    //Thêm ảnh cho sản phẩm
        //    if (bus_ProductPhotos.BusAddProductPhoto(ListPhoto, VersionId) == false)
        //    {
        //        GetProductDetail(VersionId);
        //        listModel.message = "photofalse";
        //        return View("form/FormAddProductVersion",listModel);
        //    }
        //    GetProductDetail(VersionId);
        //    listModel.message = "phototrue";
        //    return View("ShowDetailProduct", listModel);
        //}

        ///// <summary>
        ///// ajax thêm sản phâm version
        ///// </summary>
        ///// <param name="productVersion">Model dữ liệu phiên bản sản phẩm cần thêm</param>
        ///// <returns></returns>

        //[HttpPost]
        //[Route("AddVersionProduct")]
        //public bool AddVerSionProduct(ProductVersion productVersion)
        //{
        //    if (bus_ProductVersion.AddProductVersion(productVersion) != true)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        ///// <summary>
        ///// ajax thêm thông sô kỹ thuật sản phâm version
        ///// </summary>
        ///// <param name="valueProperty">danh sách dữ liệu thông tin thông số kỹ thuật sản phẩm</param>
        ///// <returns>true thêm thành công</returns>
        ///// <returns>false thêm thất bại</returns>
        //[HttpPost]
        //[Route("AddPropertyValue")]
        //public bool AddPropertyValue(PropertiesValue[] valueProperty)
        //{

        //    if (bus_PropertyValue.AddPropertyValue(valueProperty) != true)
        //    {
        //        return false;
        //    }
        //    return true;
        //}


        ///// <summary>
        ///// ajax thêm số lượng cho phiên bản sản phẩm
        ///// </summary>
        ///// <param name="versionQuantity">dữ liệu số lượng sản phẩm</param>
        ///// <returns>true them thành công</returns>
        ///// <returns>false them thất bại</returns>
        //[HttpPost]
        //[Route("AddVersionQuantity")]
        //public bool AddVersionQuantity(VersionQuantity[] versionQuantity)
        //{

        //    if (bus_VersionQuantity.AddVersionQuantity(versionQuantity) != true)
        //    {
        //        return false;
        //    }
        //    return true;
        //}

        ///// <summary>
        ///// hiện thông tin chi tiết sản phẩm theo phiên bản sản phẩm
        ///// </summary>
        ///// <param name="id">mã phiên bản sản phẩm</param>
        ///// <returns>thông tin sản phẩm</returns>
        ///// <returns>thông tin phiên bản sản phẩm</returns>
        ///// <returns>thông tin thông số kỹ thuật sản phẩm</returns>
        ///// <returns>thông tin số lượng sản phẩm (có màu)</returns>
        //[HttpGet]
        //[Route("ShowDetailProduct")]
        //public IActionResult ShowDetailProduct(string id)
        //{
        //    GetProductDetail(id);
        //    return View(listModel);
        //}

        ///// <summary>
        ///// hàm lấy thông tin chi tiết sản phẩm
        ///// </summary>
        ///// <param name="id">mã sản phẩm version</param>
        //public void GetProductDetail(string id)
        //{
        //    listModel.productVersionDetail = bus_ProductVersion.DalReadProduct(id);
        //    listModel.product = listModel.productVersionDetail.Product;
        //    GetTypeBrands();
        //    listModel.propertiesValues = bus_PropertyValue.ReadValue(id);
        //    listModel.versionQuantities = bus_VersionQuantity.ReadQuantity(id);
        //}


        //[HttpGet]
        //[Route("DeleteProductVerSion")]
        //public IActionResult DeleteProduct(string versionId, string productId)
        //{
        //    if (bus_VersionQuantity.DelQuantyti(versionId) == true) {
        //        bus_PropertyValue.DeletePropertyValue(versionId);
        //        bus_ProductPhotos.DelPhoto(versionId);
        //        var listPath = bus_Photo.DeletePhoto();
        //        bus_ProductVersion.DelProductVerion(versionId);
        //        if (listPath.Count > 0) deleteListPhoto(listPath);
        //        if (bus_Product.CheckVersionQuantity(versionId) == 0) {
        //            bus_ProductColor.delColor(productId);
        //            string path = bus_Product.DeleteProduct(productId);
        //            if (path != null)
        //            {
        //                System.IO.File.Delete("wwwroot\\images\\" + path);
        //            }
        //        }
        //        listModel.productVersion = bus_ProductVersion.DalReadProductAll();
        //        return View("ShowProduct", listModel);
        //    }
        //    GetProductDetail(versionId);
        //    return View("ShowDetailProduct", listModel);
        //}


        ///// <summary>
        ///// Xóa hình khỏi thư mục
        ///// </summary>
        ///// <param name="paths">dahh sách đường dẫn</param>
        //public void deleteListPhoto(List<string> paths)
        //{
        //    foreach (var item in paths)
        //    {
        //        System.IO.File.Delete("wwwroot\\images\\" + item);
        //    }
        //}


        ///// <summary>
        ///// Hàm cập nhật thông tin 
        ///// </summary>
        ///// <param name="product">sản phảm</param>
        ///// <param name="productVersion"> phiên bản sản phẩm</param>
        ///// <param name="PropertiesId">danh sách id thông tin thông số</param>
        ///// <param name="ValueId">danh sách id dữ liệu</param>
        ///// <param name="Value">dữ liệu</param>
        ///// 
        ///// <param name="fileImage">hình cập nhật</param>
        ///// <param name="Id">mã sản phẩm</param>
        ///// <param name="ColorId">màu sản phẩm</param>
        ///// <param name="Quantity"></param>

        //[HttpPost]
        //[Route("UpdateProduct")]
        //public int[] UpdateProduct(Product product, ProductVersion productVersion, int[] PropertiesId, int[] ValueId, string[] Value, IFormFile fileImage, int[] Id, int[] ColorId, int[] Quantity)
        //{
        //    var GetPropertiesValues = GetPropertiesValue(PropertiesId, ValueId, Value, productVersion.VersionId);
        //    var GetVersionQuantitys = GetVersionQuantity(Id,ColorId, Quantity, productVersion.VersionId);

        //    return PropertiesId;
        //}


        ////Tạo PropertiesValue
        //public List<PropertiesValue> GetPropertiesValue(int[] PropertiesId, int[] ValueId, string[] Value, string versionId)
        //{
        //    var data = new List<PropertiesValue>();
        //   // PropertiesValue(int valueId, string versionId, int propertiesId, string ? value)
        //    for (int i = 0; i < ValueId.Length; i++)
        //    {
        //        data.Add(new PropertiesValue(ValueId[i], versionId, PropertiesId[i], Value[i]));
        //    }
        //    return data;
        //}


        //public List<VersionQuantity> GetVersionQuantity(int[] Id, int[] ColorId, int[] Quantity, string versionId)
        //{
        //    var data = new List<VersionQuantity>();
        //    //public VersionQuantity(int Id, string VersionId, int? Quantity)
        //    for (int i = 0; i < Id.Length; i++)
        //    {
        //        data.Add(new VersionQuantity(Id[i], versionId, Quantity[i], ColorId[i]));
        //    }
        //    return data;
        //}

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}

