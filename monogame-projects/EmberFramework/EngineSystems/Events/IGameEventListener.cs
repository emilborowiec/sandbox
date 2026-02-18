namespace EmberFramework.EngineSystems.Events;

public interface IGameEventListener
{
        void HandleEvent(GameEvent gameEvent);
}