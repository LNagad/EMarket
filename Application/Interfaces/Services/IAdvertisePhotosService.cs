using EMarket.Core.Application.ViewModels.AdvertisePhotos;
using EMarket.Core.Application.ViewModels.Categories;

namespace EMarket.Core.Application.Interfaces.Services
{
    public interface IAdvertisePhotosService 
    {
        Task AddAsync(SaveAdPhoto vm);
        Task<List<AdPhotoViewModel>> GetAllViewModel();

        Task<SaveAdPhoto> GetViewModelById(int id);

        Task<AdPhotoViewModel> GetAsync(int advertiseId);

        Task UpdateAsync(SaveAdPhoto vm);
    }
}
