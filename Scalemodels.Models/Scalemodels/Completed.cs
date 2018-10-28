using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Scalemodels.Models
{
    public class Completed : BaseModel<int>
    {
        //TODO: Seed  the items from Google Drive

        public Completed()
        {
            this.ModelShowsParticipatedIn = new List<CompletedModelShow>();

            this.UsedAftermarket = new List<CompletedAftermarket>();
        }

        public int Number { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Scale { get; set; }

        public int ManifacturerId { get; set; }
        [Required]
        public Manifacturer Manifacturer { get; set; }

        [Required]
        public string FactoryNumber { get; set; }

        public string Placement { get; set; }

        public string BestCompanyOffer { get; set; }

        public string GivenSold { get; set; }

        public string PicturesLink { get; set; }

        public string ForumsLink { get; set; }

        public string CombinesWith { get; set; }

        [Required]
        [Range(typeof(decimal), "0.00", "79228162514264337593543950335")]
        public decimal Price { get; set; }

        [Required]
        public DateTime DateOfPurchase { get; set; }

        [Required]
        public DateTime StartedOnDate { get; set; }

        [Required]
        public DateTime FinishedOnDate { get; set; }

        public ICollection<CompletedModelShow> ModelShowsParticipatedIn { get; set; }

        public ICollection<CompletedAftermarket> UsedAftermarket{ get; set; }
    }
}
