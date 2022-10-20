using EMarket.Core.Application.Interfaces.Repositories;
using EMarket.Core.Domain.Entities;
using EMarket.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EMarket.Infrastructure.Persistence.Repositories
{
    public class AdvertiseRepository : GenericRepository<Advertise>, IAdvertiseRepository
    {
        private readonly ApplicationContext _dbContext;
        public AdvertiseRepository(ApplicationContext dbContent) : base(dbContent)
        {
            _dbContext = dbContent;
        }

        public override async Task<Advertise> GetByIdAsync(int id)
        {
            Advertise ad = await _dbContext.Set<Advertise>()
                .Include(p => p.Category)
                .Include(p => p.User)
                .FirstOrDefaultAsync(ad => ad.Id == id);

            return ad;
        }
    }
}

