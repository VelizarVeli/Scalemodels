using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Scalemodels.Models
{
    public class Manifacturer : BaseModel<int>
    {
        public Manifacturer()
        {
            this.AvailableModels = new List<AvailableModel>();
            this.CompletedModels = new List<Completed>();
            this.PurchasedAftermarketItems = new List<PurchasedAftermarket>();
            this.StartedModels = new List<StartedModel>();
            this.WishListModels = new List<WishList>();
        }

        [Required]
        public string Name { get; set; }

        public ICollection<AvailableModel> AvailableModels { get; set; }

        public ICollection<Completed> CompletedModels { get; set; }

        public ICollection<PurchasedAftermarket> PurchasedAftermarketItems { get; set; }

        public ICollection<StartedModel> StartedModels { get; set; }

        public ICollection<WishList> WishListModels { get; set; }
    }
}
