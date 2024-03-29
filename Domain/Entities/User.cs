﻿using EMarket.Core.Domain.Common;

namespace EMarket.Core.Domain.Entities
{
    public class User : AuditableBaseEntity
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Advertise>? Advertises { get; set; }

    }
}
