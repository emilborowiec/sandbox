using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace EmberFramework.EngineSystems;

public class ScreenManager
{
    private readonly Dictionary<Type, IGameScreen> _gameScreens = new();

    public IGameScreen CurrentGameScreen { get; private set; }
    public IGameScreen NextGameScreen { get; set; }

    public void AddScreen(IGameScreen gameScreen, bool setCurrent)
    {
        _gameScreens[gameScreen.GetType()] = gameScreen;
        if (setCurrent)
        {
            CurrentGameScreen = gameScreen;
        }
    }
        
    public void SwitchScreen(Type gameScreenType)
    {
        NextGameScreen = _gameScreens[gameScreenType];
    }

    public void Update(GameTime gameTime)
    {
        if (NextGameScreen != null && NextGameScreen != CurrentGameScreen)
        {
            CurrentGameScreen = NextGameScreen;
            NextGameScreen = null;
        }
    }
}