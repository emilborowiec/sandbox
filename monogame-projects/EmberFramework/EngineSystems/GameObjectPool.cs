using System.Collections.Generic;
using EmberFramework.StageLogic;

namespace EmberFramework.EngineSystems;

public class GameObjectPool
{
    private readonly Dictionary<string, List<IGameObject>> _pool = new();

    public void Add(string bucket, IGameObject gameObject)
    {
        if (!_pool.ContainsKey(bucket))
        {
            _pool[bucket] = [];
        }
        _pool[bucket].Add(gameObject);
        gameObject.Active = false;
    }

    public IGameObject Retrieve(string bucket)
    {
        var gameObject = _pool[bucket].Find(x => !x.Active);
        gameObject.Active = true;
        return gameObject;
    }

    public void Return(IGameObject gameObject)
    {
        gameObject.Active = false;
    }

    public IEnumerable<IGameObject> GetBucket(string bucket)
    {
        return _pool[bucket];
    }
}