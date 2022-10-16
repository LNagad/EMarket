using EMarket.Core.Application.ViewModels.Users;

namespace EMarket.Core.Application.Interfaces.Services
{
    public interface IUserService : IGenericService<SaveUserViewModel, UserViewModel>
    {
        Task<UserViewModel> Login(LoginViewModel loginVM);
    }
}
