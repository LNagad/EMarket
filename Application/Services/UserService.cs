using EMarket.Core.Application.Interfaces.Repositories;

namespace EMarket.Core.Application.Services
{
    public class UserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task AddAsync()
        {

        }
    }
}
