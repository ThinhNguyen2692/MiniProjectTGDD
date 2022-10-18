using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelProject.Models;
using DAL.DataModel;
using X.PagedList;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    
    public class Dal_Brands : IDalBrands
    {
        

        private IRepository<ProductBrand> repository;
        private IUnitOfWork _uniOfWork;
        public Dal_Brands(IUnitOfWork uniOfWork)
        {
           
            _uniOfWork = uniOfWork;
            this.repository =_uniOfWork.Repository<ProductBrand>();
        }

        /// <summary>
        /// Thêm thương hiệu mới
        /// </summary>
        /// <param name="brand">thông tin thương hiệu</param>
        /// <returns>false: thêm không thành công</returns>
        /// <returns>true: thêm thành công</returns>
        public bool DalAddBrand(ProductBrand brand)
        {
            if (GetBrandById(brand.BrandId) == null)
            {
                repository.Add(brand);
                _uniOfWork.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Đọc thông tin thương hiệu
        /// </summary>
        /// <returns>danh sách thông tin các thương hiệu</returns>
        public List<ProductBrand> DalGetBrand()
        {
            var data = repository.List().OrderByDescending(b => b.BrandStatus).ToList();

            return data;
        }
        //Xóa thương hiệu
        public bool DalRemoveBrand(string id)
        {
            var data = GetBrandById(id);
            
            if (data != null)
            {
                repository.Delete(data);
                _uniOfWork.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

        //lây thông tin chi tiết thương hiệu
        public ProductBrand? GetBrandById(string id)
        {
           // var data = context.ProductBrands.Where(c => c.BrandId.Contains(id)).FirstOrDefault();
            var data = repository.GetById(m => m.BrandId == id);
            if(data == null) { return null; }
            return data;
        }


        /// <summary>
        /// Cập nhật thông tin thương hiệu
        /// </summary>
        /// <param name="brand">thông tin thương hiệu cần cập nhật</param>
        /// <returns></returns>
        public bool DalUpdateBrands(ProductBrand brand)
        {
            var data = GetBrandById(brand.BrandId);
            repository.Update(data,brand);
            _uniOfWork.SaveChanges();
            return true;
        }

        /// <summary>
        /// Đọc danh sách thương hiệu đang kinh doanh
        /// </summary>
        /// <returns>danh sach thương hiệu</returns>
        public List<ProductBrand> DalGetbrandsByStatus()
        {
            
            //var list = context.ProductBrands.Where(b => b.BrandStatus == 1).ToList();
            var list = repository.List(b => b.BrandStatus == 1).ToList();
            return list;

        }

        public ProductBrand GetProductBrand(string brandsId)
        {
            var data = repository.GetAll(predicate: p => p.BrandId == brandsId, include: p => p.Include(p => p.Products).ThenInclude(p => p.ProductVersions)).FirstOrDefault();
            if (data == null) return null;
            return data;
        }



    }
}
