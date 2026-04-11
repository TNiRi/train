using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        GameState state = WorldBuilder.CreateGame();

        var commands = new Dictionary<string, ICommand>
        {
            { "look", new LookCommand() },
            { "inv", new InventoryCommand() },
            { "status", new StatusCommand() }
        };

        commands.Add("go", new HelpStubCommand("go <keyword>", "перейти по кодовому слову"));
        commands.Add("interact", new HelpStubCommand("interact <id>", "взаимодействовать с объектом"));
        commands.Add("ask", new HelpStubCommand("ask <topic>", "спросить NPC"));
        commands.Add("exit", new HelpStubCommand("exit", "выйти из игры"));

        HelpCommand helpCmd = new HelpCommand(commands);
        commands.Add("help", helpCmd);

        Console.WriteLine("=== БУНКЕР ===");
        Console.WriteLine(state.CurrentLocation.Description);
        Console.WriteLine("Команды: look, go <слово>, interact <id>, inv, status, help, ask <тема>, exit");

        // Переменные для режима диалога
        Npc currentNPC = null;

        while (state.Health > 0)
        {
            Console.Write("\n> ");
            string input = Console.ReadLine();
            if (input == "exit" && currentNPC == null) break;

            // === РЕЖИМ ДИАЛОГА ===
            if (currentNPC != null)
            {
                if (input == "exit" || input == "bye")
                {
                    Console.WriteLine($"Вы закончили разговор с {currentNPC.Name}.");
                    currentNPC = null;
                }
                else if (input == "help")
                {
                    Console.WriteLine($"\n=== Что можно спросить у {currentNPC.Name} ===");
                    var topics = currentNPC.GetAvailableTopics();
                    foreach (var topic in topics)
                    {
                        Console.WriteLine($"- {topic}");
                    }
                    Console.WriteLine("\nКоманды диалога: ask <тема>, exit, bye");
                }
                else if (input.StartsWith("ask "))
                {
                    string topic = input.Substring(4);
                    currentNPC.Talk(topic, state);
                }
                else
                {
                    Console.WriteLine("В диалоге доступны: ask <тема>, help, exit, bye");
                }
                continue;
            }

            // === ОБЫЧНЫЙ РЕЖИМ ===
            if (commands.ContainsKey(input) && input != "go" && input != "interact" && input != "ask")
            {
                commands[input].Execute(state);
            }
            else if (input.StartsWith("go "))
            {
                string word = input.Substring(3);
                GoCommand cmd = new GoCommand(word);
                cmd.Execute(state);
            }
            else if (input.StartsWith("interact "))
            {
                string id = input.Substring(9);
                InteractCommand cmd = new InteractCommand(id);
                cmd.Execute(state);
            }
            else if (input.StartsWith("ask "))
            {
                string topic = input.Substring(4);
                var npc = state.CurrentLocation.Objects.Find(obj => obj is Npc) as Npc;
                if (npc != null)
                {
                    currentNPC = npc;
                    Console.WriteLine($"\nВы начали разговор с {npc.Name}.");
                    Console.WriteLine("Спросите что-нибудь (ask <тема>) или введите help для списка тем.");
                    
                    // Если игрок сразу спросил что-то конкретное
                    if (topic.Length > 0)
                        currentNPC.Talk(topic, state);
                }
                else
                {
                    Console.WriteLine("Здесь никого нет.");
                }
            }
            else
            {
                Console.WriteLine("Неизвестная команда. Введите help");
            }

            state.CheckQuests();
        }

        Console.WriteLine("\n=== ТЫ ПОГИБ ===");
    }
}

public class HelpStubCommand : ICommand
{
    private string _syntax;
    private string _description;

    public HelpStubCommand(string syntax, string description)
    {
        _syntax = syntax;
        _description = description;
    }

    public void Execute(GameState state)
    {
        Console.WriteLine($"Использование: {_syntax}");
    }

    public string GetDescription()
    {
        return _description;
    }
}