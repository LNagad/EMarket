using EMarket.Core.Application.ViewModels.Users;
using EMarket.Core.Domain.Entities;

namespace EMarket.Core.Application.Interfaces.Repositories
{
    public interface IUserRepository : IGenericRepository<User>
    {
        Task<User> LoginAsync(LoginViewModel loginVM);

        Task<User> ExistUserValidation(UserViewModel userVM);
    }
}
