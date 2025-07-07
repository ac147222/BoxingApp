public class Weightclasses
{
    private int weightclassID;
    private string? weightclass;

    public Weightclasses(int weightclassID, string? weightclass)
    {
        this.weightclassID = weightclassID;
        this.weightclass = weightclass;
    }

    public object WeightclassesID { get; internal set; }
    public object WeightclassesName { get; internal set; }
}