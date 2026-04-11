public class HealEffect : EffectBase
{
    private int _amount;
    
    public HealEffect(int amount)
    {
        _amount = amount;
    }
    
    public override void Apply(GameState state)
    {
        state.Health += _amount;
        state.AddEventLog($"Вы восстановили {_amount} здоровья. Здоровье: {state.Health}");
    }
}