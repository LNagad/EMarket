using EMarket.Core.Application.Helpers;
using EMarket.Core.Application.ViewModels.Users;

namespace EMarket.MiddleWares
{
    public class ValidateUserSession
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ValidateUserSession(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public bool HasUser()
        {
            //UserViewModel user = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("USER");

            //return user != null ? true : false ;

            UserViewModel userViewModel = _httpContextAccessor.HttpContext.Session.Get<UserViewModel>("user");

            if (userViewModel == null)
            {
                return false;
            }
            return true;
        }
    }
}
