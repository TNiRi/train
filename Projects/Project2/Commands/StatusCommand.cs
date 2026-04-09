using System;

public class StatusCommand : CommandBase
{
    public StatusCommand() : base("status")
    {
    }
    
    public override void Execute(GameState state)
    {
        Console.WriteLine($"\n=== Состояние игрока ===");
        Console.WriteLine($"Здоровье: {state.Health}");
        Console.WriteLine($"Ходов сделано: {state.TurnCount}");
        Console.WriteLine();
    }
    
    public override string GetDescription()
    {
        return "показать состояние игрока";
    }
}