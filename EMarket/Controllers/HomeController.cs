using EMarket.Core.Application.Interfaces.Services;
using EMarket.Core.Application.ViewModels.Advertises;
using EMarket.MiddleWares;
using Microsoft.AspNetCore.Mvc;

namespace EMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAdvertisesService _adService;
        private readonly ICategoryService _categoryService;
        private readonly ValidateUserSession _validateUserSession;

        public HomeController(IAdvertisesService adService, ICategoryService categoryService, ValidateUserSession validateUserSession)
        {
            _adService = adService;
            _categoryService = categoryService;
            _validateUserSession = validateUserSession;
        }

        public async Task<IActionResult> Index(AdvertisesWithFilters vm)
        {
            AdvertisesWithFilters vmx = new();
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            ViewBag.Categories = await _categoryService.GetAllViewModel();

            return View(await _adService.GetAllViewModelWithFilters(vm));
        }

        public IActionResult Category()
        {
            if (!_validateUserSession.HasUser())
            {
                return RedirectToRoute(new { controller = "User", action = "Index" });
            }

            return RedirectToRoute(new { controller = "Category", action = "Index" });
        }

    }
}