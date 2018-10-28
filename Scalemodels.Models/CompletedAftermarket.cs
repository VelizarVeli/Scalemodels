using System.ComponentModel.DataAnnotations;

namespace Scalemodels.Models
{
    public class CompletedAftermarket : BaseModel<int>
    {
        public int CompletedModelId { get; set; }
        [Required]
        public Completed Model { get; set; }

        public int UsedAftermarketId { get; set; }
        [Required]
        public PurchasedAftermarket Aftermarket { get; set; }
    }
}
