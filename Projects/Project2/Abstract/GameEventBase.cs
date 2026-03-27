using System.Collections.Generic;

public abstract class GameEventBase
{
    protected ICondition _condition;
    protected List<IEffect> _effects;
    protected bool _isOneTime;
    protected bool _hasTriggered;
    
    public GameEventBase(ICondition condition, List<IEffect> effects, bool isOneTime = false)
    {
        _condition = condition;
        _effects = effects;
        _isOneTime = isOneTime;
        _hasTriggered = false;
    }
    
    public void TryTrigger(GameState state)
    {
        if (_isOneTime && _hasTriggered)
            return;
        
        if (_condition.Check(state))
        {
            foreach (var effect in _effects)
            {
                effect.Apply(state);
            }
            _hasTriggered = true;
        }
    }
}