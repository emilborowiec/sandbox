using Microsoft.Xna.Framework;

namespace EmberKit.Geom;

/// <summary>
/// Axis-aligned bounding box based on floats.
/// </summary>
public readonly struct AabbF
{
    public readonly IntervalF XAxis;
    public readonly IntervalF YAxis;
        
    public AabbF(IntervalF xAxis, IntervalF yAxis)
    {
        XAxis = xAxis;
        YAxis = yAxis;
    }

    public AabbF(Vector2 topLeft, Vector2 bottomRight)
    {
        XAxis = new IntervalF(topLeft.X, bottomRight.X);
        YAxis = new IntervalF(topLeft.Y, bottomRight.Y);
    }

    public Vector2 TopLeft => new Vector2(XAxis.Min, YAxis.Min);
    public Vector2 TopRight => new Vector2(XAxis.Max, YAxis.Min);
    public Vector2 BottomRight => new Vector2(XAxis.Max, YAxis.Max);
    public Vector2 BottomLeft => new Vector2(XAxis.Min, YAxis.Max);

    public float MinX => XAxis.Min;
    public float MinY => YAxis.Min;
    public float MaxX => XAxis.Max;
    public float MaxY => YAxis.Max;
    public float Width => XAxis.Range;
    public float Height => YAxis.Range;
    public Vector2 Center => new Vector2(XAxis.Center, YAxis.Center);

    public bool Contains(float x, float y)
    {
        return XAxis.Contains(x) && YAxis.Contains(y);
    }

    public bool Contains(Vector2 coordinatePair)
    {
        return Contains(coordinatePair.X, coordinatePair.Y);
    }

    public bool Contains(AabbF box)
    {
        return XAxis.Contains(box.XAxis) && YAxis.Contains(box.YAxis);
    }

    public bool Intersects(AabbF other)
    {
        return XAxis.Intersects(other.XAxis) && YAxis.Intersects(other.YAxis);
    }
        
    public static AabbF FromMinMax(Vector2 topLeft, Vector2 bottomRight)
    {
        return FromMinMax(topLeft.X, topLeft.Y, bottomRight.X, bottomRight.Y);
    }

    public static AabbF FromMinMax(float minX, float minY, float maxX, float maxY)
    {
        var xInterval =  new IntervalF(minX, maxX);
        var yInterval =  new IntervalF(minY, maxY);
        return new AabbF(xInterval, yInterval);
    }

    public static AabbF FromSize(float minX, float minY, float width, float height)
    {
        var xInterval = IntervalF.FromRange(minX, width);
        var yInterval = IntervalF.FromRange(minY, height);
        return new AabbF(xInterval, yInterval);
    }

    public static AabbF FromSize(Vector2 topLeft, Dimension dimension)
    {
        return FromSize(topLeft.X, topLeft.Y, dimension.Width, dimension.Height);
    }

    public static AabbF FromSize(Vector2 topLeft, float width, float height)
    {
        return FromSize(topLeft.X, topLeft.Y, width, height);
    }

}