﻿using System;
using System.ComponentModel.DataAnnotations;

namespace Scalemodels.DataProcessor.Dto
{
    public class VarnishDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Manifacturer { get; set; }

        [Required]
        public decimal Price { get; set; }

        [Required]
        public DateTime DateOfPurchase { get; set; }
    }
}
