public class LockedCrate : IInteractable
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }

    private string _requiredItem;
    private string _rewardItem;
    private bool _isOpen;

    public LockedCrate(string id, string name, string description, string requiredItem, string rewardItem)
    {
        Id = id;
        Name = name;
        Description = description;
        _requiredItem = requiredItem;
        _rewardItem = rewardItem;
        _isOpen = false;
    }

    public void Interact(GameState state)
    {
        if (_isOpen)
        {
            Console.WriteLine($"{Name} уже взломан.");
            return;
        }

        if (state.Inventory.Contains(_requiredItem))
        {
            _isOpen = true;
            state.Inventory.Remove(_requiredItem);
            state.Inventory.Add(_rewardItem);
            state.AddEventLog($"Ты использовал {_requiredItem} и взломал {Name}! Внутри оказался {_rewardItem}.");
            Console.WriteLine($"Ты взломал {Name} и нашёл {_rewardItem}.");
        }
        else
        {
            Console.WriteLine($"{Name} крепкий. Нужно что-то тяжёлое, чтобы его вскрыть. Может, {_requiredItem}?");
        }
    }
}