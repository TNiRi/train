using System.Collections.Generic;

public class Npc : IInteractable
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }

    private Dictionary<string, string> _dialogues;
    private Dictionary<string, string> _questTriggers;

    public Npc(string id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
        _dialogues = new Dictionary<string, string>();
        _questTriggers = new Dictionary<string, string>();
    }

    public void AddDialogue(string keyword, string response)
    {
        _dialogues[keyword] = response;
    }

    public void AddQuestTrigger(string itemName, string questName)
    {
        _questTriggers[itemName] = questName;
    }

    public void Interact(GameState state)
    {
        Console.WriteLine($"\n{Name}: {Description}");
        Console.WriteLine("Ты можешь спросить: 'спросить <тема>'");

        // Базовая реакция на предметы
        foreach (var trigger in _questTriggers)
        {
            if (state.Inventory.Contains(trigger.Key))
            {
                Console.WriteLine($"{Name}: А, у тебя есть {trigger.Key}! Это для {trigger.Value}.");
            }
        }
    }

    public void Talk(string topic, GameState state)
    {
        if (_dialogues.ContainsKey(topic))
        {
            Console.WriteLine($"{Name}: {_dialogues[topic]}");
        }
        else
        {
            Console.WriteLine($"{Name}: Я не знаю ничего про '{topic}'");
        }
    }
    
    public List<string> GetAvailableTopics()
    {
        return new List<string>(_dialogues.Keys);
    }
}