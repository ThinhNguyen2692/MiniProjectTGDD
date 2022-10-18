using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using WebsiteHomepage.Models;
using BUS;
using ModelProject;
using ModelProject.ViewModel;
using BUS.Services;
using Microsoft.Extensions.Caching.Memory;

namespace WebsiteHomepage.Controllers
{
    public class HomeController : Controller
    {
        private readonly IBusShowProducts busShowProducts;
        private readonly ILogger<HomeController> _logger;
        private readonly IMemoryCache memoryCache;



        public HomeController(ILogger<HomeController> logger, IBusShowProducts busShowProducts, IMemoryCache memoryCache)
        {
            this.busShowProducts = busShowProducts; 
            _logger = logger;
            this.memoryCache = memoryCache;
        }

        public IActionResult Index()
        {
            //HomeController viewModel;
            HomeViewModel viewModel ;
            // Look for cache key.
            if (!memoryCache.TryGetValue("HomeProduct", out viewModel))
            {
               // Key not in cache, so get data.
              viewModel = busShowProducts.GetHomeProduct();

                //Set cache options.
                var cacheEntryOptions = new MemoryCacheEntryOptions()
                    // Keep in cache for this time, reset time if accessed.
                    .SetSlidingExpiration(TimeSpan.FromMinutes(1));

//                Save data in cache.
               memoryCache.Set<HomeViewModel>("HomeProduct", viewModel, cacheEntryOptions);

            }


            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            HomeViewModel viewModel = busShowProducts.GetHomeProduct();
            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}