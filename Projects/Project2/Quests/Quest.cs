using System.Collections.Generic;

public class Quest
{
    public string Name { get; private set; }
    public string Description { get; private set; }
    public bool IsCompleted { get; private set; }
    
    private ICondition _completionCondition;
    private List<IEffect> _rewardEffects;
    
    public Quest(string name, string description, ICondition completionCondition, List<IEffect> rewardEffects)
    {
        Name = name;
        Description = description;
        _completionCondition = completionCondition;
        _rewardEffects = rewardEffects;
        IsCompleted = false;
    }
    
    public void CheckCompletion(GameState state)
    {
        if (!IsCompleted && _completionCondition.Check(state))
        {
            IsCompleted = true;
            state.AddEventLog($"КВЕСТ ВЫПОЛНЕН: {Name}");
            
            foreach (var effect in _rewardEffects)
            {
                effect.Apply(state);
            }
        }
    }
}