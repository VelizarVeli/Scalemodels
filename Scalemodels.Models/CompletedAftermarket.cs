using System.ComponentModel.DataAnnotations;

namespace Scalemodels.Models
{
    public class CompletedAftermarket : BaseModel<int>
    {
        public int ModelId { get; set; }
        [Required]
        public Completed Model { get; set; }

        public int AftermarketId { get; set; }
        [Required]
        public PurchasedAftermarket Aftermarket { get; set; }
    }
}
