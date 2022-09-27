using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelProject.ViewModel;

namespace BUS.Services
{
    public interface IBusPromotion
    {
        public ProductPromotionViewModel GetProductPromotionViewModel();
        public ProductPromotionViewModel AddGift(ProductPromotionViewModel viewModel);
        public PricePromotionViewModel GetPricePromotionViewModel();
        public PricePromotionViewModel AddEvent(PricePromotionViewModel viewModel);
    }
}
