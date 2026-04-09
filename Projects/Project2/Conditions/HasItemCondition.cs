public class HasItemCondition : ConditionBase
{
    private string _itemName;
    
    public HasItemCondition(string itemName)
    {
        _itemName = itemName;
    }
    
    public override bool Check(GameState state)
    {
        return state.Inventory.Contains(_itemName);
    }
}