using EMarket.Core.Application.Interfaces.Services;
using EMarket.Core.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace EMarket.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            #region services
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IAdvertisesService, AdvertisesService>();
            services.AddTransient<IAdvertisePhotosService, AdvertisePhotosService>();
            #endregion
        }
    }
}
