using System;

public class LookCommand : CommandBase
{
    public LookCommand() : base("look")
    {
    }
    
    public override void Execute(GameState state)
    {
        Location currentLocation = state.CurrentLocation;
        
        Console.WriteLine($"\n=== {currentLocation.Name} ===");
        Console.WriteLine(currentLocation.Description);
        
        if (currentLocation.Objects.Count > 0)
        {
            Console.WriteLine("\nВы видите:");
            foreach (var obj in currentLocation.Objects)
            {
                Console.WriteLine($"- {obj.Name} ({obj.Id})");
            }
        }
        
        if (currentLocation.Exits.Count > 0)
        {
            Console.WriteLine("\nОтсюда можно пойти:");
            foreach (var exit in currentLocation.Exits.Keys)
            {
                Console.WriteLine($"- {exit}");
            }
        }
        Console.WriteLine();
    }
    
    public override string GetDescription()
    {
        return "осмотреть текущую локацию";
    }
}