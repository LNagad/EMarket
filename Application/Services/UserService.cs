using EMarket.Core.Application.Interfaces.Repositories;
using EMarket.Core.Application.Interfaces.Services;
using EMarket.Core.Application.ViewModels.Categories;
using EMarket.Core.Application.ViewModels.Users;
using EMarket.Core.Domain.Entities;

namespace EMarket.Core.Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<UserViewModel> Login(LoginViewModel loginVM)
        {
            User user = await _userRepository.LoginAsync(loginVM);

            if (user == null)
            {
                return null;
            }

            var userVM = new UserViewModel();

            userVM.Id = user.Id;
            userVM.Username = user.Username;
            userVM.Password = user.Password;
            userVM.Email = user.Email;
            userVM.Phone = user.Phone;
            userVM.FirstName = user.FirstName;
            userVM.LastName = user.LastName;

            return userVM;

        }


        public async Task<SaveUserViewModel> AddAsync(SaveUserViewModel vm)
        {
            var user = new User();
            user.Username = vm.Username;
            user.Password = vm.Password;
            user.Email = vm.Email;
            user.Phone = vm.Phone;
            user.FirstName = vm.FirstName;
            user.LastName = vm.LastName;

            user = await _userRepository.AddAsync(user);

            SaveUserViewModel userVM = new();

            userVM.Username = user.Username;
            userVM.Password = user.Password;
            userVM.Email = user.Email;
            userVM.Phone = user.Phone;
            userVM.FirstName = user.FirstName;
            userVM.LastName = user.LastName;

            return userVM;
        }

        public async Task UpdateAsync(SaveUserViewModel vm)
        {
            var user = await _userRepository.GetByIdAsync(vm.Id);
            user.Id = vm.Id;
            user.Username = vm.Username;
            user.Password = vm.Password;
            user.Email = vm.Email;
            user.Phone = vm.Phone;
            user.FirstName = vm.FirstName;
            user.LastName = vm.LastName;

            await _userRepository.UpdateAsync(user);

        }
        public async Task<List<UserViewModel>> GetAllViewModel()
        {
            var userList = await _userRepository.GetAllWithIncludeAsync(new List<string> { "Advertises" });

            return userList.Select(vm => new UserViewModel
            {
                Id = vm.Id,
                Username = vm.Username,
                Password = vm.Password,
                Email = vm.Email,
                Phone = vm.Phone,
                FirstName = vm.FirstName,
                LastName = vm.LastName

            }).ToList();

        }

        public async Task<SaveUserViewModel> GetViewModelById(int id)
        {
            var userFinded = await _userRepository.GetByIdAsync(id);

            SaveUserViewModel userRequested = new();

            userRequested.Id = userFinded.Id;
            userRequested.Username = userFinded.Username;
            userRequested.Password = userFinded.Password;
            userRequested.ConfirmPassword = userFinded.Password;
            userRequested.Email = userFinded.Email;
            userRequested.Phone = userFinded.Phone;
            userRequested.FirstName = userFinded.FirstName;
            userRequested.LastName = userFinded.LastName;
            

            return userRequested;
        }

        public async Task DeleteAsync(SaveUserViewModel vm)
        {
            var user = new User();
            user.Id = vm.Id;

            await _userRepository.DeleteAsync(user);
        }


    }
}
