using System;

namespace Scalemodels.DataProcessor.Dto
{
    public class ToolDto : BaseDto
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public DateTime DateOfPurchase { get; set; }

        public string Description { get; set; }
    }
}
