using System;

namespace EmberKit.Geom
{
    /// <summary>
    /// Interval of floats.
    /// Defined as inclusive minimum and maximum.
    /// </summary>
    public readonly struct IntervalF
    {
        public readonly float Min;
        public readonly float Max;
        
        public IntervalF(float min, float max)
        {
            if (max < min) throw new ArgumentOutOfRangeException(nameof(max), "Max lower than Min");
            Min = min;
            Max = max;
        }

        public float Range => Max - Min;
        public float Center => Min + (Range / 2);

        public bool Contains(float value)
        {
            return value >= Min && value <= Max;
        }

        public bool Contains(IntervalF other)
        {
            return Min <= other.Min && Max >= other.Max;
        }

        public bool Intersects(IntervalF other)
        {
            if (Max < other.Min) return false;
            return Min <= other.Max;
        }

        public float ValueToFraction(float value)
        {
            return (value - Min) / Range;
        }

        public float FractionToValue(float fraction)
        {
            return Min + (Range * fraction);
        }

        public static IntervalF FromRange(float min, float length)
        {
            return new IntervalF(min, min + length);
        }
    }
}