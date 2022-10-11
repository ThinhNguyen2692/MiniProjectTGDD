using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataModel;
using ModelProject.Models;

namespace DAL
{
    public interface IDalProductColor
    {
        public bool AddProductColor(ProductColor Color);
        public List<ProductColor> DalReadProductColors(string id);
   

    }
    public class Dal_ProductColor:IDalProductColor
    {
        private IRepository<ProductColor> repository;
        private IUnitOfWork _unitOfWork;

        public Dal_ProductColor(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
            repository = _unitOfWork.Repository<ProductColor>();
        }
        //Thêm màu cho sản phẩm
        public bool AddProductColor(ProductColor Color)
        {
                repository.Add(Color);
                _unitOfWork.SaveChanges();
            return true;
        }

       public List<ProductColor> DalReadProductColors(string id)
        {
            var data = repository.List(c => c.ProductId == id).ToList();
            if (data == null) return null;
            return data;
        }

     

    }
}
