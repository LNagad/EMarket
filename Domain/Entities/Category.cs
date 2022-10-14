using EMarket.Core.Domain.Common;

namespace EMarket.Core.Domain.Entities
{
    public class Category : AuditableBaseEntity
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public ICollection<Advertise> Advertises { get; set; }
    }
}
