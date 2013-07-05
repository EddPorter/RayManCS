namespace RayManCS {

/// <summary>
/// Represents a single point in 3-dimensional space.
/// </summary>
public sealed class Point {

  /// <summary>
  /// Constructs a point at the specified co-ordinates in 3-dimensional space.
  /// </summary>
  /// <param name="x">The x co-ordinate.</param>
  /// <param name="y">The y co-ordinate.</param>
  /// <param name="z">The z co-ordinate.</param>
  public Point(float x, float y, float z) {
    X = x;
    Y = y;
    Z = z;
  }

  /// <summary>
  /// Get the x co-ordinate.
  /// </summary>
  public float X {
    get;
    private set;
  }

  /// <summary>
  /// Get the y co-ordinate.
  /// </summary>
  public float Y {
    get;
    private set;
  }

  /// <summary>
  /// Get the z co-ordinate.
  /// </summary>
  public float Z {
    get;
    private set;
  }

  /// <summary>
  /// Calculates the vector between two points.
  /// </summary>
  /// <param name="lhs">The starting point.</param>
  /// <param name="rhs">The finishing point.</param>
  /// <returns>The vector between the two given points.</returns>
  public static Vector operator -(Point lhs, Point rhs) {
    return new Vector(lhs.X - rhs.X, lhs.Y - rhs.Y, lhs.Z - rhs.Z);
  }

  /// <summary>
  /// Determines if two points are different.
  /// </summary>
  /// <param name="lhs">The first point.</param>
  /// <param name="rhs">The second point.</param>
  /// <returns>If the two points are different.</returns>
  public static bool operator !=(Point lhs, Point rhs) {
    return !(lhs == rhs);
  }

  /// <summary>
  /// Determines if two points are equivalent.
  /// </summary>
  /// <param name="lhs">The first point.</param>
  /// <param name="rhs">The second point.</param>
  /// <returns>If the two points are equivalent.</returns>
  public static bool operator ==(Point lhs, Point rhs) {
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
  /// <returns>true if the specified object is equal to the current Point; otherwise, false.</returns>
  public override bool Equals(object obj) {
    return this == (obj as Point);
  }

  /// <summary>
  /// Serves as a hash function for a point.
  /// </summary>
  /// <returns>A hash code for the current Point.</returns>
  public override int GetHashCode() {
    return new {
      X,
      Y,
      Z
    } .GetHashCode();
  }
}
}