using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EMarket.Core.Application.Services;
using EMarket.Core.Application.ViewModels.Category;
using EMarket.Core.Domain.Entities;

namespace EMarket.Core.Application.ViewModels.Advertises
{
    public class SaveAdvertisesViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe introducir el nombre del anuncio")]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Debe introducir una descripcion al anuncio")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Debe colocar una imagen al anuncio")]
        public string ImageUrl { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe introducir el precio del anuncio")]
        public double Price { get; set; }

        //Id fk
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar a que categoria pertenece el anuncio")]
        public int CategoryId { get; set; }
        public int UserId { get; set; }
    }
}
