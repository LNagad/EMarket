using EMarket.Core.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace EMarket.Core.Application.ViewModels.AdvertisePhotos
{
    public class SaveAdPhoto
    {
        public int Id { get; set; }
        public int AdvertiseID { get; set; }
        public string Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }

        public Advertise? advertise { get; set; }
    }
}
