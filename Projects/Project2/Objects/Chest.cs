using System;
using System.Collections.Generic;

public class Chest : IInteractable
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    
    private bool _isOpen;
    private List<string> _items;
    private List<IEffect> _openEffects;
    
    public Chest(string id, string name, string description, List<string> items)
    {
        Id = id;
        Name = name;
        Description = description;
        _isOpen = false;
        _items = items;
        _openEffects = new List<IEffect>();
        
        // Создаем эффекты для открытия
        foreach (var item in items)
        {
            _openEffects.Add(new AddItemEffect(item));
        }
        _openEffects.Add(new LogEffect($"Вы открыли {Name}"));
    }
    
    public void Interact(GameState state)
    {
        if (_isOpen)
        {
            Console.WriteLine($"{Name} уже открыт.");
            return;
        }
        
        _isOpen = true;
        
        foreach (var effect in _openEffects)
        {
            effect.Apply(state);
        }
        
        Console.WriteLine($"Внутри вы нашли: {string.Join(", ", _items)}");
    }
}