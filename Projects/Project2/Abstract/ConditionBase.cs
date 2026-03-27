public abstract class ConditionBase : ICondition
{
    public abstract bool Check(GameState state);
}