using System.Collections.Generic;

public class GameState
{
    public int Health { get; set; }
    public List<string> Inventory { get; private set; }
    public Dictionary<string, bool> Flags { get; private set; }
    public int TurnCount { get; set; }
    public List<string> EventLog { get; private set; }
    public Location CurrentLocation { get; set; }
    public List<Quest> Quests { get; private set; }
    public Dictionary<string, Location> AllLocations { get; private set; }

    public GameState(Location startLocation)
    {
        Health = 100;
        Inventory = new List<string>();
        Flags = new Dictionary<string, bool>();
        TurnCount = 0;
        EventLog = new List<string>();
        CurrentLocation = startLocation;
        Quests = new List<Quest>();
        AllLocations = new Dictionary<string, Location>();
        AllLocations[startLocation.Name] = startLocation;

        AddEventLog("Игра началась");
    }

    public void AddEventLog(string message)
    {
        EventLog.Add($"[Ход {TurnCount}] {message}");
        Console.WriteLine($"[Ход {TurnCount}] {message}");
        CheckQuests();  // ← ИСПРАВЛЕНО
    }

    // Методы для работы с квестами
    public void AddQuest(Quest quest)
    {
        Quests.Add(quest);
    }

    public void CheckQuests()
    {
        foreach (var quest in Quests)
        {
            quest.CheckCompletion(this);
        }
    }
    public void RegisterLocation(Location location)
    {
        if (!AllLocations.ContainsKey(location.Name))
        {
            AllLocations[location.Name] = location;
        }
    }
}