using Padutronics.Diagnostics.Debugging;
using System;
using System.Diagnostics;

namespace Padutronics.Geometry;

[DebuggerDisplay(DebuggerDisplayValues.DebuggerDisplay)]
public sealed class CornerRadiusF : IEquatable<CornerRadiusF>
{
    public CornerRadiusF(double uniform) :
        this(uniform, uniform, uniform, uniform)
    {
    }

    public CornerRadiusF(double topLeft, double topRight, double bottomRight, double bottomLeft)
    {
        if (double.IsNaN(topLeft))
        {
            throw new ArgumentException("Top left corner radius value is NaN.", nameof(topLeft));
        }
        if (topLeft < 0.0)
        {
            throw new ArgumentOutOfRangeException(nameof(topLeft), topLeft, $"Top left corner radius value {topLeft} is out of range.");
        }
        if (double.IsNaN(topRight))
        {
            throw new ArgumentException("Top right corner radius value is NaN.", nameof(topRight));
        }
        if (topRight < 0.0)
        {
            throw new ArgumentOutOfRangeException(nameof(topRight), topRight, $"Top right corner radius value {topRight} is out of range.");
        }
        if (double.IsNaN(bottomRight))
        {
            throw new ArgumentException("Bottom right corner radius value is NaN.", nameof(bottomRight));
        }
        if (bottomRight < 0.0)
        {
            throw new ArgumentOutOfRangeException(nameof(bottomRight), bottomRight, $"Bottom right corner radius value {bottomRight} is out of range.");
        }
        if (double.IsNaN(bottomLeft))
        {
            throw new ArgumentException("Bottom left corner radius value is NaN.", nameof(bottomLeft));
        }
        if (bottomLeft < 0.0)
        {
            throw new ArgumentOutOfRangeException(nameof(bottomLeft), bottomLeft, $"Bottom left corner radius value {bottomLeft} is out of range.");
        }

        BottomLeft = bottomLeft;
        BottomRight = bottomRight;
        TopLeft = topLeft;
        TopRight = topRight;
    }

    public static CornerRadiusF Zero { get; } = new CornerRadiusF(uniform: 0.0);

    public double BottomLeft { get; }

    public double BottomRight { get; }

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string DebuggerDisplay => $"TopLeft = {TopLeft}, TopRight = {TopRight}, BottomRight = {BottomRight}, BottomLeft = {BottomLeft}";

    public bool IsZero => BottomLeft == 0.0 && BottomRight == 0.0 && TopLeft == 0.0 && TopRight == 0.0;

    public double TopLeft { get; }

    public double TopRight { get; }

    public override bool Equals(object? obj)
    {
        return Equals(obj as CornerRadiusF);
    }

    public bool Equals(CornerRadiusF? other)
    {
        return other is not null && BottomLeft == other.BottomLeft && BottomRight == other.BottomRight && TopLeft == other.TopLeft && TopRight == other.TopRight;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(BottomLeft, BottomRight, TopLeft, TopRight);
    }

    public static bool operator ==(CornerRadiusF? left, CornerRadiusF? right)
    {
        return left?.Equals(right) ?? right is null;
    }

    public static bool operator !=(CornerRadiusF? left, CornerRadiusF? right)
    {
        return !(left == right);
    }
}