using System.ComponentModel.DataAnnotations;

namespace Scalemodels.Models
{
    public abstract class BaseModel<T>
    {
        [Key]
        public T Id { get; set; }
    }
}
