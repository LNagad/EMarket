using EMarket.Core.Application.Interfaces.Repositories;
using EMarket.Core.Application.Interfaces.Services;
using EMarket.Core.Application.ViewModels.Advertises;
using EMarket.Core.Application.ViewModels.Category;
using EMarket.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Core.Application.Services
{
    public class AdvertisesService : IAdvertisesService
    {
        private readonly IAdvertiseRepository _adRepo;

        public AdvertisesService(IAdvertiseRepository adRepo)
        {
            _adRepo = adRepo;
        }


        public async Task AddAsync(SaveAdvertisesViewModel vm)
        {
            var ad = new Advertise();
            ad.ProductName = vm.ProductName;
            ad.Description = vm.Description;
            ad.ImageUrl = vm.ImageUrl;
            ad.Price = vm.Price;
            ad.CategoryId = vm.CategoryId;
            ad.UserId = null;

            await _adRepo.AddAsync(ad);
        }

        public async Task UpdateAsync(SaveAdvertisesViewModel vm)
        {
            //var category = new Category();
            //category.Id = vm.Id;
            //category.Name = vm.Name;
            //category.Description = vm.Description;

            //await _adRepo.UpdateAsync(category);

        }
        public async Task<List<AdvertisesViewModel>> GetAllViewModel()
        {
            var adList = await _adRepo.GetAllWithIncludeAsync(new List<string> { "Category" });

            return adList.Select(ad => new AdvertisesViewModel
            {
                Id = ad.Id,
                Name = ad.ProductName,
                Description = ad.Description,
                ImageUrl = ad.ImageUrl,
                Price = ad.Price
            }).ToList();
        }

        public async Task<SaveAdvertisesViewModel> GetViewModelById(int id)
        {
            //var categoryFind = await _adRepo.GetByIdAsync(id);

            //SaveAdvertisesViewModel category = new();
            //category.Id = categoryFind.Id;
            //category.Name = categoryFind.Name;
            //category.Description = categoryFind.Description;
            ////category.

            //return category;
            return null;
        }

        public async Task DeleteAsync(SaveAdvertisesViewModel vm)
        {
            //var category = new Category();
            //category.Id = vm.Id;

            //await _adRepo.DeleteAsync(category);
        }


    }
}
