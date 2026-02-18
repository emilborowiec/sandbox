using System;

namespace EmberKit.Geom;

public readonly struct Dimension : IEquatable<Dimension>
{
    public readonly float Width;
    public readonly float Height;

    public Dimension(float width, float height)
    {
        Width = width;
        Height = height;
    }

    public bool Equals(Dimension other)
    {
        return Width.Equals(other.Width) && Height.Equals(other.Height);
    }

    public override bool Equals(object obj)
    {
        return obj is Dimension other && Equals(other);
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Width, Height);
    }
}