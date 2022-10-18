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
    public interface IDalProductPecification
    {
        int DalAddProductPecification(ProductSpecification type);
  
      
        bool DeleteSpecification(int specification);
       
        public string GetTypeIdBySpecification(int SpecificationId);
        public ProductSpecification GetProductSpecification(int id);
        public void Update(ProductSpecification productSpecification);
    }

    public class Dal_ProductPecification : IDalProductPecification
    {

        private IRepository<ProductSpecification> repository;
        private IUnitOfWork _unitOfWork;
        public Dal_ProductPecification(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
            repository = _unitOfWork.Repository<ProductSpecification>();
        }
        //Thêm thông số ngành hàng
        public int DalAddProductPecification(ProductSpecification type)
        {
            repository.Add(type);
            _unitOfWork.SaveChanges();
            return type.SpecificationsId;
        }


        // lấy danh sách thông số ngành hàng
       
        //Cập nhật thông tin

       
       public ProductSpecification GetProductSpecification(int id)
        {
            var data = repository.GetAll(predicate: p => p.SpecificationsId == id, include: p => p.Include(p => p.InformationProperties)).FirstOrDefault();
            if (data == null) return null;
            return data;
        }


        public bool DeleteSpecification(int specification)
        {
            
                var data = repository.GetById(predicate: s => s.SpecificationsId == specification);
                if (data != null)
                {
               
                repository.Delete(data);

                    _unitOfWork.SaveChanges();
                    return true;
                }
            
            return false;
        }

       

        public string GetTypeIdBySpecification(int SpecificationId)
        {
            var data = repository.GetAll(predicate: s => s.SpecificationsId == SpecificationId).FirstOrDefault();
            var TypeId = data.TypeId;
            return TypeId;
        }

        public void Update(ProductSpecification productSpecification)
        {
            var data = repository.GetById(i => i.SpecificationsId == productSpecification.SpecificationsId);
            if(data != null)
            {
                repository.Update(data, productSpecification);
                _unitOfWork.SaveChanges();
            }
        }

    }

}

