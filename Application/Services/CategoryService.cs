using EMarket.Core.Application.Interfaces.Repositories;
using EMarket.Core.Application.Interfaces.Services;
using EMarket.Core.Application.ViewModels.Category;
using EMarket.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Core.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        public async Task AddAsync(SaveCategoryViewModel vm)
        {
            var category = new Category();
            category.Name = vm.Name;
            category.Description = vm.Description;

            await _categoryRepository.AddAsync(category);
        }

        public async Task UpdateAsync(SaveCategoryViewModel vm)
        {
            var category = new Category();
            category.Id = vm.Id;
            category.Name = vm.Name;
            category.Description = vm.Description;

            await _categoryRepository.UpdateAsync(category);

        }
        public async Task<List<CategoryViewModel>> GetAllViewModel()
        {
            var categoryList = await _categoryRepository.GetAllWithIncludeAsync(new List<string>  { "Advertises" });

            return categoryList.Select(category => new CategoryViewModel
            {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                Advertises = category.Advertises
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
