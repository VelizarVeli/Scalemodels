using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Scalemodels.Models.Enums;

namespace Scalemodels.Models
{
   public class PurchasedAftermarket
    {
        public PurchasedAftermarket()
        {
            this.Models = new List<ModelsAftermarket>();
        }

        [Key]
        public int ItemId { get; set; }

        [Required]
        public string ProductName { get; set; }

        public Manifacturer Manifacturer { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        public DateTime DateOfPurchase { get; set; }

        public string FactoryNumber { get; set; }

        public Category Category { get; set; }

        public string Placement { get; set; }

        public ICollection<ModelsAftermarket> Models { get; set; }
    }
}
