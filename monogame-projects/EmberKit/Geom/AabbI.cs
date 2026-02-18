using Microsoft.Xna.Framework;

namespace EmberKit.Geom;

/// <summary>
/// Axis-aligned bounding box based on ints.
/// </summary>
public readonly struct AabbI
{
    public readonly IntervalI XAxis;
    public readonly IntervalI YAxis;
        
    public AabbI(IntervalI xAxis, IntervalI yAxis)
    {
        XAxis = xAxis;
        YAxis = yAxis;
    }

    public AabbI(Point topLeft, Point bottomRight)
    {
        XAxis = new IntervalI(topLeft.X, bottomRight.X);
        YAxis = new IntervalI(topLeft.Y, bottomRight.Y);
    }

    public AabbI(in int minX, in int minY, in int maxX, in int maxY)
    {
        XAxis = new IntervalI(minX, maxX);
        YAxis = new IntervalI(minY, maxY);
    }

    public Point TopLeft => new Point(XAxis.Min, YAxis.Min);
    public Point TopRight => new Point(XAxis.Max, YAxis.Min);
    public Point BottomRight => new Point(XAxis.Max, YAxis.Max);
    public Point BottomLeft => new Point(XAxis.Min, YAxis.Max);

    public int MinX => XAxis.Min;
    public int MinY => YAxis.Min;
    public int MaxX => XAxis.Max;
    public int MaxY => YAxis.Max;
    public int Width => XAxis.Range;
    public int Height => YAxis.Range;
    public Point Center => new Point(XAxis.Center, YAxis.Center);

    public bool Contains(int x, int y)
    {
        return XAxis.Contains(x) && YAxis.Contains(y);
    }

    public bool Contains(Point coordinatePair)
    {
        return Contains(coordinatePair.X, coordinatePair.Y);
    }

    public bool Contains(AabbI box)
    {
        return XAxis.Contains(box.XAxis) && YAxis.Contains(box.YAxis);
    }

    public bool Intersects(AabbI other)
    {
        return XAxis.Intersects(other.XAxis) && YAxis.Intersects(other.YAxis);
    }
        
    public static AabbI FromMinMax(Point topLeft, Point bottomRight)
    {
        return FromMinMax(topLeft.X, topLeft.Y, bottomRight.X, bottomRight.Y);
    }

    public static AabbI FromMinMax(int minX, int minY, int maxX, int maxY)
    {
        var xInterval =  new IntervalI(minX, maxX);
        var yInterval =  new IntervalI(minY, maxY);
        return new AabbI(xInterval, yInterval);
    }

    public static AabbI FromSize(int minX, int minY, int width, int height)
    {
        var xInterval = IntervalI.FromRange(minX, width);
        var yInterval = IntervalI.FromRange(minY, height);
        return new AabbI(xInterval, yInterval);
    }

    public static AabbI FromSize(Point topLeft, Point dimension)
    {
        return FromSize(topLeft.X, topLeft.Y, dimension.X, dimension.Y);
    }

    public static AabbI CreateSmallestContainer(AabbF box)
    {
        return new AabbI(IntervalI.CreateSmallestContainer(box.XAxis), IntervalI.CreateSmallestContainer(box.YAxis));
    }
}