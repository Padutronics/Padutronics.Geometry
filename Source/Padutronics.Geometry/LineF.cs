using Padutronics.Diagnostics.Debugging;
using System;
using System.Diagnostics;

namespace Padutronics.Geometry;

[DebuggerDisplay(DebuggerDisplayValues.DebuggerDisplay)]
public sealed class LineF : IEquatable<LineF>
{
    public LineF(Point2F point1, Point2F point2)
    {
        Point1 = point1;
        Point2 = point2;
    }

    public LineF(double x1, double y1, Point2F point2) :
        this(new Point2F(x1, y1), point2)
    {
    }

    public LineF(Point2F point1, double x2, double y2) :
        this(point1, new Point2F(x2, y2))
    {
    }

    public LineF(double x1, double y1, double x2, double y2) :
        this(new Point2F(x1, y1), new Point2F(x2, y2))
    {
    }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string DebuggerDisplay => $"Point1 = (X: {Point1.X}, Y: {Point1.Y}), Point2 = (X: {Point2.X}, Y: {Point2.Y})";

    public bool IsHorizontal => Point1.Y == Point2.Y;

    public bool IsPoint => Point1 == Point2;

    public bool IsVertical => Point1.X == Point2.X;

    public bool IsZero => Point1.IsZero && Point2.IsZero;

    public Point2F Middle => new((Point1.X + Point2.X) / 2.0, (Point1.Y + Point2.Y) / 2.0);

    public Point2F Point1 { get; }

    public Point2F Point2 { get; }

    public override bool Equals(object? obj)
    {
        return Equals(obj as LineF);
    }

    public bool Equals(LineF? other)
    {
        return other is not null && Point1 == other.Point1 && Point2 == other.Point2;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Point1, Point2);
    }

    public static bool operator ==(LineF? left, LineF? right)
    {
        return left?.Equals(right) ?? right is null;
    }

    public static bool operator !=(LineF? left, LineF? right)
    {
        return !(left == right);
    }
}