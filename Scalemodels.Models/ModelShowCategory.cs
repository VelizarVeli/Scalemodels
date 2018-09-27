using System.ComponentModel.DataAnnotations;

namespace Scalemodels.Models
{
    public class ModelShowCategory
    {
        [Key]
        public int Id { get; set; }

        public string CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
