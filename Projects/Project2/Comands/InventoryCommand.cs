using System;

public class InventoryCommand : CommandBase
{
    public InventoryCommand() : base("inv")
    {
    }
    
    public override void Execute(GameState state)
    {
        Console.WriteLine("\n=== Инвентарь ===");
        
        if (state.Inventory.Count == 0)
        {
            Console.WriteLine("Ваш инвентарь пуст.");
        }
        else
        {
            foreach (string item in state.Inventory)
            {
                Console.WriteLine($"- {item}");
            }
        }
        Console.WriteLine();
    }
    
    public override string GetDescription()
    {
        return "показать инвентарь";
    }
}