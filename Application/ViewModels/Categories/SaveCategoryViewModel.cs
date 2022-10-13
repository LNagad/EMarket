using System.ComponentModel.DataAnnotations;

namespace EMarket.Core.Application.ViewModels.Categories
{
    public class SaveCategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe introducir el nombre de la categoria")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Debe introducir una descripcion para la categoria")]
        public string Description { get; set; }
    }
}
