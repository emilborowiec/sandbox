using EmberFramework.EngineSystems;
using EmberFramework.EngineSystems.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace EmberFramework;

public abstract class GameBase : Game
{
    protected GameBase(int gameWidth, int gameHeight)
    {
        GameContext.Graphics = new GraphicsDeviceManager(this)
        {
            PreferredBackBufferWidth = gameWidth, 
            PreferredBackBufferHeight = gameHeight
        };
        Content.RootDirectory = "Content";
        GameContext.Content = Content;
        IsMouseVisible = true;
        GameContext.ScreenManager = new ScreenManager();
        GameContext.InputManager = new InputManager();
    }

    protected override void LoadContent()
    {
        base.LoadContent();
        GameContext.SpriteBatch = new SpriteBatch(GraphicsDevice);
        InitializeScreens();
    }

    protected override void Initialize()
    {
        base.Initialize();
        InitializeServices();
    }

    protected abstract void InitializeServices();
    protected abstract void InitializeScreens();

    protected override void Update(GameTime gameTime)
    {
        GameContext.InputManager.Update();
        GameContext.ScreenManager.Update(gameTime);
        GameContext.ScreenManager.CurrentGameScreen.Update(gameTime);
            
        base.Update(gameTime);
    }
        
    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        GameContext.ScreenManager.CurrentGameScreen.Draw(gameTime);
            
        base.Draw(gameTime);
    }
}