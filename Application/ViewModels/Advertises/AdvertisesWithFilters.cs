﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EMarket.Core.Application.ViewModels.Advertises
{
    public class AdvertisesWithFilters
    {
        public List<int>? CategoryId { get; set; }

        //public int CategoryId { get; set; }

        public string? AdvertiseName { get; set; }
    }
}
