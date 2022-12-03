using Padutronics.Diagnostics.Debugging;
using System;
using System.Diagnostics;

namespace Padutronics.Geometry;

[DebuggerDisplay(DebuggerDisplayValues.DebuggerDisplay)]
public sealed class UniformCornerRadiusF : IEquatable<UniformCornerRadiusF>
{
    public UniformCornerRadiusF(double uniform) :
        this(uniform, uniform)
    {
    }

    public UniformCornerRadiusF(double x, double y)
    {
        if (double.IsNaN(x))
        {
            throw new ArgumentException("Horizontal radius value is NaN.", nameof(x));
        }
        if (x < 0.0)
        {
            throw new ArgumentOutOfRangeException(nameof(x), x, $"Horizontal radius value {x} is out of range.");
        }
        if (double.IsNaN(y))
        {
            throw new ArgumentException("Vertical radius value is NaN.", nameof(y));
        }
        if (y < 0.0)
        {
            throw new ArgumentOutOfRangeException(nameof(y), y, $"Vertical radius value {y} is out of range.");
        }

        X = x;
        Y = y;
    }

    public static UniformCornerRadiusF Zero { get; } = new UniformCornerRadiusF(uniform: 0.0);

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string DebuggerDisplay => $"X = {X}, Y = {Y}";

    public bool IsZero => X == 0.0 && Y == 0.0;

    public double X { get; }

    public double Y { get; }

    public override bool Equals(object? obj)
    {
        return Equals(obj as UniformCornerRadiusF);
    }

    public bool Equals(UniformCornerRadiusF? other)
    {
        return other is not null && X == other.X && Y == other.Y;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    public static bool operator ==(UniformCornerRadiusF? left, UniformCornerRadiusF? right)
    {
        return left?.Equals(right) ?? right is null;
    }

    public static bool operator !=(UniformCornerRadiusF? left, UniformCornerRadiusF? right)
    {
        return !(left == right);
    }
}