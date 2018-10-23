using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Scalemodels.Models
{
    public class StartedModel : BaseModel<int>
    {
        //TODO: Seed the items from Google Drive

        public string Name { get; set; }

        public string Scale { get; set; }

        public int ManifacturerId { get; set; }
        [Required]
        public Manifacturer Manifacturer { get; set; }

        [Required]
        public string FactoryNumber { get; set; }

        public string AvailableAftermarket { get; set; }

        public string InfoHowTo { get; set; }

        public int CategoryId { get; set; }
        public ModelShowCategory Category { get; set; }

        public string Place { get; set; }

        [Required]
        [Range(typeof(decimal), "0.01", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        public DateTime DateOfPurchase { get; set; }

        [Required]
        public DateTime StartingDate { get; set; }

        public DateTime FinishedOn { get; set; }

        public ICollection<PurchasedAftermarket> Aftermarket { get; set; }

        public string Info { get; set; }
    }
}
