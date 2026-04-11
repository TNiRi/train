using System.Collections.Generic;

public class OrCondition : ConditionBase
{
    private List<ICondition> _conditions;
    
    public OrCondition(params ICondition[] conditions)
    {
        _conditions = new List<ICondition>(conditions);
    }
    
    public override bool Check(GameState state)
    {
        foreach (var condition in _conditions)
        {
            if (condition.Check(state)) return true;
        }
        return false;
    }
}