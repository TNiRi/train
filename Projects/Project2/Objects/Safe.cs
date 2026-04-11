public class Safe : IInteractable
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }

    private string _code;
    private string _rewardItem;
    private bool _isOpen;

    public Safe(string id, string name, string description, string code, string rewardItem)
    {
        Id = id;
        Name = name;
        Description = description;
        _code = code;
        _rewardItem = rewardItem;
        _isOpen = false;
    }

    public void Interact(GameState state)
    {
        if (_isOpen)
        {
            Console.WriteLine("Сейф уже открыт и пуст.");
            return;
        }

        Console.Write("Введите код: ");
        string input = Console.ReadLine();

        if (input == _code)
        {
            _isOpen = true;
            state.Inventory.Add(_rewardItem);
            state.AddEventLog($"Ты открыл сейф и нашёл {_rewardItem}!");
            Console.WriteLine($"Внутри лежит {_rewardItem}. Ты забрал его.");
        }
        else
        {
            Console.WriteLine("Код неверный. Сейф не открывается.");
        }
    }
}