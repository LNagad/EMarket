using EMarket.Core.Application.Interfaces.Repositories;
using EMarket.Core.Domain.Entities;
using EMarket.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EMarket.Infrastructure.Persistence.Repositories
{
    public class AdvertisePhotosRepository : GenericRepository<AdvertisesPhotos>, IAdvertisePhotosRepository
    {
        private readonly ApplicationContext _dbContext;

        public AdvertisePhotosRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<AdvertisesPhotos> GetAsync(int advertiseId)
        {
            AdvertisesPhotos? adPhotos = await _dbContext.Set<AdvertisesPhotos>()
                .FirstOrDefaultAsync(adPhotos => adPhotos.AdvertiseID == advertiseId);

            return adPhotos;
        }
    }
}
