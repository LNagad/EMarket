using EMarket.Core.Application.ViewModels.Category;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Core.Application.Interfaces.Services
{
    public interface IGenericService<SaveViewModel, ViewModel>
        where SaveViewModel : class 
        where ViewModel : class
    {
        Task<List<ViewModel>> GetAllViewModel();

        Task AddAsync(SaveViewModel vm);
        Task UpdateAsync(SaveViewModel vm);
        Task<SaveViewModel> GetViewModelById(int id);

        Task DeleteAsync(SaveViewModel vm);
    }
}
