using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelProject.Models;
using Microsoft.EntityFrameworkCore;
using DAL.DataModel;
using Microsoft.AspNetCore.Http.Metadata;

namespace DAL
{
    public interface IDaltype
    {
        bool DalAddType(ProductType type);
        bool DalUpdateType(ProductType type);
        ProductType ReadType(string id);
        List<ProductType> ReadTypes();
        public void deletetype(string typeid);
        public bool CheckProductByTypeId(string typeId);

    }
    public class Dal_ProductType : IDaltype
    {

        private IRepository<ProductType> repository;
        private IUnitOfWork _unitOfWork;


        public Dal_ProductType(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
            this.repository = _unitOfWork.Repository<ProductType>();
        }


        //Thêm ngành hàng
        public bool DalAddType(ProductType type)
        {


            if (ReadType(type.Typeid) != null)
            {
                return false;
            }
            repository.Add(type);
            _unitOfWork.SaveChanges();
            return true;
        }

        //Cập nhật thông tin ngành hàng
        public bool DalUpdateType(ProductType type)
        {
            //thông tin ngành hàng cũ
            var data = repository.GetById(i => i.Typeid == type.Typeid);
            repository.Update(data, type);
            _unitOfWork.SaveChanges();

            return true;
        }


        //lấy 1 loại sản phẩm 
        public ProductType ReadType(string id)
        {
            var data = repository.GetAll(predicate: t => t.Typeid == id, include: i => i.Include(t => t.ProductSpecifications).ThenInclude(p => p.InformationProperties)).FirstOrDefault();
            if (data == null)
            {
                return null;
            }
            return data;
        }

        //lấy danh sách ngành hàng
        public List<ProductType> ReadTypes()
        {
            var data = repository.List().ToList();
            return data;
        }

        //Xóa ngành hàng
        public void deletetype(string typeid)
        {

            //kiểm tra sản phẩm ngành hàng
            var item = repository.GetById(t => t.Typeid == typeid);
            if (item != null)
            {
                repository.Delete(item);
                _unitOfWork.SaveChanges();
            }

        }


        /// <summary>
        /// kiểm tra sản phẩm của ngành hàng còn tồn tại
        /// </summary>
        /// <param name="typeId">mã ngành hàng</param>
        /// <returns>true được xóa sản phẩm</returns>
        /// <returns>false không được xóa sản phẩm</returns>
        public bool CheckProductByTypeId(string typeId)
        {
            var data = repository.GetAll(predicate: p => p.Typeid == typeId, include: p => p.Include(p => p.Products)).FirstOrDefault();
            if (data != null) if (data.Products.Count == 0) return true; else return false;
            else return false;
        }

    }
}
