using Padutronics.Diagnostics.Debugging;
using System;
using System.Diagnostics;

namespace Padutronics.Geometry;

[DebuggerDisplay(DebuggerDisplayValues.DebuggerDisplay)]
public sealed class Size : IEquatable<Size>
{
    public Size(int uniform) :
        this(uniform, uniform)
    {
    }

    public Size(int width, int height)
    {
        if (width < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(width), width, $"Width value {width} is out of range.");
        }
        if (height < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(height), height, $"Height value {height} is out of range.");
        }

        Height = height;
        Width = width;
    }

    public static Size Zero { get; } = new Size(uniform: 0);

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string DebuggerDisplay => $"Width = {Width}, Height = {Height}";

    public int Height { get; }

    public bool IsZero => Height == 0 && Width == 0;

    public int Width { get; }

    public override bool Equals(object? obj)
    {
        return Equals(obj as Size);
    }

    public bool Equals(Size? other)
    {
        return other is not null && Height == other.Height && Width == other.Width;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Height, Width);
    }

    public static bool operator ==(Size? left, Size? right)
    {
        return left?.Equals(right) ?? right is null;
    }

    public static bool operator !=(Size? left, Size? right)
    {
        return !(left == right);
    }
}