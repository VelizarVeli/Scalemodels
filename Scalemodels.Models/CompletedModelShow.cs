namespace Scalemodels.Models
{
    public class CompletedModelShow
    {
        public int CompletedId { get; set; }
        public Completed ModelCompleted { get; set; }

        public int ModelShowId { get; set; }
        public ModelShow ModelShow { get; set; }
    }
}
