using EMarket.Core.Application.Interfaces.Repositories;
using EMarket.Core.Application.Interfaces.Services;
using EMarket.Core.Application.ViewModels.Advertises;
using EMarket.Core.Domain.Entities;
using System.Diagnostics;
using System.Xml.Linq;

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
            Advertise ad = await _adRepo.GetByIdAsync(vm.Id);

            ad.ProductName = vm.ProductName;
            ad.Description = vm.Description;
            ad.ImageUrl = vm.ImageUrl;
            ad.Price = vm.Price;
            ad.CategoryId = vm.CategoryId;

            //ad.CategoryId = vm.CategoryId;
            //ad.UserId = vm.UserId;

            await _adRepo.UpdateAsync(ad);

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
                Price = ad.Price,
                CategoryId = ad.CategoryId,
                CategoryName = ad.Category.Name.ToString()
            }).ToList();
        }

        public async Task<List<AdvertisesViewModel>> GetAllViewModelWithFilters(AdvertisesWithFilters vm)
        {
            var adList = await _adRepo.GetAllWithIncludeAsync(new List<string> { "Category" });

            List<AdvertisesViewModel> listViewModel = adList.Select(ad => new AdvertisesViewModel
            {
                Id = ad.Id,
                Name = ad.ProductName,
                Description = ad.Description,
                ImageUrl = ad.ImageUrl,
                Price = ad.Price,
                CategoryId = ad.CategoryId,
                CategoryName = ad.Category.Name.ToString()

            }).ToList();

            if (vm.CategoryId != null)
            {
                listViewModel = listViewModel.Where(ad => ad.CategoryId == vm.CategoryId.Value).ToList();

            } 
            
            if (vm.AdvertiseName != null)
            {
                //listViewModel = listViewModel.Where(ad => ad.Name == vm.AdvertiseName).ToList();

                listViewModel = listViewModel.Where(p => p.Name.ToLower().Contains(vm.AdvertiseName.ToLower())).ToList();
            }

            return listViewModel;
        }

        public async Task<SaveAdvertisesViewModel> GetViewModelById(int id)
        {
            var ad = await _adRepo.GetByIdAsync(id);

            SaveAdvertisesViewModel adEmpty = new();

            adEmpty.Id = ad.Id;
            adEmpty.ProductName = ad.ProductName;
            adEmpty.Description = ad.Description;
            adEmpty.ImageUrl = ad.ImageUrl;
            adEmpty.Price = ad.Price;
            adEmpty.CategoryId = ad.CategoryId;

            return adEmpty;
        }

        public async Task DeleteAsync(SaveAdvertisesViewModel vm)
        {
            Advertise ad = await _adRepo.GetByIdAsync(vm.Id);
           
            await _adRepo.DeleteAsync(ad);
        }
    }
}
