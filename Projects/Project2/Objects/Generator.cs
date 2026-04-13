public class Generator : IInteractable
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    
    private string _requiredItem;
    private bool _isOn;
    
    public Generator(string id, string name, string description, string requiredItem)
    {
        Id = id;
        Name = name;
        Description = description;
        _requiredItem = requiredItem;
        _isOn = false;
    }
    
    public void Interact(GameState state)
    {
        if (_isOn)
        {
            Console.WriteLine("Генератор уже работает.");
            return;
        }
        
        if (state.Inventory.Contains(_requiredItem))
        {
            _isOn = true;
            state.Inventory.Remove(_requiredItem);
            state.Flags["GeneratorOn"] = true;
            state.Flags["FuseUsed"] = true; // для квеста
            state.AddEventLog($"Вы вставили {_requiredItem} и нажали кнопку! Генератор запустился.");
            Console.WriteLine("Генератор ожил! Гул разносится по бункеру.");
            state.CheckQuests(); // триггерим квест
        }
        else
        {
            Console.WriteLine($"Генератор не включается. Нужен {_requiredItem}.");
        }
    }
}   