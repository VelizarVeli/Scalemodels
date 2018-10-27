using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Scalemodels.Models
{
    public class PurchasedAftermarket : BaseModel<int>
    {
        //TODO: Update the information with the newly purchased items

        public PurchasedAftermarket()
        {
            this.Models = new List<ModelsAftermarket>();
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

        public ICollection<ModelsAftermarket> Models { get; set; }

        public ICollection<CompletedAftermarket> CompletedModels { get; set; }
    }
}
