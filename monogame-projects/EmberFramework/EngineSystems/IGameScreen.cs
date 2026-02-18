using Microsoft.Xna.Framework;

namespace EmberFramework.EngineSystems;

public interface IGameScreen
{
    void Initialize();
    void Reset();
    void Update(GameTime gameTime);
    void Draw(GameTime gameTime);
}