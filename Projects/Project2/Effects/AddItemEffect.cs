public class AddItemEffect : EffectBase
{
    private string _itemName;
    
    public AddItemEffect(string itemName)
    {
        _itemName = itemName;
    }
    
    public override void Apply(GameState state)
    {
        state.Inventory.Add(_itemName);
        state.AddEventLog($"Вы получили: {_itemName}");
    }
}