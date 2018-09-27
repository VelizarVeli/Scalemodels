using System.ComponentModel.DataAnnotations;

namespace Scalemodels.DataProcessor.Dto
{
    public class ManifacturerDto
    {
        [Required]
        public string Name { get; set; }
    }
}
