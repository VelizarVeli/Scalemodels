using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Scalemodels.Models
{
    public class Completed : BaseModel<int>
    {
        public Completed()
        {
            this.ModelShowsParticipatedIn = new List<CompletedModelShow>();
        }

        [Required]
        public string Name { get; set; }

        [Required]
        public int Scale { get; set; }

        public int ManifacturerId { get; set; }
        [Required]
        public Manifacturer Manifacturer { get; set; }

        [Required]
        public string FactoryNumber { get; set; }

        public string Placement { get; set; }

        public string BestCompanyOffer { get; set; }

        public ICollection<CompletedModelShow> ModelShowsParticipatedIn { get; set; }
    }
}
