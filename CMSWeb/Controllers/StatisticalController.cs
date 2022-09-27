using CMSWeb.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using BUS.Services;

using ModelProject.ViewModel;


namespace CMSWeb.Controllers
{
    public class StatisticalController : Controller
    {
        private readonly ILogger<StatisticalController> _logger;

        private readonly IBusStatistical iBusStatistical;


        public StatisticalController(ILogger<StatisticalController> logger, IBusStatistical iBusStatistical)
        {
            _logger = logger;
            this.iBusStatistical = iBusStatistical;

        }

        [Route("")]
        public IActionResult Statistical()
        {
            var viewModel = iBusStatistical.GetStatisticalViewModel();
            return View(viewModel);
        }

       


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
