using System;
using System.Collections.Generic;
using EmberFramework.MacroLogic;

namespace EmberFramework.EngineSystems.Events;

public class GameEventHub : IGameService
{
    private Dictionary<string, List<IGameEventListener>> _listeners = new();
    private Queue<GameEvent> _eventQueue = new();

    public void AddListener(string eventName, IGameEventListener listener)
    {
        if (!_listeners.ContainsKey(eventName))
        {
            _listeners[eventName] = new List<IGameEventListener>();
        }

        if (_listeners[eventName].Contains(listener))
        {
            throw new InvalidOperationException("Cannot add same listener more than once to the same event");
        }
        _listeners[eventName].Add(listener);
    }
        
    public void RaiseEvent(GameEvent gameEvent)
    {
        _eventQueue.Enqueue(gameEvent);
    }

    public void DispatchEvents()
    {
        while (_eventQueue.TryDequeue(out var gameEvent))
        {
            foreach (var gameFeature in _listeners[gameEvent.Name])
            {
                gameFeature.HandleEvent(gameEvent);
            }
        }
    }

    public void Clear()
    {
        _listeners.Clear();
        _eventQueue.Clear();
    }
}