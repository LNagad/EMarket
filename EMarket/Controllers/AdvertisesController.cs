using EMarket.Core.Application.Interfaces.Services;
using EMarket.Core.Application.ViewModels.Advertises;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace EMarket.Controllers
{
    public class AdvertisesController : Controller
    {
        private readonly IAdvertisesService _adService;
        private readonly ICategoryService _categoryService;
        public AdvertisesController(IAdvertisesService adService, ICategoryService categoryService)
        {
            _adService = adService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _adService.GetAllViewModel());
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _categoryService.GetAllViewModel();

            return View("SaveAdvertise", new SaveAdvertisesViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveAdvertisesViewModel vm)
        {
            ViewBag.Categories = await _categoryService.GetAllViewModel();

            if (!ModelState.IsValid)
            {
                return View("SaveAdvertise", vm);

            }

            await _adService.AddAsync(vm);

            return RedirectToRoute(new { controller="Advertises", action="Index"});
        }
    }
}
