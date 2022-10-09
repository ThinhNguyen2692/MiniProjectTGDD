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

    }
    public class Dal_Product:IDAlProduct
    {
        private IRepository<Product> repository;
        private IUnitOfWork _unitOfWork;

        public MiniProjectTGDDContext context = new MiniProjectTGDDContext();


        public Dal_Product(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
            repository = _unitOfWork.Repository<Product>();
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
       

    
        public List<string> DeleteProductAuto(string id)
        {
            var data = context.ProductVersions.Where(p => p.ProductId == id).ToList();
            if(data.Count == 0)
            {
                //danh sách tên hình cần xóa
                List<string> path = new List<string>();
                var data2 = context.Products.Include(c => c.ProductColors).ThenInclude(p => p.VersionQuantities).First(p => p.ProductId == id);
                path.Add(data2.ProductPhoto);
                foreach (var item in data2.ProductColors)
                {
                    path.Add(item.ColorPath);
                }
                foreach (var item in data2.ProductColors)
                {
                    if(item.VersionQuantities.Count > 0)
                    {
                        context.VersionQuantities.RemoveRange(item.VersionQuantities);
                    }
                }
                context.ProductColors.RemoveRange(data2.ProductColors);
                context.Products.Remove(data2);
                context.SaveChanges();
                return path;
            }
            else
            {
                return null;
            }
           
        }




    }
}
