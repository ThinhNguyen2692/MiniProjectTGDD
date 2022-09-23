using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using ModelProject.Models;

namespace BUS
{
    public interface IBus_Gift
    {
        public List<ProductType> GetProductType();
        public List<ProductType> GetProductTypeGift();
        public List<Gift> GetGift(string IdProduct);
        public void AddGift(string IdProduct, List<string> GiftIds);
        public void UpdaeGift(int IdGift);
    }
        
    public class Bus_Gift: IBus_Gift
    {
      private  IDal_Gift iDal_Gift;   
        public Bus_Gift(IDal_Gift iDal_Gift)
        {
            this.iDal_Gift = iDal_Gift;
        }

        public List<ProductType> GetProductType()
        {
           return  iDal_Gift.GetProductType();
        }
        public List<ProductType> GetProductTypeGift()
        {
            return iDal_Gift.GetProductTypeGift();
        }

        public List<Gift> GetGift(string IdProduct) { 
        
            return iDal_Gift.GetGift(IdProduct);
        }
        public void AddGift(string IdProduct, List<string> GiftIds) {

            foreach (var item in GiftIds)
            {
                var gift = new Gift(IdProduct, item);
                iDal_Gift.AddGift(gift);
            }
        
        }
        public void UpdaeGift(int IdGift)
        {
            iDal_Gift.UpdaeGift(IdGift);
        }
    }
}
