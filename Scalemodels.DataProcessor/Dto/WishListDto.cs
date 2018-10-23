using System.ComponentModel.DataAnnotations;

namespace Scalemodels.DataProcessor.Dto
{
    public class WishListDto : BaseDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string FactoryNumber { get; set; }
    }
}
