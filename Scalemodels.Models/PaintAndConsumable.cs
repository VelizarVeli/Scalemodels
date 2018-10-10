﻿using System;

namespace Scalemodels.Models
{
   public class PaintAndConsumable : BaseModel<int>
    {
        public string Name { get; set; }

        public int ManifacturerId { get; set; }
        public Manifacturer Manifacturer { get; set; }

        public string ManifacturerNumber { get; set; }

        public string Coverage { get; set; }

        public decimal? Price { get; set; }

        public DateTime? DateOfPurchase { get; set; }

        public string Type { get; set; }
    }
}