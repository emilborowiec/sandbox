using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace EmberFramework.StageLogic;

public abstract class Scene
{
    private List<IGameObject> _gameObjects = [];

    public void AddGameObject(IGameObject gameObject)
    {
        if (_gameObjects.Contains(gameObject))
        {
            return;
        }
            
        _gameObjects.Add(gameObject);
    }

    public void RemoveGameObject(IGameObject gameObject)
    {
        _gameObjects.Remove(gameObject);
    }

    public IGameObject FindGameObject(string tag)
    {
        return _gameObjects.FirstOrDefault(x => x.Tags.Contains(tag));
    }

    public IEnumerable<IGameObject> FindGameObjects(string tag)
    {
        return _gameObjects.FindAll(x => x.Tags.Contains(tag));
    }

    public void Update(GameTime gameTime)
    {
        foreach (var gameObject in _gameObjects)
        {
            gameObject.Update(gameTime);
        }
    }

    public abstract void Draw(GameTime gameTime);
}