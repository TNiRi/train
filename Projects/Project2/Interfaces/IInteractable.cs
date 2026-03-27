public interface IInteractable
{
    string Id { get; }
    string Name { get; }
    string Description { get; }
    void Interact(GameState state);
}