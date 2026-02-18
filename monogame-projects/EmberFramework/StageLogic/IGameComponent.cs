using Microsoft.Xna.Framework;

namespace EmberFramework.StageLogic;

public interface IGameComponent
{
    string Name { get; }
    IGameObject GameObject { get; set; }
    void OnFirstFrame();
    void Update(GameTime gameTime);
    public bool Active { get; set; }
}