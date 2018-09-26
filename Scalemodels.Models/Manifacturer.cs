using System.Collections.Generic;

namespace Scalemodels.Models
{
   public class Manifacturer
    {
        public Manifacturer()
        {
            this.AvailableModels = new List<AvailableModel>();
            this.CompletedModels = new List<Completed>();
            this.PurchasedAftermarketItems = new List<PurchasedAftermarket>();
            this.StartedModels = new List<StartedModel>();
        }

        public int ManifacturerId { get; set; }

        public string Name { get; set; }

        public ICollection<AvailableModel> AvailableModels { get; set; }

        public ICollection<Completed> CompletedModels { get; set; }

        public ICollection<PurchasedAftermarket> PurchasedAftermarketItems { get; set; }

        public ICollection<StartedModel> StartedModels { get; set; }
    }
}
