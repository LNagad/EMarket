using EMarket.Core.Application.Interfaces.Services;
using EMarket.Core.Application.ViewModels.Category;
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

        public IActionResult Create()
        {
            return View("SaveCategory", new SaveCategoryViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> Create(SaveCategoryViewModel vm)
        {
            if(!ModelState.IsValid)
            {
                return View("SaveCategory", vm);
            }

            await _categoryService.AddAsync(vm);

            return RedirectToRoute(new { controller = "Category", action = "Index"});
        }

        public async Task<IActionResult> Edit(int Id)
        {
            return View("SaveCategory", await _categoryService.GetViewModelById(Id));
        }

        [HttpPost]
        public async Task<IActionResult> Edit(SaveCategoryViewModel vm)
        {
            if (!ModelState.IsValid)
            {
                return View("SaveCategory", vm);
            }

            await _categoryService.UpdateAsync(vm);

            return RedirectToRoute(new { controller = "Category", action = "Index" });
        }

        public async Task<IActionResult> Delete(int Id)
        {
            return View("Delete", await _categoryService.GetViewModelById(Id));
        }

        [HttpPost]
        public async Task<IActionResult> Delete(SaveCategoryViewModel vm)
        {

            await _categoryService.DeleteAsync(vm);

            return RedirectToRoute(new { controller = "Category", action = "Index" });
        }
    }
}
