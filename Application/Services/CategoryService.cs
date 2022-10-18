using EMarket.Core.Application.Helpers;
using EMarket.Core.Application.Interfaces.Repositories;
using EMarket.Core.Application.Interfaces.Services;
using EMarket.Core.Application.ViewModels.Advertises;
using EMarket.Core.Application.ViewModels.Categories;
using EMarket.Core.Application.ViewModels.Users;
using EMarket.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;

namespace EMarket.Core.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserViewModel _userViewModel;


        public CategoryService(ICategoryRepository categoryRepository, IHttpContextAccessor httpContextAccessor)
        {
            _categoryRepository = categoryRepository;
            _httpContextAccessor = httpContextAccessor;
            _userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("USER");
        }


        public async Task<SaveCategoryViewModel> AddAsync(SaveCategoryViewModel vm)
        {
            var category = new Category();
            category.Name = vm.Name;
            category.Description = vm.Description;

            category = await _categoryRepository.AddAsync(category);

            SaveCategoryViewModel categoryVM = new();

            categoryVM.Id = category.Id;
            categoryVM.Name = category.Name;
            categoryVM.Description = category.Description;

            return categoryVM;
        }

        public async Task UpdateAsync(SaveCategoryViewModel vm)
        {
            var category = await _categoryRepository.GetByIdAsync(vm.Id);
            category.Id = vm.Id;
            category.Name = vm.Name;
            category.Description = vm.Description;

            await _categoryRepository.UpdateAsync(category);

        }
        public async Task<List<CategoryViewModel>> GetAllViewModel()
        {
            var categoryList = await _categoryRepository.GetAllWithIncludeAsync(new List<string> { "Advertises" });

            return categoryList.Select(category => new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                Advertises = category.Advertises,
                ProductsQuantity = category.Advertises.Where(p => p.UserId == _userViewModel.Id).Count()
            }).ToList();

        }

        public async Task<SaveCategoryViewModel> GetViewModelById(int id)
        {
            var categoryFind = await _categoryRepository.GetByIdAsync(id);

            SaveCategoryViewModel category = new();
            category.Id = categoryFind.Id;
            category.Name = categoryFind.Name;
            category.Description = categoryFind.Description;
            //category.

            return category;
        }

        public async Task DeleteAsync(SaveCategoryViewModel vm)
        {
            var category = new Category();
            category.Id = vm.Id;

            await _categoryRepository.DeleteAsync(category);
        }


    }
}
