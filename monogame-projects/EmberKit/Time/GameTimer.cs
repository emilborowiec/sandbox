using System;
using Microsoft.Xna.Framework;

namespace EmberKit.Time;

public class GameTimer
{
    private GameTimerMode _mode;
    private TimeSpan _duration;
    private TimeSpan _elapsed;
    private bool _paused;
    private bool _reverse;
    private bool _done;

    public GameTimer(TimeSpan duration, GameTimerMode mode, bool startPaused = true)
    {
        _mode = mode;
        _duration = duration;
        _paused = startPaused;
        _elapsed = TimeSpan.Zero;
        _reverse = false;
        _done = false;
    }
        
    public GameTimer(TimeSpan duration, bool startPaused = true)
    {
        _mode = GameTimerMode.Timeout;
        _duration = duration;
        _paused = startPaused;
        _elapsed = TimeSpan.Zero;
        _reverse = false;
        _done = false;
    }

    public GameTimer(float duration, GameTimerMode mode, bool paused = true) : this(TimeSpan.FromSeconds(duration), mode, paused)
    {
    }


    public GameTimer(float duration, bool paused = true) : this(TimeSpan.FromSeconds(duration), paused)
    {
    }

    public bool Done => _done;
    public bool Paused => _paused;
    public float ElapsedFraction => Math.Min((float)(_elapsed / _duration), 1.0f);

    public bool Reverse
    {
        get => _reverse;
        set => _reverse = value;
    }

    public void Update(GameTime gameTime)
    {
        if (_paused) return;

        if (_reverse)
        {
            _elapsed -= gameTime.ElapsedGameTime;
            if (_elapsed > TimeSpan.Zero)
            {
                _done = false;
                return;
            }
        }
        else
        {
            _elapsed += gameTime.ElapsedGameTime;
            if (_elapsed < _duration)
            {
                _done = false;
                return;
            }
        }
            
        switch (_mode)
        {
            case GameTimerMode.Timeout:
                _elapsed = _reverse ? TimeSpan.Zero : _duration;
                _paused = true;
                _done = true;
                break;
            case GameTimerMode.Interval:
                _elapsed = _reverse ? _duration : TimeSpan.Zero;
                _done = true;
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public void Start()
    {
        _paused = false;
    }

    public void Stop()
    {
        _paused = true;
        _elapsed = _reverse ? _duration : TimeSpan.Zero;
        _done = false;
    }

    public void Pause()
    {
        _paused = true;
    }

    public void Reset(TimeSpan delay)
    {
        _duration = delay;
        Stop();
    }
        
    public void Reset(float delay)
    {
        Reset(TimeSpan.FromSeconds(delay));
    }
        
    public void SetDelay(TimeSpan delay)
    {
        _duration = delay;
    }

    public void SetDelay(float delay)
    {
        SetDelay(TimeSpan.FromSeconds(delay));
    }
}

public enum GameTimerMode
{
    Timeout,    // stops when delay is reached and calls action
    Interval,   // loops when reaching delay. Calls action every time upon reaching delay. 
}