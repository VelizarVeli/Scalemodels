using System.ComponentModel.DataAnnotations;

namespace Scalemodels.DataProcessor.Dto
{
    public class WishListDto
    {
        [Required]
        public string Name { get; set; }

        public string Manifacturer { get; set; }

        [Required]
        public string FactoryNumber { get; set; }
    }
}
