public class Generator : IInteractable
{
    public string Id { get; private set; }
    public string Name { get; private set; }
    public string Description { get; private set; }

    public Generator(string id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public void Interact(GameState state)
    {
        if (state.Flags.GetValueOrDefault("GeneratorOn", false))
        {
            Console.WriteLine("Генератор уже работает.");
            return;
        }

        if (state.Inventory.Contains("Ключ от генератора"))
        {
            Console.WriteLine("Ты вставляешь ключ и нажимаешь кнопку...");
            state.Flags["FuseUsed"] = true; // флаг для квеста
            state.CheckQuests(); // квест завершится, если условия выполнены
        }
        else
        {
            Console.WriteLine("Генератор заблокирован. Нужен ключ.");
        }
    }
}