using System;
using EmberKit.Geom;
using EmberKit.Time;
using Microsoft.Xna.Framework;

namespace EmberKit.Graphics
{
    public class FadeEffect
    {
        private readonly Sprite _sprite;
        private readonly Segment1 _segment;
        private readonly GameTimer _timer;

        public FadeEffect(Sprite sprite, float start, float end, double time)
        {
            _sprite = sprite;
            _segment = new Segment1(start, end);
            _timer = new GameTimer(TimeSpan.FromSeconds(time));
        }

        public GameTimer Timer => _timer;

        public void Update(GameTime gameTime)
        {
            _timer.Update(gameTime);
            if (!_timer.Paused)
            {
                var alpha = _segment.Lerp(_timer.ElapsedFraction);
                _sprite.Tint = new Color(Color.Black, _timer.ElapsedFraction);
            }
        }
    }
}