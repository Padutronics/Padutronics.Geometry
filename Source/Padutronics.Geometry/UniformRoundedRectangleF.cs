using Padutronics.Diagnostics.Debugging;
using System;
using System.Diagnostics;

namespace Padutronics.Geometry;

[DebuggerDisplay(DebuggerDisplayValues.DebuggerDisplay)]
public sealed class UniformRoundedRectangleF : IEquatable<UniformRoundedRectangleF>
{
    public UniformRoundedRectangleF(RectangleF rectangle, double uniformRadius) :
        this(rectangle, new UniformCornerRadiusF(uniformRadius))
    {
    }

    public UniformRoundedRectangleF(RectangleF rectangle, UniformCornerRadiusF radius)
    {
        Radius = radius;
        Rectangle = rectangle;
    }

    public UniformRoundedRectangleF(RectangleF rectangle, double radiusX, double radiusY) :
        this(rectangle, new UniformCornerRadiusF(radiusX, radiusY))
    {
    }

    public UniformRoundedRectangleF(Point2F location, double width, double height, double uniformRadius) :
        this(new RectangleF(location, width, height), new UniformCornerRadiusF(uniformRadius))
    {
    }

    public UniformRoundedRectangleF(Point2F location, double width, double height, UniformCornerRadiusF radius) :
        this(new RectangleF(location, width, height), radius)
    {
    }

    public UniformRoundedRectangleF(Point2F location, double width, double height, double radiusX, double radiusY) :
        this(new RectangleF(location, width, height), new UniformCornerRadiusF(radiusX, radiusY))
    {
    }

    public UniformRoundedRectangleF(double locationX, double locationY, SizeF size, double uniformRadius) :
        this(new RectangleF(locationX, locationY, size), new UniformCornerRadiusF(uniformRadius))
    {
    }

    public UniformRoundedRectangleF(double locationX, double locationY, SizeF size, UniformCornerRadiusF radius) :
        this(new RectangleF(locationX, locationY, size), radius)
    {
    }

    public UniformRoundedRectangleF(double locationX, double locationY, SizeF size, double radiusX, double radiusY) :
        this(new RectangleF(locationX, locationY, size), new UniformCornerRadiusF(radiusX, radiusY))
    {
    }

    public UniformRoundedRectangleF(double locationX, double locationY, double width, double height, double uniformRadius) :
        this(new RectangleF(locationX, locationY, width, height), new UniformCornerRadiusF(uniformRadius))
    {
    }

    public UniformRoundedRectangleF(double locationX, double locationY, double width, double height, UniformCornerRadiusF radius) :
        this(new RectangleF(locationX, locationY, width, height), radius)
    {
    }

    public UniformRoundedRectangleF(double locationX, double locationY, double width, double height, double radiusX, double radiusY) :
        this(new RectangleF(locationX, locationY, width, height), new UniformCornerRadiusF(radiusX, radiusY))
    {
    }

    public static UniformRoundedRectangleF Zero { get; } = new UniformRoundedRectangleF(RectangleF.Zero, UniformCornerRadiusF.Zero);

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string DebuggerDisplay => $"X = {Rectangle.Location.X}, Y = {Rectangle.Location.Y}, Width = {Rectangle.Size.Width}, Height = {Rectangle.Size.Height}, ({Radius.X}, {Radius.Y})";

    public bool IsZero => Radius.IsZero && Rectangle.IsZero;

    public UniformCornerRadiusF Radius { get; }

    public RectangleF Rectangle { get; }

    public override bool Equals(object? obj)
    {
        return Equals(obj as UniformRoundedRectangleF);
    }

    public bool Equals(UniformRoundedRectangleF? other)
    {
        return other is not null && Radius == other.Radius && Rectangle == other.Rectangle;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Radius, Rectangle);
    }

    public static bool operator ==(UniformRoundedRectangleF? left, UniformRoundedRectangleF? right)
    {
        return left?.Equals(right) ?? right is null;
    }

    public static bool operator !=(UniformRoundedRectangleF? left, UniformRoundedRectangleF? right)
    {
        return !(left == right);
    }
}