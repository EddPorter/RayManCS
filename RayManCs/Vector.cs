using System;

namespace RayManCS {

/// <summary>
/// Represents a single vector in 3-dimensional space.
/// </summary>
public sealed class Vector {

  /// <summary>
  /// Constructs a vector in 3-dimensional space.
  /// </summary>
  /// <param name="x">The length along the x axis.</param>
  /// <param name="y">The length along the y axis.</param>
  /// <param name="z">The length along the z axis.</param>
  public Vector(float x, float y, float z) {
    X = x;
    Y = y;
    Z = z;
  }

  /// <summary>
  /// Get the length along the x axis.
  /// </summary>
  public float X {
    get;
    private set;
  }

  /// <summary>
  /// Get the length along the y axis.
  /// </summary>
  public float Y {
    get;
    private set;
  }

  /// <summary>
  /// Get the length along the z axis.
  /// </summary>
  public float Z {
    get;
    private set;
  }

  /// <summary>
  /// Performs the cross-product of two vectors.
  /// </summary>
  /// <remarks>This operator is anti-commutative: x%y == -(y%x).</remarks>
  /// <param name="lhs">The left-hand side vector.</param>
  /// <param name="rhs">The right-hand side vector.</param>
  /// <returns>The cross-product of the two vectors.</returns>
  public static Vector operator %(Vector lhs, Vector rhs) {
    return new Vector(lhs.Y * rhs.Z - lhs.Z * rhs.Y, lhs.Z * rhs.X - lhs.X * rhs.Z, lhs.X * rhs.Y - lhs.Y * rhs.X);
  }

  /// <summary>
  /// Scales a vector by a given factor.
  /// </summary>
  /// <param name="v"></param>
  /// <param name="factor"></param>
  /// <returns></returns>
  public static Vector operator *(Vector v, float factor) {
    return new Vector(v.X * factor, v.Y * factor, v.Z * factor);
  }

  /// <summary>
  /// Scales a vector by a given factor.
  /// </summary>
  /// <param name="v"></param>
  /// <param name="factor"></param>
  /// <returns></returns>
  public static Vector operator *(double factor, Vector v) {
    return new Vector((float)(v.X * factor), (float)(v.Y * factor), (float)(v.Z * factor));
  }

  /// <summary>
  /// Adds a vector to a point.
  /// </summary>
  /// <param name="p">The point.</param>
  /// <param name="v">The vector to add to the point.</param>
  /// <returns>A new point.</returns>
  public static Point operator +(Point p, Vector v) {
    return new Point(p.X + v.X, p.Y + v.Y, p.Z + v.Z);
  }

  /// <summary>
  /// Calculates the norm, or length, of the vector.
  /// </summary>
  /// <remarks>The result of this function is non-negative.</remarks>
  /// <returns>The norm of the vector.</returns>
  public float Norm() {
    return (float)Math.Sqrt(X * X + Y * Y + Z * Z);
  }
}
}