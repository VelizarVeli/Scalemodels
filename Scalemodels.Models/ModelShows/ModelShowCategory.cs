namespace Scalemodels.Models
{
    public class ModelShowCategory : BaseModel<int>
    {
        public int ModelShowId { get; set; }
        public ModelShow ModelShow { get; set; }

        public string CategoryId { get; set; }

        public string CategoryName { get; set; }
    }
}
