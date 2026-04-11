public class SetFlagEffect : EffectBase
{
    private string _flagName;
    private bool _value;
    
    public SetFlagEffect(string flagName, bool value)
    {
        _flagName = flagName;
        _value = value;
    }
    
    public override void Apply(GameState state)
    {
        state.Flags[_flagName] = _value;
        state.AddEventLog($"Флаг {_flagName} установлен в {_value}");
    }
}