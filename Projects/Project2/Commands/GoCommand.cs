using System;

public class GoCommand : CommandBase
{
    private string _keyword;

    public GoCommand(string keyword) : base("go")
    {
        _keyword = keyword;
    }

    public override void Execute(GameState state)
    {
        Location current = state.CurrentLocation;

        if (current.Exits.ContainsKey(_keyword))
        {
            Location next = current.Exits[_keyword];
            state.CurrentLocation = next;
            foreach (var evt in next.Events)
            {
                if (evt is OnEnterLocationEvent)
                    evt.TryTrigger(state);
            }
            state.TurnCount++;

            Console.WriteLine($"\nВы перешли по слову '{_keyword}'");
            Console.WriteLine($"-- {next.Name} --");
            Console.WriteLine(next.Description);

            state.AddEventLog($"Переход в {next.Name}");

            foreach (var evt in next.Events)
            {
                evt.TryTrigger(state);
            }
        }
        else
        {
            Console.WriteLine($"\nНет перехода по слову '{_keyword}'");
        }
    }

    public override string GetDescription()
    {
        return "перейти по кодовому слову (go <слово>)";
    }
}