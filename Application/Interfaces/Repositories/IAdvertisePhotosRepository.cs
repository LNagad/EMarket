using EMarket.Core.Domain.Entities;

namespace EMarket.Core.Application.Interfaces.Repositories
{
    public interface IAdvertisePhotosRepository : IGenericRepository<AdvertisesPhotos>
    {
        Task<AdvertisesPhotos> GetAsync(int id);
    }
}
