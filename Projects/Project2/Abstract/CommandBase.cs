public abstract class CommandBase : ICommand
{
    protected string _name;
    
    public CommandBase(string name)
    {
        _name = name;
    }
    
    public abstract void Execute(GameState state);
    
    public virtual string GetDescription()
    {
        return $"{_name} — выполнить действие";
    }
}