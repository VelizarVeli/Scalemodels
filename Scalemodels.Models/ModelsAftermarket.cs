using System.ComponentModel.DataAnnotations;

namespace Scalemodels.Models
{
    public class ModelsAftermarket
    {
        public int ModelId { get; set; }
        [Required]
        public AvailableModel Model { get; set; }

        public int AftermarketId { get; set; }
        [Required]
        public PurchasedAftermarket Aftermarket { get; set; }
    }
}
