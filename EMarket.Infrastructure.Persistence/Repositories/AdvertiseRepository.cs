using EMarket.Core.Application.Interfaces.Repositories;
using EMarket.Core.Domain.Entities;
using EMarket.Infrastructure.Persistence.Contexts;

namespace EMarket.Infrastructure.Persistence.Repositories
{
    public class AdvertiseRepository : GenericRepository<Advertise>, IAdvertiseRepository
    {
        private readonly ApplicationContext _dbContext;
        public AdvertiseRepository(ApplicationContext dbContent) : base(dbContent)
        {
            _dbContext = dbContent;
        }

    }
}
