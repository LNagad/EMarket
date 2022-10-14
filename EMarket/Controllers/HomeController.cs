using EMarket.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EMarket.Controllers
{
    public class HomeController : Controller
    {
        private readonly IAdvertisesService _adService;
        private readonly ICategoryService _categoryService;

        public HomeController(IAdvertisesService adService, ICategoryService categoryService)
        {
            _adService = adService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index(int CategoryId)
        {
            ViewBag.Categories = await _categoryService.GetAllViewModel();
            return View(await _adService.GetAllViewModel());
        }

        public IActionResult Category()
        {
            return RedirectToRoute(new { controller = "Category", action = "Index" });
        }

    }
}