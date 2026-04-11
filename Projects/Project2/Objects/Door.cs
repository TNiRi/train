public class Door : IInteractable
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    
    private string _requiredItem;
    private Location _targetLocation;
    private bool _isOpen;
    
    public Door(string id, string name, string description, string requiredItem, Location targetLocation)
    {
        Id = id;
        Name = name;
        Description = description;
        _requiredItem = requiredItem;
        _targetLocation = targetLocation;
        _isOpen = false;
    }
    
    public void Interact(GameState state)
    {
        if (_isOpen)
        {
            Console.WriteLine($"Дверь уже открыта. Вы можете пройти через нее.");
            return;
        }
        
        if (state.Inventory.Contains(_requiredItem))
        {
            _isOpen = true;
            // Добавляем переход в текущую локацию
            state.CurrentLocation.AddExit("дверь", _targetLocation);
            state.AddEventLog($"Вы открыли {Name} с помощью {_requiredItem}");
            Console.WriteLine($"Вы использовали {_requiredItem} и открыли дверь! Теперь можно пройти через нее командой 'go дверь'");
        }
        else
        {
            Console.WriteLine($"Дверь заперта. Нужен предмет: {_requiredItem}");
        }
    }
}