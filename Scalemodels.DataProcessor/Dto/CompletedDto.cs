using System.ComponentModel.DataAnnotations;
using Scalemodels.Models;

namespace Scalemodels.DataProcessor.Dto
{
    public class CompletedDto : BaseDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public int Scale { get; set; }

        [Required]
        public string FactoryNumber { get; set; }

        public string Placement { get; set; }

        public string BestCompanyOffer { get; set; }

        //TODO: Add all the properties from the Sheet
    }
}