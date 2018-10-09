using System;

namespace Scalemodels.Models
{
    public class Tool : BaseModel<int>
    {
        public string Name { get; set; }

        public int ManifacturerId { get; set; }
        public Manifacturer Manifacturer { get; set; }

        public decimal Price { get; set; }

        public DateTime DateOfPurchase { get; set; }

        public string Description { get; set; }
    }
}
