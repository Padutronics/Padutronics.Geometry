using Padutronics.Diagnostics.Debugging;
using System;
using System.Diagnostics;

namespace Padutronics.Geometry;

[DebuggerDisplay(DebuggerDisplayValues.DebuggerDisplay)]
public sealed class EllipseF : IEquatable<EllipseF>
{
    public EllipseF(Point2F origin, double uniformRadius) :
        this(origin, new UniformCornerRadiusF(uniformRadius))
    {
    }

    public EllipseF(Point2F origin, UniformCornerRadiusF radius)
    {
        Origin = origin;
        Radius = radius;
    }

    public EllipseF(Point2F origin, double radiusX, double radiusY) :
        this(origin, new UniformCornerRadiusF(radiusX, radiusY))
    {
    }

    public EllipseF(double originX, double originY, double uniformRadius) :
        this(new Point2F(originX, originY), new UniformCornerRadiusF(uniformRadius))
    {
    }

    public EllipseF(double originX, double originY, UniformCornerRadiusF radius) :
        this(new Point2F(originX, originY), radius)
    {
    }

    public EllipseF(double originX, double originY, double radiusX, double radiusY) :
        this(new Point2F(originX, originY), new UniformCornerRadiusF(radiusX, radiusY))
    {
    }

    public static EllipseF Zero { get; } = new EllipseF(Point2F.Zero, UniformCornerRadiusF.Zero);

    [DebuggerBrowsable(DebuggerBrowsableState.Never)]
    private string DebuggerDisplay => $"Origin = (X: {Origin.X}, Y: {Origin.Y}), Radius = (X: {Radius.X}, Y = {Radius.Y})";

    public bool IsZero => Origin.IsZero && Radius.IsZero;

    public Point2F Origin { get; }

    public UniformCornerRadiusF Radius { get; }

    public override bool Equals(object? obj)
    {
        return Equals(obj as EllipseF);
    }

    public bool Equals(EllipseF? other)
    {
        return other is not null && Origin == other.Origin && Radius == other.Radius;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Origin, Radius);
    }

    public static bool operator ==(EllipseF? left, EllipseF? right)
    {
        return left?.Equals(right) ?? right is null;
    }

    public static bool operator !=(EllipseF? left, EllipseF? right)
    {
        return !(left == right);
    }
}