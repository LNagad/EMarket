using EMarket.Core.Application.Interfaces.Repositories;
using EMarket.Core.Domain.Entities;
using EMarket.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Infrastructure.Persistence.Repositories
{
    public class AdvertiseRepository : GenericRepository<Advertise>, IAdvertiseRepository
    {
        private readonly ApplicationContext _dbContext;
        public AdvertiseRepository(ApplicationContext dbContent) :base(dbContent)
        {
            _dbContext = dbContent;
        }

    }
}
