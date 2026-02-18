using System;
using Microsoft.Xna.Framework;

namespace EmberKit.Time
{
    public class TimedAction
    {
        private readonly GameTimer _timer;
        private readonly Action _action;

        public TimedAction(GameTimer timer, Action action)
        {
            _timer = timer;
            _action = action;
            _timer.Start();
        }

        public TimedAction(float delay, Action action) : this(new GameTimer(delay), action)
        {
        }

        public void SetDelay(float delay)
        {
            _timer.SetDelay(delay);
        }

        public void Update(GameTime gameTime)
        {
            _timer.Update(gameTime);
            if (_timer.Done)
            {
                _action.Invoke();
            }
        }
    }
}