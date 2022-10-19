using EMarket.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Core.Domain.Entities
{
    public class AdvertisesPhotos : AuditableBaseEntity
    {
        public int AdvertiseID { get; set; }
        public string? Image1 { get; set; }
        public string? Image2 { get; set; }
        public string? Image3 { get; set; }

        public Advertise? advertise { get; set; }
    }
}
