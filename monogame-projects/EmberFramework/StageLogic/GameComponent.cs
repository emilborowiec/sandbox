using Microsoft.Xna.Framework;

namespace EmberFramework.StageLogic;

public abstract class GameComponent : IGameComponent
{
    private bool _doneFirstFrame;
    private bool _active = true;

    public bool Active { 
        get => _active && GameObject.Active;
        set => _active = value;
    }
        
    private void OnFirstFrameInternal()
    {
        _doneFirstFrame = true;
        OnFirstFrame();
    }

    public abstract void OnFirstFrame();

    public string Name => GetType().Name;
    public IGameObject GameObject { get; set; }

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
    }

    public abstract void InnerUpdate(GameTime gameTime);
}