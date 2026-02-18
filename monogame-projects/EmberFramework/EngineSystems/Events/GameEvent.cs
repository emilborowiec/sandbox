using EmberFramework.StageLogic;

namespace EmberFramework.EngineSystems.Events;

public readonly struct GameEvent
{
    public readonly string Name;
    public readonly IGameObject Source;
        
    public GameEvent(string name, IGameObject source)
    {
        Name = name;
        Source = source;
    }
}