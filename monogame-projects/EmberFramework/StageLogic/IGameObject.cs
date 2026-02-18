using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace EmberFramework.StageLogic;

public interface IGameObject
{
    List<string> Tags { get; }
    void Update(GameTime gameTime);
    bool Active { get; set; }

    IList<IGameObject> Children { get; }
    IGameObject Parent { get; set; }
    void AddChild(IGameObject gameObject);
    void RemoveChild(IGameObject gameObject);

    T GetComponent<T>() where T : class, IGameComponent;
    void AttachComponent(IGameComponent component);
    void DetachComponent(IGameComponent component);
    
    IEnumerable<T> FindComponents<T>() where T : class, IGameComponent;
}