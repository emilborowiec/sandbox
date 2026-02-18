using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace EmberKit.Geom;

public readonly struct Segment1 : IEqualityComparer<Segment1>
{
    public readonly float Start;
    public readonly float End;

    public Segment1(float start, float end)
    {
        Start = start;
        End = end;
    }

    public float Lerp(float weight) => MathHelper.Lerp(Start, End, weight);

    public bool Equals(Segment1 x, Segment1 y)
    {
        return x.Start.Equals(y.Start) && x.End.Equals(y.End);
    }

    public int GetHashCode(Segment1 obj)
    {
        return HashCode.Combine(obj.Start, obj.End);
    }
}