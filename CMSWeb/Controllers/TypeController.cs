using CMSWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BUS;
using DAL.Models;
using DAL;
using Newtonsoft.Json;

namespace CMSWeb.Controllers
{
    public class TypeController : Controller
    {
        private readonly ILogger<TypeController> _logger;

        private readonly IBusProductType bus_ProductType;

        //IBusProductPecification bus_ProductPecification = Bus_ProductPecification.GetBus_ProductPecification(Dal_ProductPecification.GetsPecification());
        //IBusInformationProperties bus_InformationProperties = Bus_InformationProperties.GetBus_InformationProperties(Dal_InformationProperties.GetInformationProperties());
        public TypeController(ILogger<TypeController> logger, IBusProductType bus_ProductType)
        {
            _logger = logger;
            this.bus_ProductType = bus_ProductType;
        }
        //ListModel listModel = ListModel.GetList();
        ////
        //public void GetTypeDetail(string typeid)
        //{

        //    listModel.productTypeDetail = bus_ProductType.BusReadType(typeid);
        //    listModel.productSpecifications = bus_ProductPecification.ReadSpecification(typeid);
        //    listModel.information = bus_InformationProperties.ReadProperty(typeid);
        //}

        ////load form lại thêm thông số kỹ thuật
        //[HttpGet]
        //[Route("FormSpecification")]
        //public IActionResult FormSpecification(string TypeId)
        //{
        //    return View("FormSpecification", TypeId);
        //}

        //[HttpGet]
        //[Route("ShowFormSpecification")]
        //public IActionResult ShowFormSpecification(int idSpecification, string TypeId)
        //{
        //    string[] InformationId = new string[2];

        //    InformationId[0] = idSpecification.ToString();
        //    InformationId[1] = TypeId;
        //    return View("FormProperty", InformationId);
        //    return View("FormProperty");
        //}

        //// hiện danh sách ngành hàng
        [Route("ShowType")]
        public IActionResult ShowType()
        {
            ListModel listModel = new ListModel();
            listModel.productType = bus_ProductType.ReadAll();
            return View(listModel);
        }

        ////load trang thêm ngành hàng
        //[Route("Formtype")]
        //public IActionResult Formtype()
        //{
        //    return View("Formtype");
        //}




        ////Xử lý thêm ngành hàng mới
        //[HttpPost]
        //[Route("AddType")]
        //public IActionResult AddType(ProductType productType)
        //{
        //    if (bus_ProductType.BusAddType(productType) != true)
        //    {
        //        // Nếu lỗi load lại trang thêm ngành hàng
        //        bool message = true;
        //        return View("Formtype", message);
        //    }
        //    string TypeId = productType.Typeid;
        //    return View("FormSpecification", TypeId);
        //}


        ////xử lý thêm thông số kỹ thuật sản phẩm
        //[HttpPost]
        //[Route("AddSpecification")]
        //public IActionResult AddSpecification(ProductSpecification productSpecification)
        //{
        //    string[] InformationId = new string[2];
        //    var SpecificationsId = bus_ProductPecification.BusAddProductPecification(productSpecification);
        //    InformationId[0] = SpecificationsId.ToString();
        //    InformationId[1] = productSpecification.TypeId;
        //    return View("FormProperty", InformationId);
        //}



        ////xử lý thêm thuộc tính thông số
        //[HttpPost]
        //[Route("AddProperty")]
        //public IActionResult AddProperty(string TypeId, int SpecificationsId, InformationProperty informationProperty)
        //{
        //    //trả mã thông sô ngành hàng
        //    bus_InformationProperties.BusAddInformationProperties(informationProperty);
        //    string[] InformationId = new string[2];
        //    InformationId[0] = SpecificationsId.ToString();
        //    InformationId[1] = TypeId;
        //    return View("FormProperty", InformationId);
        //}



        ////Hiện chi tiết ngành hàng
        //[HttpGet]
        //[Route("ShowTypeDetail")]
        //public IActionResult ShowTypeDetail(string typeid)
        //{
        //    listModel.message = null;
        //    GetTypeDetail(typeid);
        //    return View(listModel);
        //}
        //[HttpPost]
        //[Route("UpdataType")]
        //public bool UpdataType(ProductType type)
        //{
        //    if (bus_ProductType.BusUpdateType(type) == true)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}


        ////Cập nhật thuộc tính kỹ thuật
        //[HttpPost]
        //[Route("UpdataSpecification")]
        //public bool UpdataSpecification(ProductSpecification specification)
        //{
        //    if (bus_ProductPecification.UpdateSpecificatio(specification) == true)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}




        //[HttpPost]
        //[Route("UpdataProperty")]
        //public bool UpdataProperty(InformationProperty specification)
        //{
        //    bus_InformationProperties.UpDateProperty(specification);
        //    return true;

        //}


        //[HttpGet]
        //[Route("DeleteProperty")]
        //public IActionResult DeleteProperty(int id, string typeid)
        //{
        //    listModel.message = null;
        //    if (bus_InformationProperties.DalDeleteProperty(id) != true)
        //    {
        //        listModel.message = "fale";
        //    }
        //    else { listModel.message = "true"; }

        //    GetTypeDetail(typeid);
        //    return View("ShowTypeDetail", listModel);
        //}


        //[HttpGet]
        //[Route("DeleteSpecification")]
        //public IActionResult DeleteSpecification(int id, string typeid)
        //{

        //    if (bus_ProductPecification.DeleteSpecification(id) != true)
        //    {
        //        listModel.message = "fale";
        //    }
        //    else { listModel.message = "true"; }
        //    GetTypeDetail(typeid);
        //    return View("ShowTypeDetail", listModel);
        //}



        //[HttpGet]
        //[Route("DeleteType")]
        //public IActionResult DeleteType(string typeid)
        //{
        //   var itemCheck = bus_ProductType.BusReadType(typeid);
        //    if (itemCheck != null)
        //    {
        //        if (bus_InformationProperties.DeletePropertyType(typeid) == true)
        //        {
        //            bus_ProductPecification.DeleteSpecificationType(typeid);
        //            bus_ProductType.deletetype(typeid);

        //        }
        //        listModel.productType = bus_ProductType.ReadAll();
        //        return View("ShowType", listModel);
        //    }
        //    else
        //    {
        //        listModel.productType = bus_ProductType.ReadAll();
        //        return View("ShowType", listModel);
        //    }
        //    GetTypeDetail(typeid);
        //    return View("ShowTypeDetail", listModel);
        //}


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
