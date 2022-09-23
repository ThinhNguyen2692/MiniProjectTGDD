using ModelProject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{

    public interface IDal_Gift
    {
        public List<ProductType> GetProductType();
        public List<ProductType> GetProductTypeGift();
        public List<Gift> GetGift(string IdProduct);
        public void AddGift(Gift gift);
        public void UpdaeGift(int IdGift);
    }

    public class Dal_Gift : IDal_Gift
    {
        private MiniProjectTGDDContext context;
        public Dal_Gift(MiniProjectTGDDContext context)
        {
            this.context = context;
        }
        public List<ProductType> GetProductType()
        {
            var data = context.ProductTypes.Include(p => p.Products).ThenInclude(pv => pv.ProductVersions.Where(v => v.ProductPrice < 500000).Where(v => v.ProductStatus == 1)).ToList();
            return data;
        }

        public List<ProductType> GetProductTypeGift()
        {
            var data = context.ProductTypes.Include(p => p.Products).ThenInclude(pv => pv.ProductVersions.Where(v => v.ProductStatus == 1)).ToList();
            return data;
        }

        public List<Gift> GetGift(string IdProduct)
        {
            var data = context.Gifts.Where(g => g.ProductId == IdProduct).ToList();
            return data;
        }

        public void AddGift(Gift gift)
        {
            context.Gifts.Add(gift);
            context.SaveChanges();
        }


        public void UpdaeGift(int IdGift)
        {
            var data = context.Gifts.Where(g => g.GiftId == IdGift).First();
            data.GiftStatus = 0;
            context.Gifts.Update(data);
            context.SaveChanges();
        }

        
    }
}
