using EMarket.Core.Application.Helpers;
using EMarket.Core.Application.Interfaces.Repositories;
using EMarket.Core.Application.Interfaces.Services;
using EMarket.Core.Application.ViewModels.AdvertisePhotos;
using EMarket.Core.Application.ViewModels.Advertises;
using EMarket.Core.Application.ViewModels.Categories;
using EMarket.Core.Application.ViewModels.Users;
using EMarket.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using static System.Net.Mime.MediaTypeNames;

namespace EMarket.Core.Application.Services
{
    public class AdvertisePhotosService : IAdvertisePhotosService
    {
        private readonly IAdvertisePhotosRepository _adRepo;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly UserViewModel _userViewModel;


        public AdvertisePhotosService(IAdvertisePhotosRepository adRepo, IHttpContextAccessor httpContextAccessor)
        {
            _adRepo = adRepo;
            _httpContextAccessor = httpContextAccessor;
            _userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("USER");
        }


        public async /*Task<SaveAdPhoto>*/ Task AddAsync(SaveAdPhoto vm)
        {
            var adPhoto = new AdvertisesPhotos();
            adPhoto.Image1 = vm.Image1;
            adPhoto.Image2 = vm.Image2;
            adPhoto.Image3 = vm.Image3;
            adPhoto.AdvertiseID = vm.AdvertiseID;

            await _adRepo.AddAsync(adPhoto);

        }

        public async Task UpdateAsync(SaveAdPhoto vm)
        {
            var adPhoto = await _adRepo.GetByIdAsync(vm.Id);
            adPhoto.Image1 = vm.Image1;
            adPhoto.Image2 = vm.Image2;
            adPhoto.Image3 = vm.Image3;

            await _adRepo.UpdateAsync(adPhoto);
        }
        public async Task<List<AdPhotoViewModel>> GetAllViewModel()
        {
            var adPhotoList = await _adRepo.GetAllWithIncludeAsync(new List<string> { "advertise" });

            return adPhotoList.Select(photo => new AdPhotoViewModel
            {
                Id = photo.Id,
                Image1 = photo.Image1,
                Image2 = photo.Image2,
                Image3 = photo.Image3,
                AdvertiseID = photo.AdvertiseID,
            }).ToList();
        }

        public async Task<SaveAdPhoto> GetViewModelById(int id)
        {
            var adPhotosFinded = await _adRepo.GetByIdAsync(id);

            SaveAdPhoto adPhotoEmpty = new();

            adPhotoEmpty.Id = adPhotosFinded.Id;
            adPhotoEmpty.Image1 = adPhotosFinded.Image1;
            adPhotoEmpty.Image2 = adPhotosFinded.Image2;
            adPhotoEmpty.Image3 = adPhotosFinded.Image3;

            return adPhotoEmpty;
        }

        public async Task<AdPhotoViewModel> GetAsync(int advertiseId)
        {
            AdvertisesPhotos adPhotosfounded = await _adRepo.GetAsync(advertiseId);

            AdPhotoViewModel myAd = new();

            myAd.Id = adPhotosfounded.Id;
            myAd.AdvertiseID = adPhotosfounded.AdvertiseID;
            myAd.Image1 = adPhotosfounded.Image1 == null ? "" : adPhotosfounded.Image1;
            myAd.Image2 = adPhotosfounded.Image2 == null ? "" : adPhotosfounded.Image2;
            myAd.Image3 = adPhotosfounded.Image3 == null ? "" : adPhotosfounded.Image3;

            return myAd;
        }

        public async Task DeleteAsync(SaveAdPhoto vm)
        {
            //    var category = new Category();
            //    category.Id = vm.Id;

            //    await _categoryRepository.DeleteAsync(category);
            //}

        }
    }
}
