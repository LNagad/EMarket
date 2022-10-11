using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Core.Application.Interfaces.Repositories
{
    public interface IGenericRepository<Entity> where Entity : class
    {
        Task AddAsync(Entity entity);

        Task UpdateAsync(Entity entity);

        Task DeleteAsync(Entity entity);

        Task<List<Entity>> GetAllAsync(Entity entity);

        Task<List<Entity>> GetAllWithIncludeAsync(List<string> properties);

        Task<Entity> GetByIdAsync(int id);
    }
}
