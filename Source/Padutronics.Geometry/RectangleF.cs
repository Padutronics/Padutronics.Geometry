using Padutronics.Diagnostics.Debugging;
using System;
using System.Diagnostics;

namespace Padutronics.Geometry;

[DebuggerDisplay(DebuggerDisplayValues.DebuggerDisplay)]
public sealed class RectangleF : IEquatable<RectangleF>
{
    public RectangleF(Point2F location, SizeF size)
    {
        Location = location;
        Size = size;
    }

    public RectangleF(Point2F location, double width, double height) :
        this(location, new SizeF(width, height))
    {
    }

    public RectangleF(double x, double y, SizeF size) :
        this(new Point2F(x, y), size)
    {
    }

    public RectangleF(double x, double y, double width, double height) :
        this(new Point2F(x, y), new SizeF(width, height))
    {
    }

    public static RectangleF Zero { get; } = new RectangleF(Point2F.Zero, SizeF.Zero);

    public double Bottom => Top + Size.Height;

    public Point2F BottomLeft => new(Left, Bottom);

    public LineF BottomLine => new(BottomRight, BottomLeft);

    public Point2F BottomRight => new(Right, Bottom);

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string DebuggerDisplay => $"X = {Location.X}, Y = {Location.Y}, Width = {Size.Width}, Height = {Size.Height}";

    public bool IsZero => Location.IsZero && Size.IsZero;

    public double Left => Location.X;

    public LineF LeftLine => new(BottomLeft, TopLeft);

    public Point2F Location { get; }

    public double Right => Left + Size.Width;

    public LineF RightLine => new(TopRight, BottomRight);

    public SizeF Size { get; }

    public double Top => Location.Y;

    public Point2F TopLeft => new(Left, Top);

    public LineF TopLine => new(TopLeft, TopRight);

    public Point2F TopRight => new(Right, Top);

    public override bool Equals(object? obj)
    {
        return Equals(obj as RectangleF);
    }

    public bool Equals(RectangleF? other)
    {
        return other is not null && Location == other.Location && Size == other.Size;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Location, Size);
    }

    public static bool operator ==(RectangleF? left, RectangleF? right)
    {
        return left?.Equals(right) ?? right is null;
    }

    public static bool operator !=(RectangleF? left, RectangleF? right)
    {
        return !(left == right);
    }
}