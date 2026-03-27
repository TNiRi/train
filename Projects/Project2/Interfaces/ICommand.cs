public interface ICommand
{
    void Execute(GameState state);
    string GetDescription();
}