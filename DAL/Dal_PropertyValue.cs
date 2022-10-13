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
    public interface IDalPropertyValue
    {
        public bool Update(ProductVerSionDetailInformation productVerSionDetailInformation);
  
    }
    public class Dal_PropertyValue:IDalPropertyValue
    {
        
        private IRepository<PropertiesValue> repository;
        private IUnitOfWork _unitOfWork;

        public Dal_PropertyValue(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
            repository = _unitOfWork.Repository<PropertiesValue>();
        }

        //Cập nhật
        public bool Update(ProductVerSionDetailInformation productVerSionDetailInformation)
        {
            var data = repository.GetAll(predicate: p => p.ValueId == productVerSionDetailInformation.vauleId).FirstOrDefault();
            if (data == null) return false;
            repository.Attach(data);
            data.Value = productVerSionDetailInformation.Value;
            _unitOfWork.SaveChanges();
            return true;
        }

        //them thông tin thông số cho sản phẩm
        public bool AddPropertyValue(PropertiesValue propertiesValue)
        {
                repository.Add(propertiesValue);
                _unitOfWork.SaveChanges();
            return true;
        }


    }
}
