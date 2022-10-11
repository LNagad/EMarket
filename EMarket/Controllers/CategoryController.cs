using EMarket.Core.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace EMarket.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService _categoryService;

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _categoryService.GetAllViewModel());
        }
    }
}
