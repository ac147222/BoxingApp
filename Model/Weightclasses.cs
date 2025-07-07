namespace BoxingApp.Models
{
    public class Weightclass
    {
        public int WeightclassID { get; set; }
        public string WeightclassName { get; set; }

        public Weightclass(int id, string weightclass)
        {
            WeightclassID = id;
            WeightclassName = weightclass;
        }
    }
}