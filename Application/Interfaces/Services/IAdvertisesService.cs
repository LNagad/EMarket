using EMarket.Core.Application.ViewModels.Advertises;

namespace EMarket.Core.Application.Interfaces.Services
{
    public interface IAdvertisesService : IGenericService<SaveAdvertisesViewModel, AdvertisesViewModel>
    {
        Task UpdateAsync(SaveAdvertisesViewModel vm);
    }
}
