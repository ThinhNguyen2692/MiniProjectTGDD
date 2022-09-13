using CMSWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BUS;
using DAL.Models;
using DAL;
using Newtonsoft.Json;
using CMSWeb.ViewModels;
using CMSWeb.ViewModels.ProductTypeViewModel;

namespace CMSWeb.Controllers
{
    public class TypeController : Controller
    {
        private readonly ILogger<TypeController> _logger;

        private readonly IBusProductType Ibus_ProductType;
        private readonly IBusInformationProperties Ibus_InformationProperties;
        private readonly IBusProductPecification IbusProductPecification;
       
        public TypeController(ILogger<TypeController> logger, IBusProductType Ibus_ProductType, IBusProductPecification IbusProductPecification, IBusInformationProperties Ibus_InformationProperties)
        {
            _logger = logger;
            this.Ibus_ProductType = Ibus_ProductType;
            this.Ibus_InformationProperties = Ibus_InformationProperties;
            this.IbusProductPecification = IbusProductPecification;
        }
        //ListModel listModel = ListModel.GetList();
        ////
        
        ////load form lại thêm thông số kỹ thuật
        [HttpGet]
        [Route("FormSpecification")]
        public IActionResult FormSpecification(string TypeId)
        {
            var Specification = new CreateProductPecification();
            Specification.typeId = TypeId;
            return View("FormSpecification", Specification);
        }


        [HttpGet]
        [Route("ShowFormSpecification")]
        public IActionResult ShowFormSpecification(int idSpecification, string TypeId)
        {
            var InformationId = new CreateInformationProperty();
            InformationId.SpecificationId = idSpecification;
            InformationId.typeId = TypeId;
            return View("FormProperty", InformationId);
        }

        /// <summary>
        /// Hiện danh sách ngành hàng
        /// </summary>
        /// <returns>ShowType.cshtml</returns>
        /// <returns>Danh sách ngành hàng</returns>
        [Route("ShowType")]
        public IActionResult ShowType()
        {
            return View(GetListProductTypeViewModel());
        }


        /// <summary>
        /// lấy danh sách ngành hàng
        /// </summary>
        /// <returns></returns>
        public ListProductTypeViewModel GetListProductTypeViewModel()
        {
            var listProducttype = new ListProductTypeViewModel();
            listProducttype.listproductTypes = Ibus_ProductType.ReadAll();
            return listProducttype;
        }

        ////load trang thêm ngành hàng
        
        [Route("Formtype")]
        public IActionResult Formtype()
        {
            return View("Formtype", new CreateProductType());
        }




        ////Xử lý thêm ngành hàng mới
        [HttpPost]
        [Route("Type/AddBrands")]
        public IActionResult AddType(CreateProductType productType)
        {
            if (Ibus_ProductType.BusAddType(new ProductType(productType.typeId, productType.typeName)) != true)
            {
                // Nếu lỗi load lại trang thêm ngành hàng
                productType.message = true;
                return View("Formtype", productType);
            }
            var Specification = new CreateProductPecification();
            Specification.typeId = productType.typeId;
            return View("FormSpecification", Specification);
        }


        ////xử lý thêm thông số kỹ thuật sản phẩm
        [HttpPost]
        [Route("AddSpecification")]
        public IActionResult AddSpecification(CreateProductPecification productSpecification)
        {
            var SpecificationsId = IbusProductPecification.BusAddProductPecification(new ProductSpecification(productSpecification.typeId, productSpecification.ProductPecificationName, productSpecification.ProductPecificationDrecription));
            var Information = new CreateInformationProperty();
            Information.SpecificationId = SpecificationsId;
            return View("FormProperty", Information);
        }



        ////xử lý thêm thuộc tính thông số
        [HttpPost]
        [Route("AddProperty")]
        public IActionResult AddProperty(CreateInformationProperty createInformationProperty)
        {
            //trả mã thông sô ngành hàng
            Ibus_InformationProperties.BusAddInformationProperties(new InformationProperty(createInformationProperty.SpecificationId, createInformationProperty.InformationPropertyName, createInformationProperty.Description));
            createInformationProperty.typeId = IbusProductPecification.GetTypeIdBySpecification(createInformationProperty.SpecificationId);
            return View("FormProperty", createInformationProperty);
        }

        ////Hiện chi tiết ngành hàng
        [HttpGet]
        [Route("ShowTypeDetail")]
        public IActionResult ShowTypeDetail(string typeid)
        {
            var itemCheck = Ibus_ProductType.BusReadType(typeid);
            if(itemCheck == null)
            {
                return View("ShowType",GetListProductTypeViewModel());
            }

            var productTypeDetail = new ProductTypeDetail();

            GetTypeDetail(typeid, ref productTypeDetail);
            productTypeDetail.GetProductTypeNew();
            return View(productTypeDetail);
           }

        public void GetTypeDetail(string typeid, ref ProductTypeDetail productTypeDetail)
        {
            productTypeDetail.createListProductSpecification = new List<ArrayProductSpectification>();
            productTypeDetail.createProductType = Ibus_ProductType.BusReadType(typeid);
        }

        [HttpPost]
        [Route("UpdataType")]
        public IActionResult UpdataType(ProductTypeDetail productTypeDetail)
        {
            //lấy thông tin ngành hàng cũ
            string status = "";
            if (Ibus_ProductType.BusUpdateType(productTypeDetail.createProductType) == true)
            {
                foreach (var item in productTypeDetail.createListProductSpecification)
                {
                    item.createProductSpectification.TypeId = productTypeDetail.createProductType.Typeid;
                    IbusProductPecification.UpdateSpecificatio(item.createProductSpectification);
                    foreach (var value in item.createArrayInformationProperty)
                    {
                        value.SpecificationsId = item.createProductSpectification.SpecificationsId;
                        Ibus_InformationProperties.UpDateProperty(value);
                    }
                  
                }
                status = "UpdateTrue";
            }
            else
            {
                status = "UpdateFalse";
            }
            string Typeid = productTypeDetail.createProductType.Typeid;
             productTypeDetail = new ProductTypeDetail();
            GetTypeDetail(Typeid, ref productTypeDetail);
            productTypeDetail.GetProductTypeNew();
            productTypeDetail.messageUpdate = status;
            return View("ShowTypeDetail", productTypeDetail);
        }


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


        [HttpGet]
        [Route("DeleteProperty")]
        public IActionResult DeleteProperty(int id, string typeid)
        {
            var ProductDetail = new ProductTypeDetail();
            if (Ibus_InformationProperties.DalDeleteProperty(id) != true)
            {
                ProductDetail.messageDelete = "DeleteFalse";
            }
            else { ProductDetail.messageDelete = "DeleteTrue"; }

            GetTypeDetail(typeid, ref ProductDetail);
            ProductDetail.GetProductTypeNew();
            return View("ShowTypeDetail", ProductDetail);
        }


        [HttpGet]
        [Route("DeleteSpecification")]
        public IActionResult DeleteSpecification(int id, string typeid)
        {

            var ProductDetail = new ProductTypeDetail();
            if (IbusProductPecification.DeleteSpecification(id) != true)
            {
                ProductDetail.messageDelete = "DeleteFalse";
            }
            else { ProductDetail.messageDelete = "DeleteTrue"; }

            GetTypeDetail(typeid, ref ProductDetail);
            ProductDetail.GetProductTypeNew();
            return View("ShowTypeDetail", ProductDetail);
        }



        [HttpGet]
        [Route("DeleteType")]
        public IActionResult DeleteType(string typeid)
        {
            var itemCheck = Ibus_ProductType.BusReadType(typeid);
            if (itemCheck != null)
            {
                if (Ibus_InformationProperties.DeletePropertyType(typeid) == true)
                {
                    IbusProductPecification.DeleteSpecificationType(typeid);
                    Ibus_ProductType.deletetype(typeid);

                }
                var listProducttype = new ListProductTypeViewModel();
                listProducttype.listproductTypes = Ibus_ProductType.ReadAll();
                return View("ShowType", listProducttype);
              
            }

            var ProductDetail = new ProductTypeDetail();
            GetTypeDetail(typeid, ref ProductDetail);
            return View("ShowTypeDetail", ProductDetail);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
