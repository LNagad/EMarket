using EMarket.Core.Domain.Entities;

namespace EMarket.Core.Application.ViewModels.AdvertisePhotos
{
    public class AdPhotoViewModel
    {
        public int? Id { get; set; }
        public int? AdvertiseID { get; set; }
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }

        public Advertise? advertise { get; set; }
    }
}
