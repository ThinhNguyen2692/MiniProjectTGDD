using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;

using System.Linq;

using ModelProject.ViewModel;
using BUS.Services;

namespace WebsiteHomepage.Component
{
    public class ShowProductSuggestionsViewComponent : ViewComponent
    {
        private readonly IBusShowProducts busShowProducts;
        private IMemoryCache cache;
        public ShowProductSuggestionsViewComponent(IBusShowProducts busShowProducts, IMemoryCache cache)
        {
            this.busShowProducts = busShowProducts;
            this.cache = cache;
        }

        public async Task<IViewComponentResult> InvokeAsync(string brands)
        {
            var viewModel = busShowProducts.GetProductSuggestions(brands);

            return View("Default", viewModel);
        }
    }
}
