using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelProject.ViewModel
{
    public class ItemProductPromotion
    {
        public ItemProductPromotion() { }
        public bool select { get; set; } = false;

        public string productId { get; set; }

        public string productName { get; set; }
        public string productPhoto { get; set; }

        public int Price { get; set ; }
    }

    public class ProductPromotionViewModel
    {
        public ProductPromotionViewModel() { }
        public string ProductId { get; set; }
        public List<ItemProductPromotion> listProductPromotions { get; set; } = new List<ItemProductPromotion>();
        public string Message { get; set; }

    }


    public class PricePromotionViewModel
    {
        public PricePromotionViewModel() { }
        public string eventName { get; set; }
        public int sale { get; set; }
        public DateTime StartTime { get; set; } = DateTime.Now;
        public DateTime EndTime { get; set; } = DateTime.Now ;
        public List<ItemProductPromotion> listProductPromotions { get; set; } = new List<ItemProductPromotion>();
        public string Message { get; set; }

    }
}
