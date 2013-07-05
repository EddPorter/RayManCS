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
  /// Subtracts two vectors.
  /// </summary>
  /// <param name="v1">The starting vector.</param>
  /// <param name="v2">The vector to subtract from the starting vector.</param>
  /// <returns>Returns the vector equivalent to going from v2 to v1.</returns>
  public static Vector operator -(Vector v1, Vector v2) {
    if (v1 == null) {
      throw new ArgumentNullException("v1");
    }
    if (v2 == null) {
      throw new ArgumentNullException("v2");
    }
    return new Vector(v1.X - v2.X, v1.Y - v2.Y, v1.Z - v2.Z);
  }

  /// <summary>
  /// Determines if two vectors are different.
  /// </summary>
  /// <param name="lhs">The first vector.</param>
  /// <param name="rhs">The second vector.</param>
  /// <returns>If the two points are different.</returns>
  public static bool operator !=(Vector lhs, Vector rhs) {
    return !(lhs == rhs);
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
  /// Computes the dot product of two vectors.
  /// </summary>
  /// <param name="lhs">The left vector.</param>
  /// <param name="rhs">The right vector.</param>
  /// <returns>The dot product of the two vectors.</returns>
  public static float operator *(Vector lhs, Vector rhs) {
    if (lhs == null) {
      throw new ArgumentNullException("lhs");
    }
    if (rhs == null) {
      throw new ArgumentNullException("rhs");
    }
    return lhs.X * rhs.X + lhs.Y * rhs.Y + lhs.Z * rhs.Z;
  }

  /// <summary>
  /// Scales a vector by a given factor.
  /// </summary>
  /// <param name="factor">The factor by which to scale the vector.</param>
  /// <param name="v">The vector to scale.</param>
  /// <returns>The scaled vector.</returns>
  public static Vector operator *(double factor, Vector v) {
    if (v == null) {
      throw new ArgumentNullException("v");
    }
    return new Vector((float)(v.X * factor), (float)(v.Y * factor), (float)(v.Z * factor));
  }

  /// <summary>
  /// Scales a vector by a given factor.
  /// </summary>
  /// <param name="v">The vector to scale.</param>
  /// <param name="factor">The factor by which to scale the vector.</param>
  /// <returns>The scaled vector.</returns>
  public static Vector operator *(Vector v, double factor) {
    return factor * v;
  }

  /// <summary>
  /// Adds a vector to a point.
  /// </summary>
  /// <param name="p">The point.</param>
  /// <param name="v">The vector to add to the point.</param>
  /// <returns>A new point.</returns>
  public static Point operator +(Point p, Vector v) {
    if (p == null) {
      throw new ArgumentNullException("p");
    }
    if (v == null) {
      throw new ArgumentNullException("v");
    }
    return new Point(p.X + v.X, p.Y + v.Y, p.Z + v.Z);
  }

  /// <summary>
  /// Adds a vector to a point.
  /// </summary>
  /// <param name="v">The vector to add to the point.</param>
  /// <param name="p">The point.</param>
  /// <returns>A new point.</returns>
  public static Point operator +(Vector v, Point p) {
    return p + v;
  }

  /// <summary>
  /// Determines if two vectors are equivalent.
  /// </summary>
  /// <param name="lhs">The first vector.</param>
  /// <param name="rhs">The second vector.</param>
  /// <returns>If the two vectors are equivalent.</returns>
  public static bool operator ==(Vector lhs, Vector rhs) {
    if (object.ReferenceEquals(lhs, rhs)) {
      return true;
    }
    if (object.ReferenceEquals(lhs, null) || object.ReferenceEquals(rhs, null)) {
      return false;
    }
    return lhs.X == rhs.X && lhs.Y == rhs.Y & lhs.Z == rhs.Z;
  }

  /// <summary>
  /// Determines whether the specified System.Object is equal to the current System.Object.
  /// </summary>
  /// <param name="obj">The object to compare with the current object.</param>
  /// <returns>true if the specified objcet is equal to the current Vector; otherwise, false.</returns>
  public override bool Equals(object obj) {
    return this == (obj as Vector);
  }

  /// <summary>
  /// Serves as a hash function for a vector.
  /// </summary>
  /// <returns>A hash code for the current Vector.</returns>
  public override int GetHashCode() {
    return new {
      X,
      Y,
      Z
    } .GetHashCode();
  }

  /// <summary>
  /// Calculates the norm, or length, of the vector.
  /// </summary>
  /// <remarks>The result of this function is non-negative.</remarks>
  /// <returns>The norm of the vector.</returns>
  public float Norm() {
    return (float)Math.Sqrt(X * X + Y * Y + Z * Z);
  }

  /// <summary>
  /// Returns a vector in the same direction but with unit length.
  /// </summary>
  /// <returns>A vector in the same direction  as the original but with unit length.</returns>
  public Vector Normalise() {
    float length = this.Norm();
    if (length == 0.0d) {
      return this;
    }
    return (1.0f / length) * this;
  }
}
}