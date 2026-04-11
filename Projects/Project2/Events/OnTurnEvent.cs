public class OnTurnEvent : GameEventBase
{
    public OnTurnEvent(ICondition condition, List<IEffect> effects, bool isOneTime = false) 
        : base(condition, effects, isOneTime)
    {
    }
}