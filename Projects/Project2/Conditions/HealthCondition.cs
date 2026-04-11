public class HealthCondition : ConditionBase
{
    private int _threshold;
    private string _operator;
    
    public HealthCondition(int threshold, string operatorSymbol)
    {
        _threshold = threshold;
        _operator = operatorSymbol;
    }
    
    public override bool Check(GameState state)
    {
        return _operator switch
        {
            ">" => state.Health > _threshold,
            "<" => state.Health < _threshold,
            ">=" => state.Health >= _threshold,
            "<=" => state.Health <= _threshold,
            "==" => state.Health == _threshold,
            _ => false
        };
    }
}