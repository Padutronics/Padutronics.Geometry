using Padutronics.Diagnostics.Debugging;
using System;
using System.Diagnostics;

namespace Padutronics.Geometry;

[DebuggerDisplay(DebuggerDisplayValues.DebuggerDisplay)]
public sealed class Offset2F : IEquatable<Offset2F>
{
    public Offset2F(double uniform) :
        this(uniform, uniform)
    {
    }

    public Offset2F(double x, double y)
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

    public static Offset2F Zero { get; } = new Offset2F(uniform: 0.0);

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string DebuggerDisplay => $"X = {X}, Y = {Y}";

    public bool IsZero => X == 0.0 && Y == 0.0;

    public double X { get; }

    public double Y { get; }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Offset2F);
    }

    public bool Equals(Offset2F? other)
    {
        return other is not null && X == other.X && Y == other.Y;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    public static bool operator ==(Offset2F? left, Offset2F? right)
    {
        return left?.Equals(right) ?? right is null;
    }

    public static bool operator !=(Offset2F? left, Offset2F? right)
    {
        return !(left == right);
    }
}