﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelProject.Models;
using DAL;
using BUS.Services;
using ModelProject.ViewModel;

namespace BUS
{
    public class BusBrands : IBusBands
    {
        private IDalBrands iDalBrands;
        public BusBrands(IDalBrands iDalBrands)
        {
            this.iDalBrands = iDalBrands;
        }


        public bool AddBrands(AddBrandViewModel brandViewModel)
        {
            if (iDalBrands.GetBrandById(brandViewModel.BrandId) != null)
            {
                return false;
            }
            var brands = new ProductBrand()
            {
                BrandName = brandViewModel.BrandName,
                BrandId = brandViewModel.BrandId,
                BrandDescription = brandViewModel.BrandDescription,
                BrandPhoto = brandViewModel.BrandPhoto,
                BrandStatus = brandViewModel.BrandStatus
            };
            return iDalBrands.DalAddBrand(brands);

        }


        public List<ShowBrandsViewModel> GetProductBrands()
        {
            var ListBrands = iDalBrands.DalGetBrand();
            var ListBrandsShow = new List<ShowBrandsViewModel>();
            foreach (var item in ListBrands)
            {
                var brand = new ShowBrandsViewModel()
                {
                    BrandId = item.BrandId,
                    BrandName = item.BrandName,
                    BrandPhoto = item.BrandPhoto,
                    BrandStatus = item.BrandStatus
                };

                ListBrandsShow.Add(brand);
            }

            return ListBrandsShow;
        }
        public bool? RemoveBrand(string brandsId)
        {
            var data = iDalBrands.GetProductBrand(brandsId);
            if(data.Products.Count == 0)
            {
                if (iDalBrands.DalRemoveBrand(data.BrandId) == true)
                {
                    try
                    {
                         // Xóa ảnh
                    File.Delete("wwwroot\\images\\Logo\\" + data.BrandPhoto);
                    }
                    catch (Exception)
                    {

                        throw;
                    }

                    return true;
                }
            }
            
            return false;
        }

        public AddBrandViewModel GetBrandById(string id)
        {
            ProductBrand productBrand = iDalBrands.GetBrandById(id);
            if (productBrand == null)
            {
                return null;
            }
            var addBrandViewModel = new AddBrandViewModel();
            addBrandViewModel.BrandName = productBrand.BrandName;
            addBrandViewModel.BrandId = productBrand.BrandId;
            addBrandViewModel.BrandDescription = productBrand.BrandDescription;
            addBrandViewModel.BrandPhoto = productBrand.BrandPhoto;
            addBrandViewModel.BrandStatus = (int)productBrand.BrandStatus;
            return addBrandViewModel;
        }

        public bool UpdateBrands(AddBrandViewModel brandViewModel)
        {
            var brands = new ProductBrand()
            {
                BrandName = brandViewModel.BrandName,
                BrandId = brandViewModel.BrandId,
                BrandDescription = brandViewModel.BrandDescription,
                BrandPhoto = brandViewModel.BrandPhoto,
                BrandStatus = brandViewModel.BrandStatus
            };

            return iDalBrands.DalUpdateBrands(brands);
        }

        //Đọc dữ liệu thương hiệu đang kinh doanh
        public List<ProductBrand> DalGetbrandsByStatus()
        {
            return iDalBrands.DalGetbrandsByStatus();
        }

        public bool UpdateBrands(string demo)
        {
            ProductBrand brandViewModel = iDalBrands.GetBrandById("Apple");
            var brands = new ProductBrand()
            {
                BrandName = demo,
                BrandId = brandViewModel.BrandId,
                BrandDescription = brandViewModel.BrandDescription,
                BrandPhoto = brandViewModel.BrandPhoto,
                BrandStatus = brandViewModel.BrandStatus
            };

            return iDalBrands.DalUpdateBrands(brands);
        }

    }
}
