using EmberFramework.EngineSystems.Events;
using EmberFramework.StageLogic;
using Microsoft.Xna.Framework;

namespace EmberFramework.EngineSystems;

public abstract class GameScreen : IGameScreen
{
    private readonly Scene _scene;
    private readonly GameEventHub _eventHub;
    private bool _doneFirstFrame;

    protected GameScreen()
    {
        _eventHub = new GameEventHub();
    }

    private void OnFirstFrameInternal()
    {
        _doneFirstFrame = true;
        OnFirstFrame();
    }

    public abstract void OnFirstFrame();

    protected abstract void InitializeGameObjects();

    public void Initialize()
    {
        InitializeGameObjects();
    }

    public void Reset()
    {
        _eventHub.Clear();
        InitializeGameObjects();
    }

    public void Update(GameTime gameTime)
    {
        if (!_doneFirstFrame)
        {
            OnFirstFrameInternal();
        }
            
        _scene.Update(gameTime);
            
        _eventHub.DispatchEvents();
    }

    public void Draw(GameTime gameTime)
    {
        _scene.Draw(gameTime);
    }
}