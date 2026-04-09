public class FlagCondition : ConditionBase
{
    private string _flagName;
    private bool _expectedValue;
    
    public FlagCondition(string flagName, bool expectedValue)
    {
        _flagName = flagName;
        _expectedValue = expectedValue;
    }
    
    public override bool Check(GameState state)
    {
        if (state.Flags.ContainsKey(_flagName))
        {
            return state.Flags[_flagName] == _expectedValue;
        }
        return false;
    }
}