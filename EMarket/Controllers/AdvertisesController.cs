using EMarket.Core.Application.Interfaces.Services;
using EMarket.Core.Application.ViewModels.Advertises;
using Microsoft.AspNetCore.Mvc;

namespace EMarket.Controllers
{
    public class AdvertisesController : Controller
    {
        private readonly IAdvertisesService _adService;
        public AdvertisesController (IAdvertisesService adService)
        {
            _adService = adService;
        }

        public IActionResult Index()
        {
            return View(new List<AdvertisesViewModel>() );
        }
        public IActionResult Create()
        {
            return View("SaveAdvertise", new SaveAdvertisesViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveAdvertisesViewModel vm)
        {
            return View("SaveAdvertise");
        }
    }
}
