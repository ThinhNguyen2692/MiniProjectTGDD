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
    public interface IDAlProduct
    {
        public void AddProduct(Product product);
     
        public Product DalReadProduct(string productId);
    
        public List<string> DeleteProductAuto(string id);
        public List<Product> GetProducts();

    }
    public class Dal_Product:IDAlProduct
    {
        private IRepository<Product> repository;
        private IRepository<VersionQuantity> repositoryVersionQuantity;
        private IRepository<ProductColor> repositoryProductColor;
        private IUnitOfWork _unitOfWork;

     


        public Dal_Product(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
            repository = _unitOfWork.Repository<Product>();
            repositoryVersionQuantity = _unitOfWork.Repository<VersionQuantity>();
            repositoryProductColor = _unitOfWork.Repository<ProductColor>();
        }

        /// <summary>
        ///thêm sản phẩm mới
        /// </summary>
        /// <param name="product">thong tin sản phẩm</param>
        /// <returns>true thêm thành công</returns>
        public void AddProduct(Product product)
        {
           repository.Add(product);
          _unitOfWork.SaveChanges();
        }
        /// <summary>
        /// lấy dánh sách sản phẩm
        /// </summary>
        /// <returns></returns>
     
        
        public Product DalReadProduct(string productId)
        {

            var data = repository.GetById(p => p.ProductId == productId);
            if (data == null) return null;
            return data;
        }
       
        public List<Product> GetProducts()
        {
            var data = repository.GetAll(include: p => p.Include(p => p.ProductVersions)
            .Include(p => p.ProductBrandNavigation)
            .Include(p => p.ProductTypeNavigation).Include(p => p.EventDetails).ThenInclude(e => e.Event)).ToList();
            if(data == null) { return new List<Product>(); }
            return data;
        }
    
        public List<string> DeleteProductAuto(string id)
        {
            var data = repository.GetAll(predicate: p => p.ProductId == id).ToList();
            if(data.Count == 0)
            {
                //danh sách tên hình cần xóa
                List<string> path = new List<string>();
                var data2 = repository.GetAll(predicate: p => p.ProductId == id, include: p =>p.Include(c => c.ProductColors).ThenInclude(p => p.VersionQuantities)).FirstOrDefault();
                if (data2 == null) return null;
                path.Add(data2.ProductPhoto);
                foreach (var item in data2.ProductColors)
                {
                    path.Add(item.ColorPath);
                }
                foreach (var item in data2.ProductColors)
                {
                    if(item.VersionQuantities.Count > 0)
                    {
                        repositoryVersionQuantity.RemoveRange(item.VersionQuantities);
                    }
                }
                repositoryProductColor.RemoveRange(data2.ProductColors);
                repository.Delete(data2);
                _unitOfWork.SaveChanges();
                return path;
            }
            else
            {
                return null;
            }
           
        }


        





    }
}
