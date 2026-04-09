public class LogEffect : EffectBase
{
    private string _message;
    
    public LogEffect(string message)
    {
        _message = message;
    }
    
    public override void Apply(GameState state)
    {
        state.AddEventLog(_message);
    }
}