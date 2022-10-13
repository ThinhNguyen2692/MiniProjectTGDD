using CMSWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BUS.Services;
using Newtonsoft.Json;
using X.PagedList;
using ModelProject.ViewModel;
using Microsoft.AspNetCore.Authorization;

namespace CMSWeb.Controllers
{

    [Authorize(Roles = "1,5")]
    public class TypeController : Controller
    {
        private readonly ILogger<TypeController> _logger;

        private readonly IBusProductType Ibus_ProductType;
      
       
        public TypeController(ILogger<TypeController> logger, IBusProductType Ibus_ProductType)
        {
            _logger = logger;
            this.Ibus_ProductType = Ibus_ProductType;

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
        public IActionResult ShowType(int page = 1)
        {
            var viewModel = Ibus_ProductType.ReadAll().ToPagedList(page, 10);
            return View("ShowType", viewModel);
        }


        /// <summary>
        /// lấy danh sách ngành hàng
        /// </summary>
        /// <returns></returns>
        //public ListProductTypeViewModel GetListProductTypeViewModel()
        //{
        //    var listProducttype = new ListProductTypeViewModel();
        //    var  = Ibus_ProductType.ReadAll();
        //    return listProducttype;
        //}

        ////load trang thêm ngành hàng
        
        [Route("Formtype")]
        public IActionResult Formtype()
        {
            return View("Formtype", new CreateProductType());
        }




        /// <summary>
        /// xử lý thêm mới thông tin ngành hàng
        /// </summary>
        /// <param name="productType">thông tin ngành hàng</param>
        /// <returns>thêm thành công chuyển sang form thêm thông tin kỹ thuật</returns>
        /// <returns>thêm thất bại load lại trang thêm thông tin ngành hàng</returns>
        [HttpPost]
        [Route("Type/AddType")]
        public IActionResult AddType(CreateProductType productType)
        {
            if (Ibus_ProductType.BusAddType(productType) != true)
            {
                // Nếu lỗi load lại trang thêm ngành hàng
                productType.message = true;
                return View("Formtype", productType);
            }
            var Specification = new CreateProductPecification();
            Specification.typeId = productType.typeId;
            return View("FormSpecification", Specification);
        }


        /// <summary>
        /// xử lý thêm thông số kỹ thuật sản phẩm
        /// </summary>
        /// <param name="productSpecification">thông tin thông số kỹ thuật</param>
        /// <returns></returns>
        [HttpPost]
        [Route("AddSpecification")]
        public IActionResult AddSpecification(CreateProductPecification productSpecification)
        {

            var SpecificationsId = Ibus_ProductType.BusAddProductPecification(productSpecification);
            var Information = new CreateInformationProperty();
            Information.SpecificationId = SpecificationsId;
            return View("FormProperty", Information);
        }



        /// <summary>
        /// xử lý thêm thuộc tính thông số
        /// </summary>
        /// <param name="createInformationProperty">thông tin thuộc tính thông số kỹ thuật</param>
        /// <returns>FormProperty: hiện lại view form nhập thông tin thuộc tính</returns>
        /// <returns>Thông tin view model thuộc tính</returns>
        [HttpPost]
        [Route("AddProperty")]
        public IActionResult AddProperty(CreateInformationProperty createInformationProperty)
        {
            Ibus_ProductType.BusAddInformationProperties(createInformationProperty);
            createInformationProperty.typeId = Ibus_ProductType.GetTypeIdBySpecification(createInformationProperty.SpecificationId);
            return View("FormProperty", createInformationProperty);
        }



        /// <summary>
        /// Hiện chi tiết thông tin ngành hàng
        /// </summary>
        /// <param name="typeid">mã ngành hàng</param>
        /// <returns>producttypeDetail</returns>
        [HttpGet]
        [Route("ShowTypeDetail")]
        public IActionResult ShowTypeDetail(string typeid)
        {
            var itemCheck = Ibus_ProductType.BusReadType(typeid);
            if (itemCheck == null)
            {
                return ShowType();
            }
            return View("ShowTypeDetail", itemCheck);
        }


        /// <summary>
        /// cập nhật thông tin ngành hàng
        /// </summary>
        /// <param name="productTypeDetail">thông tin chi tiết của ngành hàng</param>
        /// <returns>ShowTypeDetail</returns>
        /// <returns>thông tin chi tiết ngành hàng</returns>
        [HttpPost]
        [Route("UpdataType")]
        public IActionResult UpdataType(ProductTypeDetail productTypeDetail)
        {
           var value = Ibus_ProductType.BusUpdateType(productTypeDetail);
            return View("ShowTypeDetail", value);
        }





        [HttpGet]
        [Route("DeleteProperty")]
        public IActionResult DeleteProperty(int id, string typeid)
        {
            var ProductDetail = new ProductTypeDetail();
           
            if (Ibus_ProductType.DeleteInformationProperty(id) == true){
                ProductDetail = Ibus_ProductType.BusReadType(typeid);
                ProductDetail.messageDelete = "removePropertyRemoveTrue";
            }
            else
            {
                ProductDetail = Ibus_ProductType.BusReadType(typeid);
                ModelState.AddModelError("ErrorType", "Không thê xóa thông số của ngành hàng");
            }
            return View("ShowTypeDetail", ProductDetail);
        }


        [HttpGet]
        [Route("DeleteSpecification")]
        public IActionResult DeleteSpecification(int id, string typeid)
        {
            var ProductDetail = new ProductTypeDetail();

            if (Ibus_ProductType.deleteSpecificatio(id) == true)
            {
                ProductDetail = Ibus_ProductType.BusReadType(typeid);
                ProductDetail.messageDelete = "removeSpecificationRemoveTrue";
            }
            else
            {
                ProductDetail = Ibus_ProductType.BusReadType(typeid);
                
                ModelState.AddModelError("ErrorType", "Không thê xóa thông số của ngành hàng");
            }

            return View("ShowTypeDetail", ProductDetail);
        }

       

        [HttpGet]
        [Route("DeleteType")]
        public IActionResult DeleteType(string typeid)
        {
            var ProductDetail = Ibus_ProductType.BusReadType(typeid);
            if (Ibus_ProductType.deletetype(typeid) == true) return ShowType();
            else
            {
                
                ModelState.AddModelError("ErrorType", "Không thê xóa thông số của ngành hàng");
            }
            return View("ShowTypeDetail", ProductDetail);
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
