using System.Collections.Generic;

public class OnEnterLocationEvent : GameEventBase
{
    public OnEnterLocationEvent(ICondition condition, List<IEffect> effects, bool isOneTime = false) 
        : base(condition, effects, isOneTime)
    {
    }
}