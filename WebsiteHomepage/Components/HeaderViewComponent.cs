using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using System.Collections.Generic;

using System.Linq;

using ModelProject.ViewModel;
using BUS.Services;

namespace WebsiteHomepage.Component
{
    public class HeaderViewComponent: ViewComponent
    {
        private readonly IBusShowProducts busShowProducts;
        private IMemoryCache cache;
        public HeaderViewComponent(IBusShowProducts busShowProducts, IMemoryCache cache)
        {
            this.busShowProducts = busShowProducts;
            this.cache = cache;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            HeaderViewModel viewModel;
            // Look for cache key.
            if (!cache.TryGetValue("menu", out viewModel))
            {
                // Key not in cache, so get data.
                viewModel = busShowProducts.HeaderViewModel();
                // Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromMinutes(30));
                // Save data in cache.
                cache.Set<HeaderViewModel>("menu", viewModel, cacheEntryOptions); 
            }
            return View("Defult", viewModel);
        }
    }
}
