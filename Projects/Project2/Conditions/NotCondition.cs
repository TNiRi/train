public class NotCondition : ConditionBase
{
    private ICondition _condition;
    
    public NotCondition(ICondition condition)
    {
        _condition = condition;
    }
    
    public override bool Check(GameState state)
    {
        return !_condition.Check(state);
    }
}