using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Scalemodels.Models
{
    public class ModelShow
    {
        public ModelShow()
        {
            this.Participants = new List<CompletedModelShow>();
            this.Categories = new List<ModelShowCategory>();
        }

        [Key]
        public int Id { get; set; }

        public DateTime Year { get; set; }

        public string Place { get; set; }

        public ICollection<CompletedModelShow> Participants { get; set; }

        public ICollection<ModelShowCategory> Categories { get; set; }
    }
}
