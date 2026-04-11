public class DamageEffect : EffectBase
{
    private int _amount;
    
    public DamageEffect(int amount)
    {
        _amount = amount;
    }
    
    public override void Apply(GameState state)
    {
        state.Health -= _amount;
        state.AddEventLog($"Вы получили {_amount} урона. Здоровье: {state.Health}");
        
        if (state.Health <= 0)
        {
            Console.WriteLine("ВЫ УМЕРЛИ... ИГРА ОКОНЧЕНА");
            // Здесь потом добавим завершение игры
        }
    }
}