using System;

namespace EmberKit.Geom;

/// <summary>
/// Interval of ints.
/// Defined as inclusive minimum and maximum.
/// </summary>
public readonly struct IntervalI
{
    public readonly int Min;
    public readonly int Max;
        
    public IntervalI(int min, int max)
    {
        if (max < min) throw new ArgumentOutOfRangeException(nameof(max), "Max lower than Min");
        Min = min;
        Max = max;
    }

    public int Range => Max - Min;
    public int Center => Min + (Range / 2);

    public bool Contains(int value)
    {
        return value >= Min && value <= Max;
    }

    public bool Contains(IntervalI other)
    {
        return Min <= other.Min && Max >= other.Max;
    }

    public bool Intersects(IntervalI other)
    {
        if (Max < other.Min) return false;
        return Min <= other.Max;
    }

    public int ValueToFraction(int value)
    {
        return (value - Min) / Range;
    }

    public int FractionToValue(int fraction)
    {
        return Min + (Range * fraction);
    }

    public static IntervalI FromRange(int min, int length)
    {
        return new IntervalI(min, min + length);
    }

    /// <summary>
    /// Creates smallest integral interval that contains floating point interval
    /// </summary>
    /// <param name="min"></param>
    /// <param name="max"></param>
    /// <returns></returns>
    public static IntervalI CreateSmallestContainer(float min, float max)
    {
        return new IntervalI((int)Math.Floor(min), (int)Math.Ceiling(max));
    }

    public static IntervalI CreateSmallestContainer(IntervalF interval)
    {
        return new IntervalI((int)Math.Floor(interval.Min), (int)Math.Ceiling(interval.Max));
    }
}