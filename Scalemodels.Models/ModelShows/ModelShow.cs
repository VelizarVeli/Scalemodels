using System;
using System.Collections.Generic;

namespace Scalemodels.Models
{
    public class ModelShow : BaseModel<int>
    {
        public ModelShow()
        {
            this.Participants = new List<CompletedModelShow>();
            this.Categories = new List<ModelShowCategory>();
        }
        
        public DateTime Year { get; set; }

        public string Place { get; set; }

        public ICollection<CompletedModelShow> Participants { get; set; }

        public ICollection<ModelShowCategory> Categories { get; set; }
    }
}
