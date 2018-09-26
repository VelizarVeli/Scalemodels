using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Scalemodels.Models.Enums;

namespace Scalemodels.Models
{
    public class AvailableModel
    {
        public AvailableModel()
        {
            this.UsedAftermarket = new List<PurchasedAftermarket>();
        }

        [Key]
        public int ModelId { get; set; }

        [Required]
        public int Scale { get; set; }

        public int ManifacturerId { get; set; }
        [Required]
        public Manifacturer Manifacturer { get; set; }

        [Required]
        public string FactoryNumber { get; set; }

        public string AvailableAftermarket { get; set; }

        public string CombinesWith { get; set; }

        public string InfoHowTo { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        public DateTime DateOfPurchase { get; set; }

        public string Info { get; set; }

        public ICollection<PurchasedAftermarket> UsedAftermarket { get; set; }
    }
}
