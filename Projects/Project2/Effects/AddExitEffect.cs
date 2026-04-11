public class AddExitEffect : EffectBase
{
    private string _fromLocationName;
    private string _keyword;
    private Location _targetLocation;
    
    public AddExitEffect(string fromLocationName, string keyword, Location targetLocation)
    {
        _fromLocationName = fromLocationName;
        _keyword = keyword;
        _targetLocation = targetLocation;
    }
    
    public override void Apply(GameState state)
    {
        // Нам нужен способ найти локацию по имени
        if (state.AllLocations.ContainsKey(_fromLocationName))
        {
            Location from = state.AllLocations[_fromLocationName];
            from.AddExit(_keyword, _targetLocation);
            state.AddEventLog($"Теперь ты можешь переместиться в '{_targetLocation.Name}' по слову '{_keyword}'");
        }
        else
        {
            state.AddEventLog($"Ошибка: локация '{_fromLocationName}' не найдена");
        }
    }
}