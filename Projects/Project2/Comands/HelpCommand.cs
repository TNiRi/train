using System;
using System.Collections.Generic;

public class HelpCommand : CommandBase
{
    private Dictionary<string, ICommand> _commands;
    
    public HelpCommand(Dictionary<string, ICommand> commands) : base("help")
    {
        _commands = commands;
    }
    
    public override void Execute(GameState state)
    {
        Console.WriteLine("\n=== Доступные команды ===");
        foreach (var cmd in _commands)
        {
            Console.WriteLine($"{cmd.Key} - {cmd.Value.GetDescription()}");
        }
        Console.WriteLine();
    }
}