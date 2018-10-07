using System;

namespace Scalemodels.Models
{
    public class Varnish : BaseModel<int>
    {
        public string Name { get; set; }

        public Manifacturer Manifacturer { get; set; }

        public decimal Price { get; set; }

        public DateTime DateOfPurchase { get; set; }
    }
}
