using DAL;
using CMSWeb.Models;

namespace CMSWeb.ViewModels.GiftViewModels
{
    public class ItemGift
    {
        public string TypeId { get; set; }
        public string TypeName { get; set; }
        public List<GiftModel> Products { get; set; }
    }

   


    public class GiftViewModel
    {
        public GiftViewModel() { }
        public ItemGift itemGiftProductPromotions { get; set; }
        public ItemGift giftProduct { get; set; }

        public bool Message { get; set; }

    }
}
