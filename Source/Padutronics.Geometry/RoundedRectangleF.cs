using Padutronics.Diagnostics.Debugging;
using System;
using System.Diagnostics;

namespace Padutronics.Geometry;

[DebuggerDisplay(DebuggerDisplayValues.DebuggerDisplay)]
public sealed class RoundedRectangleF : IEquatable<RoundedRectangleF>
{
    public RoundedRectangleF(RectangleF rectangle, double uniformRadius) :
        this(rectangle, new CornerRadiusF(uniformRadius))
    {
    }

    public RoundedRectangleF(RectangleF rectangle, CornerRadiusF radius)
    {
        Radius = radius;
        Rectangle = rectangle;
    }

    public RoundedRectangleF(RectangleF rectangle, double topLeftRadius, double topRightRadius, double bottomRightRadius, double bottomLeftRadius) :
        this(rectangle, new CornerRadiusF(topLeftRadius, topRightRadius, bottomRightRadius, bottomLeftRadius))
    {
    }

    public RoundedRectangleF(Point2F location, double width, double height, double uniformRadius) :
        this(new RectangleF(location, width, height), new CornerRadiusF(uniformRadius))
    {
    }

    public RoundedRectangleF(Point2F location, double width, double height, CornerRadiusF radius) :
        this(new RectangleF(location, width, height), radius)
    {
    }

    public RoundedRectangleF(Point2F location, double width, double height, double topLeftRadius, double topRightRadius, double bottomRightRadius, double bottomLeftRadius) :
        this(new RectangleF(location, width, height), new CornerRadiusF(topLeftRadius, topRightRadius, bottomRightRadius, bottomLeftRadius))
    {
    }

    public RoundedRectangleF(double locationX, double locationY, SizeF size, double uniformRadius) :
        this(new RectangleF(locationX, locationY, size), new CornerRadiusF(uniformRadius))
    {
    }

    public RoundedRectangleF(double locationX, double locationY, SizeF size, CornerRadiusF radius) :
        this(new RectangleF(locationX, locationY, size), radius)
    {
    }

    public RoundedRectangleF(double locationX, double locationY, SizeF size, double topLeftRadius, double topRightRadius, double bottomRightRadius, double bottomLeftRadius) :
        this(new RectangleF(locationX, locationY, size), new CornerRadiusF(topLeftRadius, topRightRadius, bottomRightRadius, bottomLeftRadius))
    {
    }

    public RoundedRectangleF(double locationX, double locationY, double width, double height, double uniformRadius) :
        this(new RectangleF(locationX, locationY, width, height), new CornerRadiusF(uniformRadius))
    {
    }

    public RoundedRectangleF(double locationX, double locationY, double width, double height, CornerRadiusF radius) :
        this(new RectangleF(locationX, locationY, width, height), radius)
    {
    }

    public RoundedRectangleF(double locationX, double locationY, double width, double height, double topLeftRadius, double topRightRadius, double bottomRightRadius, double bottomLeftRadius) :
        this(new RectangleF(locationX, locationY, width, height), new CornerRadiusF(topLeftRadius, topRightRadius, bottomRightRadius, bottomLeftRadius))
    {
    }

    public static RoundedRectangleF Zero { get; } = new RoundedRectangleF(RectangleF.Zero, CornerRadiusF.Zero);

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string DebuggerDisplay => $"X = {Rectangle.Location.X}, Y = {Rectangle.Location.Y}, Width = {Rectangle.Size.Width}, Height = {Rectangle.Size.Height}, ({Radius.TopLeft}, {Radius.TopRight}, {Radius.BottomRight}, {Radius.BottomLeft})";

    public bool IsZero => Radius.IsZero && Rectangle.IsZero;

    public CornerRadiusF Radius { get; }

    public RectangleF Rectangle { get; }

    public override bool Equals(object? obj)
    {
        return Equals(obj as RoundedRectangleF);
    }

    public bool Equals(RoundedRectangleF? other)
    {
        return other is not null && Radius == other.Radius && Rectangle == other.Rectangle;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Radius, Rectangle);
    }

    public static bool operator ==(RoundedRectangleF? left, RoundedRectangleF? right)
    {
        return left?.Equals(right) ?? right is null;
    }

    public static bool operator !=(RoundedRectangleF? left, RoundedRectangleF? right)
    {
        return !(left == right);
    }
}