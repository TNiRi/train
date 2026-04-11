using System;
using System.Linq;

public class InteractCommand : CommandBase
{
    private string _objectId;

    public InteractCommand(string objectId) : base("interact")
    {
        _objectId = objectId;
    }

    public override void Execute(GameState state)
    {
        Location current = state.CurrentLocation;

        // Ищем объект с таким Id в текущей локации
        var target = current.Objects.FirstOrDefault(obj => obj.Id == _objectId);

        if (target != null)
        {
            Console.WriteLine($"\nВы взаимодействуете с {target.Name}...");
            target.Interact(state);
            state.TurnCount++;
            state.AddEventLog($"Взаимодействие с {target.Name}");
        }
        else
        {
            Console.WriteLine($"\nЗдесь нет объекта с названием '{_objectId}'");
        }
    }

    public override string GetDescription()
    {
        return "взаимодействовать с объектом (interact <id>)";
    }
}