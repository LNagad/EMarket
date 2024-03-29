﻿using EMarket.Core.Domain.Entities;

namespace EMarket.Core.Application.ViewModels.Categories
{
    public class CategoryViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public int ProductsQuantity { get; set; }
        public ICollection<Advertise> Advertises { get; set; }
    }
}
