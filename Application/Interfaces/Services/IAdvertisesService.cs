using EMarket.Core.Application.ViewModels.Advertises;
using EMarket.Core.Application.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Core.Application.Interfaces.Services
{
    public interface IAdvertisesService : IGenericService<SaveAdvertisesViewModel, AdvertisesViewModel>
    {
    }
}
