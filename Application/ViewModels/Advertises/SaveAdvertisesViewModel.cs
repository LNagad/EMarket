using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Core.Application.ViewModels.Advertises
{
    public class SaveAdvertisesViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe introducir el nombre del anuncio")]
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }

        //Id fk
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}
