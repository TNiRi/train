abstract class BaseOfLocations {
    protected string title;
    protected string description;
    protected List<string> exits;
    protected List<string> curAvailability;
    public string Title {get{return title;};}
    public string TextDescription {get{return textDescription;};}
    public List<string> Txits {get{return exits;};}
    public List<string> CurAvailability {get{return curAvailability;};}
    protected static void LocationDescription() {
        Console.WriteLine($"{Title} - {TextDescription}");
    }
}