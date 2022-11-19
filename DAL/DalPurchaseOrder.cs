using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.DataModel;
using Microsoft.EntityFrameworkCore;
using ModelProject.Models;

namespace DAL
{
    public interface IDalPurchaseOrder
    {
        public List<PurchaseOrder> GetPurchaseOrderAll();
        public PurchaseOrder GetPurchaseOrderById(string OrderId);
        public void Update(string OrderId, int stastus);
        public List<PurchaseOrder> GetPurchaseOrdersMonth();
        public List<PurchaseOrder> GetPurchaseOrdersMonthProduct();
        public void Add(PurchaseOrder order);
    }
    public class DalPurchaseOrder:IDalPurchaseOrder
    {
        private IRepository<PurchaseOrder> repository;
        private IUnitOfWork _unitOfWork;
        public DalPurchaseOrder(IUnitOfWork _unitOfWork)
        {
            this._unitOfWork = _unitOfWork;
            repository = _unitOfWork.Repository<PurchaseOrder>();
        }

       
        public List<PurchaseOrder> GetPurchaseOrderAll()
        {
            var data = repository.ListIncludes(p => p.PurchaseOrderDetails).ToList();
            return data;
        }

        public PurchaseOrder GetPurchaseOrderById(string OrderId)
        {
            var data = repository.GetAll(predicate: p => p.OrderId == OrderId, include: p => p.Include(p => p.PurchaseOrderDetails).ThenInclude(p => p.GiftDetails)).FirstOrDefault();
            if (data == null) return new PurchaseOrder();
            return data;
        }


        /// <summary>
        /// thay đổi thành trạng thái đang giao hàng
        /// </summary>
        /// <param name="OrderId"></param>
        public void Update(string OrderId, int stastus)
        {
            var data = repository.GetById(predicate: p => p.OrderId == OrderId);
            if (data == null) { _unitOfWork.SaveChanges(); return; }
            var dataUpdate = data;
            dataUpdate.OrderStatus = stastus;
            repository.Update(data, dataUpdate);
            _unitOfWork.SaveChanges();
        }

        public List<PurchaseOrder> GetPurchaseOrdersMonth()
        {
            DateTime dateTime = DateTime.Now;
            var data = repository.GetAll(predicate: p => p.SetupTime.Value.Month == dateTime.Month && p.SetupTime.Value.Year == dateTime.Year).ToList();
            return data;
        }

        public List<PurchaseOrder> GetPurchaseOrdersMonthProduct()
        {
            DateTime dateTime = DateTime.Now;
            var data = repository.GetAll(predicate: p => p.SetupTime.Value.Month == dateTime.Month || p.SetupTime.Value.Year == dateTime.Year || p.OrderStatus == 0 || p.OrderStatus == 1, include: p => p.Include(p => p.PurchaseOrderDetails)).ToList();
            return data;
        }

        public void Add(PurchaseOrder order)
        {
            repository.Add(order);
            _unitOfWork.SaveChanges();
        }

    }
}
