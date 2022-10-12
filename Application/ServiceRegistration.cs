﻿using EMarket.Core.Application.Interfaces.Services;
using EMarket.Core.Application.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Core.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationLayer(this IServiceCollection services, IConfiguration configuration)
        {

            #region services
            services.AddTransient<ICategoryService, CategoryService>();
            services.AddTransient<IAdvertisesService, AdvertisesService>();

            //services.AddTransient(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            #endregion
        }

    }
}