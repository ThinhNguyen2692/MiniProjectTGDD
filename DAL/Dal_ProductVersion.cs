using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelProject.Models;
using Microsoft.EntityFrameworkCore;
using DAL.DataModel;

namespace DAL
{
    public interface IDalProductVersion
    {
        public bool AddProductVerion(ProductVersion productVersion);
        public bool DelProductVerion(string id);
        public ProductVersion DalReadProduct(string id);
        public List<ProductVersion> DalReadProductAll();
        public bool UpdateProductVersion(ProductVersion productVersion);
      
        public bool CheckVersionQuantity(string id);
    }

    public class Dal_ProductVersion:IDalProductVersion
    {
        private  MiniProjectTGDDContext context;
        private IRepository<ProductVersion> repository;
        private IUnitOfWork _unitOfWork;
        public  Dal_ProductVersion(MiniProjectTGDDContext context, IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
            repository = _unitOfWork.Repository<ProductVersion>();
        }
        //Add thông tin phiên bản
        public bool AddProductVerion(ProductVersion productVersion)
        {
            var data = repository.GetById(p => p.VersionId == productVersion.VersionId);
            if(data != null)
            {
                return false;
            }
                repository.Add(productVersion);
                _unitOfWork.SaveChanges();
            return true;
        }


        //Xóa phiên bản sản phẩm
        public bool DelProductVerion(string id)
        {
            var data = repository.ListIncludes(x =>x.PropertiesValues, p => p.VersionQuantities, p=>p.ProductPhotos).First(v => v.VersionId == id);

            if (data == null) return false;
       
            repository.Delete(data);
            _unitOfWork.SaveChanges();
            return true;
        }

        //lấy chi tiết sản phẩm
        public ProductVersion DalReadProduct(string id)
        {

            var data2 = context.ProductVersions.Where(p => p.VersionId == id).Include(pv => pv.Product).Include(p => p.PropertiesValues).ThenInclude(p=>p.Properties).ThenInclude(p => p.Specifications).Include(p => p.VersionQuantities).ThenInclude(p => p.Color).Include(p => p.Product).ThenInclude(p => p.ProductBrandNavigation).Include(p => p.Product).ThenInclude(p => p.ProductTypeNavigation).FirstOrDefault();
            if (data2 == null) return null;
            var data = context.Products.Where(p => p.ProductId == data2.ProductId).Include(g => g.ProductVersions).Include(p => p.EventDetails).ThenInclude(p => p.Event).Include(p => p.ProductBrandNavigation).FirstOrDefault();
            if (data == null) return null;
            data2.Product = data;
            return data2;
        }

        /// <summary>
        /// Lấy danh sách  tất cả sản phẩm
        /// </summary>
        /// <returns>danh sách sản phẩm</returns>
        public List<ProductVersion> DalReadProductAll()
        {
            var data = repository.ListIncludes(p => p.Product).ToList();
            return data;
        }

        /// <summary>
        /// cập nhật phiên bản sản phẩm sản phẩm 
        /// </summary>
        /// <param name="product">thông tin sản phẩm</param>

        public bool UpdateProductVersion(ProductVersion productVersion)
        {
            context = new MiniProjectTGDDContext();
            context.ProductVersions.Update(productVersion);
            context.SaveChanges();
            return true;
        }

     

        public bool CheckVersionQuantity(string id)
        {
            var data = repository.ListIncludes(v => v.VersionQuantities).First(p => p.VersionId == id);

            foreach (var item in data.VersionQuantities)
            {
                if (item.Quantity != 0)
                {
                    return false;
                }
            }
            return true;
        }
    }

}
