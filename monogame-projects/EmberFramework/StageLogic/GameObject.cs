using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace EmberFramework.StageLogic;

public abstract class GameObject : IGameObject
{
    private readonly List<IGameObject> _children = [];
    private readonly Dictionary<Type, IGameComponent> _components = new();
    private bool _doneFirstFrame;
    private bool _active = true;

    protected GameObject()
    {
    }

    protected GameObject(params string[] tags) : this()
    {
        foreach (var tag in tags)
        {
            Tags.Add(tag);
        }
    }

    public List<string> Tags { get; } = [];

    public bool Active
    {
        get => _active && (Parent?.Active ?? true);
        set => _active = value;
    }

    private void OnFirstFrameInternal()
    {
        _doneFirstFrame = true;
    }

    public abstract void OnFirstFrame();

    public void Update(GameTime gameTime)
    {
        if (!Active)
        {
            return;
        }

        if (!_doneFirstFrame)
        {
            OnFirstFrameInternal();
        }

        InnerUpdate(gameTime);

        foreach (var component in _components.Values)
        {
            component.Update(gameTime);
        }

        foreach (var child in _children)
        {
            child.Update(gameTime);
        }
    }

    public abstract void InnerUpdate(GameTime gameTime);

    public IList<IGameObject> Children => _children;
    public IGameObject Parent { get; set; }

    public void AddChild(IGameObject gameObject)
    {
        if (gameObject.Parent != null) throw new InvalidOperationException("gameObject already has a parent");
        _children.Add(gameObject);
        gameObject.Parent = this;
    }

    public void RemoveChild(IGameObject gameObject)
    {
        _children.Remove(gameObject);
    }

    public T GetComponent<T>() where T : class, IGameComponent
    {
        return (T)_components[typeof(T)];
    }

    public void AttachComponent(IGameComponent component)
    {
        if (component.GameObject != null) throw new InvalidOperationException("GameComponent already has an owner");
        _components[component.GetType()] = component;
    }

    public void DetachComponent(IGameComponent component)
    {
        _components.Remove(component.GetType());
    }

    public IEnumerable<T> FindComponents<T>() where T : class, IGameComponent
    {
        var queue = new Queue<IGameObject>();
        queue.Enqueue(this);
        IGameObject gameObject;
        while (queue.TryDequeue(out gameObject))
        {
            foreach (var child in gameObject.Children)
            {
                queue.Enqueue(child);
            }

            var behavior = gameObject.GetComponent<T>();
            if (behavior != null)
            {
                yield return behavior;
            }
        }
    }
}