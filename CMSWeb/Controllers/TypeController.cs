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
            string[] InformationId = new string[2];
            InformationId[0] = idSpecification.ToString();
            InformationId[1] = TypeId;
            return View("FormProperty", InformationId);
            return View("FormProperty");
        }

        /// <summary>
        /// Hiện danh sách ngành hàng
        /// </summary>
        /// <returns>ShowType.cshtml</returns>
        /// <returns>Danh sách ngành hàng</returns>
        [Route("ShowType")]
        public IActionResult ShowType()
        {
            var listProducttype = new ListProductTypeViewModel();
            listProducttype.listproductTypes = Ibus_ProductType.ReadAll();
            return View(listProducttype);
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
            var productTypeDetail = new ProductTypeDetail();

            GetTypeDetail(typeid, ref productTypeDetail);
            return View(productTypeDetail);
           }

        public void GetTypeDetail(string typeid, ref ProductTypeDetail productTypeDetail)
        {

            productTypeDetail.productType = Ibus_ProductType.BusReadType(typeid);
            productTypeDetail.productSpecifications = IbusProductPecification.ReadSpecification(typeid);
            productTypeDetail.informationPropertys = Ibus_InformationProperties.ReadProperty(typeid);
        }

        [HttpPost]
        [Route("UpdataType")]
        public IActionResult UpdataType(ProductTypeDetail productTypeDetail)
        {
            if (Ibus_ProductType.BusUpdateType(productTypeDetail.productType) == true)
            {
                productTypeDetail.message = true;
            }
            else
            {
                productTypeDetail.message = false;
            }
            productTypeDetail.productSpecifications = IbusProductPecification.ReadSpecification(productTypeDetail.productType.Typeid);
            productTypeDetail.informationPropertys = Ibus_InformationProperties.ReadProperty(productTypeDetail.productType.Typeid);
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
                ProductDetail.message = false;
            }
            else { ProductDetail.message = true; }

            GetTypeDetail(typeid, ref ProductDetail);
            return View("ShowTypeDetail", ProductDetail);
        }


        [HttpGet]
        [Route("DeleteSpecification")]
        public IActionResult DeleteSpecification(int id, string typeid)
        {

            var ProductDetail = new ProductTypeDetail();
            if (IbusProductPecification.DeleteSpecification(id) != true)
            {
                ProductDetail.message = false;
            }
            else { ProductDetail.message = true; }

            GetTypeDetail(typeid, ref ProductDetail);
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
