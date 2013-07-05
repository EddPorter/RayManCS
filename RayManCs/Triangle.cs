using System;

namespace RayManCS {

/// <summary>
/// Represents a flat triangle in 3-dimensional space.
/// </summary>
public sealed class Triangle : Object {
  private readonly float d;
  private readonly Vector normal;

  /// <summary>
  /// Creates a triangle in 3-dimensional space.
  /// </summary>
  /// <remarks>We assume points are specified in clockwise fashion to form the top of the triangle.</remarks>
  /// <param name="p1">The first point of the triangle.</param>
  /// <param name="p2">The second point of the triangle.</param>
  /// <param name="p3">The third point of the triangle.</param>
  public Triangle(Point p1, Point p2, Point p3) {
    if (p1 == null) {
      throw new ArgumentNullException("p1");
    }
    if (p2 == null) {
      throw new ArgumentNullException("p2");
    }
    if (p3 == null) {
      throw new ArgumentNullException("p3");
    }
    P1 = p1;
    P2 = p2;
    P3 = p3;

    // Pre-calculate.
    normal = ((P2 - P1) % (P3 - P1)).Normalise();
    if (normal == new Vector(0.0f, 0.0f, 0.0f)) {
      // Points form a line.
      throw new ArgumentOutOfRangeException("p3");
    }
    d = normal * new Vector(P1.X, p1.Y, p1.Z);
  }

  /// <summary>
  /// Gets the first point of the triangle.
  /// </summary>
  public Point P1 {
    get;
    private set;
  }

  /// <summary>
  /// Gets the second point of the triangle.
  /// </summary>
  public Point P2 {
    get;
    private set;
  }

  /// <summary>
  /// Gets the third point of the triangle.
  /// </summary>
  public Point P3 {
    get;
    private set;
  }

  /// <summary>
  /// Calculates the normal vector to the surface of the triangle at the given point.
  /// </summary>
  /// <remarks>The points of the triangle define the "top" surface of the triangle as that where they are in anti-clockwise order (right-hand rule).</remarks>
  /// <param name="point">The point on the surface of the triangle.</param>
  /// <returns>The normalised normal vector to the surface of the triangle at the given point.</returns>
  public override Vector GetNormalAtPoint(Point point) {
    return normal;
  }

  /// <summary>
  /// Calculates the distance along the specified ray the first intersection with this object occurs.
  /// </summary>
  /// <param name="ray">The ray to test.</param>
  /// <returns>The distance along the ray the first intersection with this object occurs. If no intersection, returns a negative value.</returns>
  public override float IntersectDistance(Ray ray) {
    if (ray == null) {
      throw new ArgumentNullException("ray");
    }

    var nd = normal * ray.Direction;
    if (nd == 0) {
      return -1.0f;
    }
    var start = new Vector(ray.Start.X, ray.Start.Y, ray.Start.Z);
    var t = (d - normal * start) / (nd);

    var q = ray.Start + t * ray.Direction;
    if (((P2 - P1) % (q - P1)) * normal < 0.0f) {
      return -1.0f;
    }
    if (((P3 - P2) % (q - P2)) * normal < 0.0f) {
      return -1.0f;
    }
    if (((P1 - P3) % (q - P3)) * normal < 0.0f) {
      return -1.0f;
    }
    return t;
  }
}
}