using EmberFramework.EngineSystems.Input;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace EmberFramework.EngineSystems;

public static class GameContext
{
    public static GraphicsDeviceManager Graphics { get; set; }
    public static GraphicsDevice GetGraphicsDevice() => Graphics.GraphicsDevice;
    public static ContentManager Content { get; set; }
    public static GameSettings Settings { get; set; }
    public static ScreenManager ScreenManager { get; set; }
    public static IGameScreen CurrentScreen => ScreenManager.CurrentGameScreen;
    public static InputManager InputManager { get; set; }
    public static SpriteBatch SpriteBatch { get; set; }
}