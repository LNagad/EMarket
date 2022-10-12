using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Core.Application.ViewModels.Category
{
    public class SaveCategoryViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage ="Debe introducir el nombre de la categoria")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Debe introducir una descripcion para la categoria")]
        public string Description { get; set; }
    }
}
