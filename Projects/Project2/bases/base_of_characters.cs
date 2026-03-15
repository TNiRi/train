abstract class BaseOfCharacters {
    protected string name;
    protected string description;
    protected string status;
    protected string curLocation;
    protected List<string> curAvailability;
    public string Title {get{return title;};}
    public string TextDescription {get{return textDescription;};}
    public List<string> Txits {get{return exits;};}
    public List<string> CurAvailability {get{return curAvailability;};}
    protected static void LocationDescription() {
        Console.WriteLine($"{Title} - {TextDescription}");
    }
}