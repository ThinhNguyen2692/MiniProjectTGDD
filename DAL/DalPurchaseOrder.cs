﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ModelProject.Models;

namespace DAL
{
    public interface IDalPurchaseOrder
    {
        public List<PurchaseOrder> GetPurchaseOrderAll();
        public PurchaseOrder GetPurchaseOrderById(string OrderId);
        public void Update(string OrderId, int stastus);
    }
    public class DalPurchaseOrder:IDalPurchaseOrder
    {
        private MiniProjectTGDDContext context;

        public DalPurchaseOrder(MiniProjectTGDDContext context) { this.context = context; }
        public List<PurchaseOrder> GetPurchaseOrderAll()
        {
            var data = context.PurchaseOrders.Include(p => p.PurchaseOrderDetails).ToList();
            return data;
        }

        public PurchaseOrder GetPurchaseOrderById(string OrderId)
        {
            var data = context.PurchaseOrders.Include(p => p.PurchaseOrderDetails).ThenInclude(p => p.GiftDetails).FirstOrDefault(p => p.OrderId == OrderId);
            if (data == null) return null;
            return data;
        }


        /// <summary>
        /// thay đổi thành trạng thái đang giao hàng
        /// </summary>
        /// <param name="OrderId"></param>
        public void Update(string OrderId, int stastus)
        {
            var data = context.PurchaseOrders.FirstOrDefault(p => p.OrderId == OrderId);
            if (data == null) return;
            data.OrderStatus = stastus;
            context.SaveChanges();
        }

    }
}