using EMarket.Core.Domain.Entities;

namespace EMarket.Core.Application.ViewModels.Advertises
{
    public class AdvertisesViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public string ImageUrl { get; set; }
        public string Description { get; set; }

        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }

        public User User { get; set; }
    }
}
