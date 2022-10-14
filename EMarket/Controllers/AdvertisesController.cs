using EMarket.Core.Application.Interfaces.Services;
using EMarket.Core.Application.ViewModels.Advertises;
using Microsoft.AspNetCore.Mvc;

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
            var emptyAd = new SaveAdvertisesViewModel();
            emptyAd.Categories = await _categoryService.GetAllViewModel();

            return View("SaveAdvertise", emptyAd);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveAdvertisesViewModel vm)
        {

            if (!ModelState.IsValid)
            {
                vm.Categories = await _categoryService.GetAllViewModel();
                return View("SaveAdvertise", vm);

            }

            await _adService.AddAsync(vm);

            return RedirectToRoute(new { controller = "Advertises", action = "Index" });
        }

        public async Task<IActionResult> Edit(int Id)
        {
            
            var value = await _adService.GetViewModelById(Id);
            value.Categories = await _categoryService.GetAllViewModel();

            return View("SaveAdvertise", value);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveAdvertisesViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                vm.Categories = await _categoryService.GetAllViewModel();
                return View("SaveAdvertise", vm);
            }

            await _adService.UpdateAsync(vm);

            return RedirectToRoute(new { controller = "Advertises", action = "Index" });
        }

        public async Task<IActionResult> Delete(int Id)
        {
            var value = await _adService.GetViewModelById(Id);

            return View("Delete", value);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(SaveAdvertisesViewModel vm)
        {
            await _adService.DeleteAsync(vm);

            return RedirectToRoute(new { controller = "Advertises", action = "Index" });
        }
    }
}
