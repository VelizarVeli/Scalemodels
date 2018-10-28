using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Scalemodels.Models
{
    public class PurchasedAftermarket : BaseModel<int>
    {
        public PurchasedAftermarket()
        {
            this.AvailableModels = new List<ModelsAftermarket>();

            this.CompletedModels = new List<CompletedAftermarket>();
        }

        [Required]
        public string ProductName { get; set; }

        public int ManifacturerId { get; set; }
        [Required]
        public Manifacturer Manifacturer { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        public DateTime DateOfPurchase { get; set; }

        public string FactoryNumber { get; set; }

        public string Category { get; set; }

        public string Placement { get; set; }

        public ICollection<ModelsAftermarket> AvailableModels { get; set; }

        public ICollection<CompletedAftermarket> CompletedModels { get; set; }
    }
}
