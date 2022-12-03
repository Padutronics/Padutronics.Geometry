using Padutronics.Diagnostics.Debugging;
using System;
using System.Diagnostics;

namespace Padutronics.Geometry;

[DebuggerDisplay(DebuggerDisplayValues.DebuggerDisplay)]
public sealed class Point2F : IEquatable<Point2F>
{
    public Point2F(double uniform) :
        this(uniform, uniform)
    {
    }

    public Point2F(double x, double y)
    {
        if (double.IsNaN(x))
        {
            throw new ArgumentException("X value is NaN.", nameof(x));
        }
        if (double.IsNaN(y))
        {
            throw new ArgumentException("Y value is NaN.", nameof(y));
        }

        X = x;
        Y = y;
    }

    public static Point2F Zero { get; } = new Point2F(uniform: 0.0);

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string DebuggerDisplay => $"X = {X}, Y = {Y}";

    public bool IsZero => X == 0.0 && Y == 0.0;

    public double X { get; }

    public double Y { get; }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Point2F);
    }

    public bool Equals(Point2F? other)
    {
        return other is not null && X == other.X && Y == other.Y;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    public static bool operator ==(Point2F? left, Point2F? right)
    {
        return left?.Equals(right) ?? right is null;
    }

    public static bool operator !=(Point2F? left, Point2F? right)
    {
        return !(left == right);
    }
}