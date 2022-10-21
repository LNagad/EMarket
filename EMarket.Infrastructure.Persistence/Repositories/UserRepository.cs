using EMarket.Core.Application.Helpers;
using EMarket.Core.Application.Interfaces.Repositories;
using EMarket.Core.Application.ViewModels.Users;
using EMarket.Core.Domain.Entities;
using EMarket.Infrastructure.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace EMarket.Infrastructure.Persistence.Repositories
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        private readonly ApplicationContext _dbContext;
        public UserRepository(ApplicationContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }


        public override async Task<User> AddAsync(User user)
        {
            user.Password = PasswordEncryption.ComputeSha256Hash(user.Password);
            //Liskov principle // instead of using the logic we just call our father method   
            return await base.AddAsync(user);
        }

        public async Task<User> LoginAsync(LoginViewModel loginVM)
        {
            string encryptedPassword = PasswordEncryption.ComputeSha256Hash(loginVM.Password);

            User user = await _dbContext.Set<User>()
                .FirstOrDefaultAsync(user => user.Username == loginVM.Username 
                                    && user.Password == encryptedPassword);

            return user;
        }

        public async Task<User> ExistUserValidation(UserViewModel userVM)
        {

            User user = await _dbContext.Set<User>()
                .FirstOrDefaultAsync(user => user.Username == userVM.Username);

            return user;
        }
    }
}
