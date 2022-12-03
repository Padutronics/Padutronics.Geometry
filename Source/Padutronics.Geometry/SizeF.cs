using Padutronics.Diagnostics.Debugging;
using System;
using System.Diagnostics;

namespace Padutronics.Geometry;

[DebuggerDisplay(DebuggerDisplayValues.DebuggerDisplay)]
public sealed class SizeF : IEquatable<SizeF>
{
    public SizeF(double uniform) :
        this(uniform, uniform)
    {
    }

    public SizeF(double width, double height)
    {
        if (double.IsNaN(width))
        {
            throw new ArgumentException("Width value is NaN.", nameof(width));
        }
        if (width < 0.0)
        {
            throw new ArgumentOutOfRangeException(nameof(width), width, $"Width value {width} is out of range.");
        }
        if (double.IsNaN(height))
        {
            throw new ArgumentException("Height value is NaN.", nameof(height));
        }
        if (height < 0.0)
        {
            throw new ArgumentOutOfRangeException(nameof(height), height, $"Height value {height} is out of range.");
        }

        Height = height;
        Width = width;
    }

    public static SizeF Zero { get; } = new SizeF(uniform: 0.0);

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string DebuggerDisplay => $"Width = {Width}, Height = {Height}";

    public double Height { get; }

    public bool IsZero => Height == 0.0 && Width == 0.0;

    public double Width { get; }

    public override bool Equals(object? obj)
    {
        return Equals(obj as SizeF);
    }

    public bool Equals(SizeF? other)
    {
        return other is not null && Height == other.Height && Width == other.Width;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Height, Width);
    }

    public static bool operator ==(SizeF? left, SizeF? right)
    {
        return left?.Equals(right) ?? right is null;
    }

    public static bool operator !=(SizeF? left, SizeF? right)
    {
        return !(left == right);
    }
}