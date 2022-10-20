using EMarket.Core.Application.ViewModels.Categories;
using EMarket.Core.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace EMarket.Core.Application.ViewModels.Advertises
{
    public class SaveAdvertisesViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Debe introducir el nombre del anuncio")]
        [DataType(DataType.Text)]
        public string ProductName { get; set; }

        [Required(ErrorMessage = "Debe introducir una descripcion al anuncio")]
        [DataType(DataType.Text)]
        public string Description { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Debe introducir el precio del anuncio")]
        [DataType(DataType.Currency)]
        public double? Price { get; set; }
        public string? ImageUrl { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile? File1 { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile? File2 { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile? File3 { get; set; }

        [DataType(DataType.Upload)]
        public IFormFile? File4 { get; set; }

        public DateTime? date { get; set; }

        

        //---------------- Id fk ---------------
        [Range(1, int.MaxValue, ErrorMessage = "Debe seleccionar a que categoria pertenece el anuncio")]
        public int? CategoryId { get; set; }
        public int? UserId { get; set; }
        

        //Navigation properties
        public ICollection<CategoryViewModel>? Categories { get; set; }

        public User? User { get; set; }
        public Category? Category { get; set; }


    }
}
