public class RemoveItemEffect : EffectBase
{
    private string _itemName;
    
    public RemoveItemEffect(string itemName)
    {
        _itemName = itemName;
    }
    
    public override void Apply(GameState state)
    {
        if (state.Inventory.Contains(_itemName))
        {
            state.Inventory.Remove(_itemName);
            state.AddEventLog($"Вы потеряли: {_itemName}");
        }
    }
}