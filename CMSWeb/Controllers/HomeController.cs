﻿using CMSWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BUS.Services;
using ModelProject.Models;
using Newtonsoft.Json;
using CMSWeb.Models.ProductBrands;
using ModelProject.ViewModel;
using CMSWeb.ViewModels.ProductBrandsViewModel;
using Microsoft.AspNetCore.Authorization;
using X.PagedList;

namespace CMSWeb.Controllers
{
    [Authorize(Roles = "1,5")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBusBands bus_Brands;

        public HomeController(ILogger<HomeController> logger, IBusBands brands)
        {
            _logger = logger;
            bus_Brands = brands;

        }




        


        /// <summary>
        /// Hiện danh sách thương hiệu
        /// </summary>
        /// <returns>View: FormBrands.cshtml</returns>
        /// <returns>danh sách thương hiệu</returns>
        [HttpGet]
        public IActionResult ShowBrands(int page = 1)
        {
            //lấy danh sách thương hiệu
            var brandsView = bus_Brands.GetProductBrands();
            var viewModel = brandsView.ToPagedList(page, 5);

            return View("ShowBrands", viewModel);
        }


      
        public IActionResult FormBrands()
        {
            var item = new AddBrandViewModel();
            return View("form/FormBrands", item);
        }

    


        /// <summary>
        /// controller: thêm thông tin thuong hiệu
        /// </summary>
        /// <param name="brandsViewModel"></param>
        /// <returns>FormBrands.cshtml</returns>
        [HttpPost]
        [Route("AddBrands")]
        public IActionResult AddBrands(AddBrandViewModel brandsViewModel)
        {
            if (bus_Brands.GetBrandById(brandsViewModel.BrandId) != null)
            {
                brandsViewModel.MessageAdd = "AddBrandsIDfalse";
            }
            else
            {
                brandsViewModel.BrandPhoto = "https://localhost:7079/images/Logo/" + brandsViewModel.fileImage.FileName;
                if (bus_Brands.AddBrands(brandsViewModel) == true)
                {
                    AddFileImage(brandsViewModel.fileImage);
                    brandsViewModel.MessageAdd = "AddBrandsTrue";
                }
                else
                {
                    brandsViewModel.MessageAdd = "AddBrandsFalse";
                }
            }
            

            return View("form/FormBrands", brandsViewModel);
        }

        /// <summary>
        /// thêm ảnh vào folder
        /// </summary>
        /// <param name="fileImage"></param>
        public void AddFileImage(IFormFile fileImage)
        {
            string fileName = fileImage.FileName;
            string upLoad = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\images\\Logo\\", fileName);
            var stream = new FileStream(upLoad, FileMode.CreateNew);
            fileImage.CopyToAsync(stream);

        }


        [HttpGet]
        public IActionResult RemoveBrands(string id)
        {
            var brands = bus_Brands.GetBrandById(id);
            var brandsCheck = bus_Brands.RemoveBrand(id);
            if (brands == null || brandsCheck == false)
            {
                ModelState.AddModelError("ErrorBrands", "Không thể xóa thương hiệu này "+id);
                return ShowBrands();

            }

            return View("form/FormUpdateBrands", brands);
        }

        /// <summary>
        /// thông tin chi tiết thương hiệu
        /// </summary>
        /// <param name="idBrands"></param>
        /// <returns></returns>
        [HttpGet]
        
        public IActionResult ShowDetail(string idBrands)
        {
            AddBrandViewModel addBrandsViewModel = bus_Brands.GetBrandById(idBrands);
            return View("form/FormUpdateBrands", addBrandsViewModel);
        }


        public void DeleteImage(string FileImageName)
        {
            System.IO.File.Delete("wwwroot\\images\\logo\\" + FileImageName);
        }


        //cập nhật thông tin thương hiệu
        [HttpPost]
        [Route("cap-nhat-thuong-hieu")]
        public IActionResult UpdateBrands(AddBrandViewModel addBrandViewModel)
        {
            //lấy path anh cũ
            string path = bus_Brands.GetBrandById(addBrandViewModel.BrandId).BrandPhoto;
            addBrandViewModel.BrandPhoto = path;
            //kiểm tra có file ảnh mới
            if (addBrandViewModel.fileImage != null)
            {
                addBrandViewModel.BrandPhoto = "https://localhost:7079/images/Logo/" + addBrandViewModel.fileImage.FileName;
                AddFileImage(addBrandViewModel.fileImage);
                try
                {
                    path = path.Remove(0, 34);
                    System.IO.File.Delete("wwwroot\\images\\Logo\\" + path);
                }
                catch (Exception)
                {
                    throw;
                }
               
            }
            //kiểm tra cập nhật
            if (bus_Brands.UpdateBrands(addBrandViewModel) == true)
            {
                addBrandViewModel.MessageUpdate = "BrandsUpdateTrue";
            }
            else
            {
                addBrandViewModel.MessageUpdate = "BrandsUpdateFalse";
            }
            return View("form/FormUpdateBrands", addBrandViewModel);
        }



       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}