using System;

namespace Scalemodels.DataProcessor.Dto
{
    public class ModelShowDto
    {
        public DateTime Year { get; set; }

        public string Place { get; set; }

        public CategoryDto[] Categories { get; set; } = new CategoryDto[0];
    }
}
