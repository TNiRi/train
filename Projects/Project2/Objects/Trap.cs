public class Trap : IInteractable
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }
    
    private bool _isActive;
    private int _damage;
    private bool _isOneTime;
    
    public Trap(string id, string name, string description, int damage, bool isOneTime = true)
    {
        Id = id;
        Name = name;
        Description = description;
        _isActive = true;
        _damage = damage;
        _isOneTime = isOneTime;
    }
    
    public void Interact(GameState state)
    {
        if (!_isActive)
        {
            Console.WriteLine($"{Name} уже сработала и не опасна.");
            return;
        }
        
        Console.WriteLine($"Вы наступили на {Name}!");
        DamageEffect damage = new DamageEffect(_damage);
        damage.Apply(state);
        
        if (_isOneTime)
        {
            _isActive = false;
            state.AddEventLog($"Ловушка {Name} сломалась");
        }
    }
}