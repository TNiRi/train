using System.Collections.Generic;

public class Location
{
    public string Name { get; set; }
    public string Description { get; set; }
    public List<IInteractable> Objects { get; private set; }
    public List<GameEventBase> Events { get; private set; }
    public Dictionary<string, Location> Exits { get; private set; }

    public Location(string name, string description)
    {
        Name = name;
        Description = description;
        Objects = new List<IInteractable>();
        Events = new List<GameEventBase>();
        Exits = new Dictionary<string, Location>();
    }

    public void AddExit(string keyword, Location target)
    {
        Exits[keyword] = target;
    }

    public void AddObject(IInteractable obj)
    {
        Objects.Add(obj);
    }

    public void AddEvent(GameEventBase evt)
    {
        Events.Add(evt);
    }
}