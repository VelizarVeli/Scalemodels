using System.ComponentModel.DataAnnotations;

namespace Scalemodels.DataProcessor.Dto
{
    public class ManifacturerDto
    {
        [Required]
        public string Manifacturer { get; set; }
    }
}
