using EmberKit.Geom;
using Microsoft.Xna.Framework;

namespace EmberKit.Time
{
    public struct TimeFunction
    {
        private IntervalF _intervalF;
        private GameTimer _timer;

        public TimeFunction(float minValue, float maxValue, float time)
        {
            _intervalF = new IntervalF(minValue, maxValue);
            _timer = new GameTimer(time, true);
        }

        public void Update(GameTime gameTime)
        {
            _timer.Update(gameTime);
        }

        public void Pause()
        {
            _timer.Pause();
        }

        public void Start(bool countdown)
        {
            _timer.Reverse = countdown;
            _timer.Start();
        }

        public float CurrentValue => _intervalF.FractionToValue(_timer.ElapsedFraction);
    }
}