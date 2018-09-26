using System.ComponentModel.DataAnnotations;

namespace Scalemodels.Models
{
    public class StartedModel
    {
        public int ManifacturerId { get; set; }
        [Required]
        public Manifacturer Manifacturer { get; set; }
    }
}
