using CMSWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BUS;
using DAL.Models;
using Newtonsoft.Json;

namespace CMSWeb.Controllers
{
    public class TypeController : Controller
    {
        private readonly ILogger<TypeController> _logger;

        public TypeController(ILogger<TypeController> logger)
        {
            _logger = logger;
        }


        //load form lại thêm thông số kỹ thuật
        [HttpGet]
        [Route("FormSpecification")]
        public IActionResult FormSpecification(string typeid)
        {
            if (typeid == null)
            {
                ViewBag.Id = HttpContext.Session.GetString("typeid");
                HttpContext.Session.Remove("typeid");
            }
            else
            {
                ViewBag.Id = typeid;
            }
            return View("FormSpecification");
        }

        [HttpGet]
        [Route("ShowFormSpecification")]
        public IActionResult ShowFormSpecification(int idSpecification, string TypeId)
        {
            ViewBag.ReadTypes = bus_ProductType.ReadAll();
            ViewBag.Id = idSpecification;
            HttpContext.Session.SetString("typeid", TypeId);
            ViewBag.TypeId = TypeId;
            return View("FormProperty");
        }

        // hiện danh sách ngành hàng
        [Route("ShowType")]
        public IActionResult ShowType()
        {
            ViewBag.ReadTypes = bus_ProductType.ReadAll();
            return View();
        }

        //load trang thêm ngành hàng
        [Route("Formtype")]
        public IActionResult Formtype()
        {
            return View("Formtype");
        }

        Bus_ProductType bus_ProductType = new Bus_ProductType();
        Bus_ProductPecification bus_ProductPecification = new Bus_ProductPecification();
        Bus_InformationProperties bus_InformationProperties = new Bus_InformationProperties();


        //Xử lý thêm ngành hàng mới
        [HttpPost]
        [Route("AddType")]
        public IActionResult AddType(string TypeId, string TypeName)
        {
            if (bus_ProductType.BusAddType(TypeId, TypeName) != true)
            {
                // Nếu lỗi load lại trang thêm ngành hàng
                return View("Formtype");
            }
            else
            {
                // trả mã ngành hàng cho trang thêm thông số kỹ thuật
                ViewBag.Id = TypeId;
            }
            return View("FormSpecification");
        }


        //xử lý thêm thông số kỹ thuật sản phẩm
        [HttpPost]
        [Route("AddSpecification")]
        public IActionResult AddSpecification(string TypeId, string SpecificationName, string DescriptionSpecification)
        {
            int idSpecification = bus_ProductPecification.BusAddProductPecification(TypeId, SpecificationName, DescriptionSpecification);
            if (idSpecification != -1)
            {
                ViewBag.Id = idSpecification;
                ViewBag.TypeId = TypeId;
                // lưu lại mã ngành hàng
                HttpContext.Session.SetString("typeid", TypeId);
            }
            else
            {
                //nếu lỗi load lại trang
                return View("FormSpecification");
            }
            // chuyển qua trang thêm thuộc tính thông số sản phẩm
            return View("FormProperty");
        }



        // xử lý thêm thuộc tính thông số
        //[HttpPost]
        //[Route("AddProperty")]
        //public IActionResult AddProperty(int SpecificationId, string PropertiesName, string PropertiesDescription)
        //{
        //    //trả mã thông sô ngành hàng
        //    int idSpecification = bus_InformationProperties.BusAddInformationProperties(SpecificationId, PropertiesName, PropertiesDescription);
        //    if (idSpecification != -1)
        //    {
        //        //nếu thêm thành công 
        //        ViewBag.Id = idSpecification;
                
        //        ViewBag.TypeId = HttpContext.Session.GetString("typeid");
                
                
        //    }
        //    else
        //    {
        //        return View("FormProperty");
        //    }
        //    return View("FormProperty");
        //}



        //Hiện chi tiết ngành hàng
        [HttpGet]
        [Route("ShowTypeDetail")]
        public IActionResult ShowTypeDetail(string typeid)
        {
            if (HttpContext.Session.GetString("typeid") != null)
            {
                HttpContext.Session.Remove("typeid");
            }
            // Lấy thông tin của ngành hàng 

            GetTypeDetail(typeid);
            return View();
        }
        [HttpPost]
        [Route("UpdataType")]
        public bool UpdataType(ProductType type)
        {
            if (bus_ProductType.BusUpdateType(type) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        //Cập nhật thuộc tính kỹ thuật
        [HttpPost]
        [Route("UpdataSpecification")]
        public bool UpdataSpecification(ProductSpecification specification)
        {
            if (bus_ProductPecification.UpdateSpecificatio(specification) == true)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        

        //[HttpPost]
        //[Route("UpdataProperty")]
        //public bool UpdataProperty(InformationProperty specification)
        //{
        //    if (bus_InformationProperties.UpDateProperty(specification) == true)
        //    {
        //        return true;
        //    }
        //    else
        //    {
        //        return false;
        //    }
        //}

        //
        [HttpGet]
        [Route("DeleteProperty")]
        public IActionResult DeleteProperty(int id, string typeid)
        {
            try
            {
                if (bus_InformationProperties.DalDeleteProperty(id) == true)
                {
                    ViewBag.ReadTypes = bus_ProductType.ReadAll();
                    GetTypeDetail(typeid);
                }
                else
                {
                    GetTypeDetail(typeid);
                    return View("ShowTypeDetail");
                }
            }
            catch (Exception)
            {
                GetTypeDetail(typeid);
                return View("ShowTypeDetail");
                throw;
            }
            GetTypeDetail(typeid);
            return View("ShowTypeDetail");
        }

        //
        //[HttpGet]
        //[Route("DeleteSpecification")]
        //public IActionResult DeleteSpecification(int id, string typeid)
        //{
        //    try
        //    {
        //        if (bus_InformationProperties.DalDeletePropertySpecification(id) == true)
        //        {
        //            if (bus_ProductPecification.DeleteSpecification(id) == true)
        //            {
        //                ViewBag.ReadTypes = bus_ProductType.ReadAll();
        //                GetTypeDetail(typeid);
        //            }
        //            else
        //            {
        //                GetTypeDetail(typeid);
        //                return View("ShowTypeDetail");
        //            }
        //        }
        //        else
        //        {
        //            GetTypeDetail(typeid);
        //            return View("ShowTypeDetail");
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        GetTypeDetail(typeid);
        //        return View("ShowTypeDetail");
        //        throw;
        //    }
        //    GetTypeDetail(typeid);
        //    return View("ShowTypeDetail");
        //}


        //
        [HttpGet]
        [Route("DeleteType")]
        public IActionResult DeleteType(string typeid)
        {
            if (bus_InformationProperties.DeletePropertyType(typeid) == true)
            {
                if (bus_ProductPecification.DeleteSpecificationType(typeid) == true)
                {
                    if (bus_ProductType.deletetype(typeid) == true)
                    {
                        ViewBag.ReadTypes = bus_ProductType.ReadAll();
                    }
                    else
                    {
                        GetTypeDetail(typeid);
                        return View("ShowTypeDetail");
                    }
                }
                else
                {
                    GetTypeDetail(typeid);
                    return View("ShowTypeDetail");
                }
            }
            else
            {
                GetTypeDetail(typeid);
                return View("ShowTypeDetail");
            }
            return View("ShowType");
        }


        //
        public void GetTypeDetail(string typeid)
        {
            ViewBag.DataType = bus_ProductType.BusReadType(typeid);
            ViewBag.DataSpecification = bus_ProductPecification.ReadSpecification(typeid);
            ViewBag.DataProperty = bus_InformationProperties.ReadProperty(typeid);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
