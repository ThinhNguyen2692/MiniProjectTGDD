using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;

using System.Collections.Generic;

using System.Linq;

using ModelProject.ViewModel;
using BUS.Services;



namespace WebsiteHomepage.Component
{
    public class HeaderViewComponent: ViewComponent
    {
        private readonly IBusShowProducts busShowProducts;
        public HeaderViewComponent(IBusShowProducts busShowProducts )
        {
            this.busShowProducts = busShowProducts;

        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var viewModel = busShowProducts.HeaderViewModel();
            return View("Defult", viewModel);
        }


    }
}
