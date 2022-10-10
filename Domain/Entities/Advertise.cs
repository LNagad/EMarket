﻿using EMarket.Core.Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Core.Domain.Entities
{
    public class Advertise : AuditableBaseEntity
    {
        public string ProductName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public double Price { get; set; }

        //Id fk
        public int CategoryId { get; set; }
        public int UserId { get; set; }
        //navigation properties
        public Category Category { get; set; }
        public User User { get; set; }

    }
}
