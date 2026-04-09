using System.Collections.Generic;

public class GameState
{
    public int Health { get; set; }
    public List<string> Inventory { get; private set; }
    public Dictionary<string, bool> Flags { get; private set; }
    public int TurnCount { get; set; }
    public List<string> EventLog { get; private set; }
    public Location CurrentLocation { get; set; }

    public GameState(Location startLocation)
    {
        Health = 100;
        Inventory = new List<string>();
        Flags = new Dictionary<string, bool>();
        TurnCount = 0;
        EventLog = new List<string>();
        CurrentLocation = startLocation;

        AddEventLog("Игра началась");
    }

    public void AddEventLog(string message)
    {
        EventLog.Add($"[Ход {TurnCount}] {message}");
        Console.WriteLine($"[Ход {TurnCount}] {message}");
    }
}