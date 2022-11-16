using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelProject.ViewModel;
using BUS.Services;
using ModelProject.Models;

namespace VueApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VueController : ControllerBase
    {
        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IBusShowProducts busShowProducts;
        private readonly IBusBands busBrands;
        private readonly IBusProductType busProductType;
        public VueController(ILogger<WeatherForecastController> logger, IBusShowProducts busShowProducts, IBusBands busBrands, IBusProductType busProductType)
        {
            _logger = logger;
            this.busShowProducts = busShowProducts;
            this.busBrands = busBrands;
            this.busProductType = busProductType;
        }

        [Route("api/GetBrands")]
        [HttpGet]
        public IEnumerable<ShowBrandsViewModel> GetBrands()
        {
            var data = busBrands.GetProductBrands();
            return data;
        }

        [Route("api/GetType")]
        [HttpGet]
        public IEnumerable<ListProductTypeViewModel> GetType()
        {
            var data = busProductType.ReadAll();
            return data;
        }
    }
}
