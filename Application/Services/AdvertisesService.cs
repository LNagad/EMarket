using EMarket.Core.Application.Helpers;
using EMarket.Core.Application.Interfaces.Repositories;
using EMarket.Core.Application.Interfaces.Services;
using EMarket.Core.Application.ViewModels.Advertises;
using EMarket.Core.Application.ViewModels.Users;
using EMarket.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using System.Diagnostics;
using System.Net.Http.Headers;
using System.Xml.Linq;

namespace EMarket.Core.Application.Services
{
    public class AdvertisesService : IAdvertisesService
    {
        private readonly IAdvertiseRepository _adRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserViewModel _userViewModel;

        public AdvertisesService(IAdvertiseRepository adRepo, IHttpContextAccessor httpContextAccessor)
        {
            _adRepo = adRepo;
            _httpContextAccessor = httpContextAccessor;
            _userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("USER");
        }


        public async Task<SaveAdvertisesViewModel> AddAsync(SaveAdvertisesViewModel vm)
        {
            var ad = new Advertise();

            ad.ProductName = vm.ProductName;
            ad.Description = vm.Description;
            ad.ImageUrl = vm.ImageUrl;
            ad.Price = vm.Price;
            ad.CategoryId = vm.CategoryId;
            ad.UserId = _userViewModel.Id; // USER

            ad = await _adRepo.AddAsync(ad);

            SaveAdvertisesViewModel adVM = new();

            adVM.Id = ad.Id;
            adVM.ProductName = ad.ProductName;
            adVM.Description = ad.Description;
            adVM.ImageUrl = ad.ImageUrl;
            adVM.Price = ad.Price;
            adVM.CategoryId = ad.CategoryId;

            return adVM;
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
            var adList = await _adRepo.GetAllWithIncludeAsync(new List<string> { "Category", "User" });

            return adList.Where(p => p.UserId == _userViewModel.Id).Select(ad => new AdvertisesViewModel
            {
                Id = ad.Id,
                Name = ad.ProductName,
                Description = ad.Description,
                ImageUrl = ad.ImageUrl,
                Price = ad.Price,
                CategoryId = ad.CategoryId,
                CategoryName = ad.Category.Name.ToString(),
                User = ad.User

            }).ToList();
        }

        public async Task<List<AdvertisesViewModel>> GetAllViewModelWithFilters(AdvertisesWithFilters vm)
        {
            var adList = await _adRepo.GetAllWithIncludeAsync(new List<string> { "Category", "User" });

            List<AdvertisesViewModel> listViewModel = adList.Where(p => p.UserId != _userViewModel.Id)
                .Select(ad => new AdvertisesViewModel
                {
                    Id = ad.Id,
                    Name = ad.ProductName,
                    Description = ad.Description,
                    ImageUrl = ad.ImageUrl,
                    Price = ad.Price,
                    CategoryId = ad.CategoryId,
                    CategoryName = ad.Category.Name.ToString(),
                    User = ad.User

                }).ToList();

            if (vm.CategoryId != null)
            {
                listViewModel = listViewModel.Where(ad => ad.CategoryId == vm.CategoryId.Value).ToList();
            }

            if (vm.AdvertiseName != null)
            {
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
            adEmpty.User = ad.User;
            adEmpty.Category = ad.Category;

            return adEmpty;
        }

        public async Task DeleteAsync(SaveAdvertisesViewModel vm)
        {
            Advertise ad = await _adRepo.GetByIdAsync(vm.Id);

            await _adRepo.DeleteAsync(ad);
        }
    }
}
