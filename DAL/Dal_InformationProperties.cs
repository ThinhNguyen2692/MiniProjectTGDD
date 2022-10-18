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
    public interface IDalInformationProperties
    {
        void AddInformationProperties(InformationProperty informationProperty);
      
        bool DalDeleteProperty(int property);

        public bool DeleteProperty(int property);
        public void UpdateProperty(InformationProperty informationProperty);



    }
    public class Dal_InformationProperties:IDalInformationProperties
    {


        private IRepository<InformationProperty> repository;
        private IUnitOfWork _unitOfWork;

        public Dal_InformationProperties (IUnitOfWork _unitOfWork)
        {

            this._unitOfWork = _unitOfWork;
            repository = _unitOfWork.Repository<InformationProperty>();
        }

        //Thêm thông tin thuộc tính
        public void AddInformationProperties(InformationProperty informationProperty)
        {
            repository.Add(informationProperty);
            _unitOfWork.SaveChanges();
        }

   

        //cập nhật thông tin thuộc tính
       


        //Xóa thuộc tính
        public bool DalDeleteProperty(int property)
        {
            var data = repository.List(p => p.PropertiesId == property).ToList();
            if (data.Count != 0)
            {
                repository.RemoveRange(data);
                _unitOfWork.SaveChanges();
                return true;
            }
            return false;
        }

        public bool DeleteProperty(int property)
        {
            var data = repository.GetById(predicate: i => i.PropertiesId == property);
            if(data != null)
            {
                repository.Delete(data);
                _unitOfWork.SaveChanges();
                return true;
            }
            return false;
        }

        public void UpdateProperty(InformationProperty informationProperty)
        {
            var data = repository.GetById(i => i.PropertiesId == informationProperty.PropertiesId);
            if(data != null) {
                repository.Update(data, informationProperty);
                _unitOfWork.SaveChanges();
            }
        }
    }
}
