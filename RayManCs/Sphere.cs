namespace RayManCS {

/// <summary>
/// Represents a spherical object in 3-dimensional space.
/// </summary>
public sealed class Sphere : Object {

  /// <summary>
  /// Creates a sphere in 3-dimensional space.
  /// </summary>
  /// <param name="centre">The centre point of the sphere.</param>
  /// <param name="radius">The radius of the sphere.</param>
  public Sphere(Point centre, float radius) {
    Centre = centre;
    Radius = radius;
  }

  /// <summary>
  /// Gets the centre of the sphere in 3-dimensional space.
  /// </summary>
  public Point Centre {
    get;
    private set;
  }

  /// <summary>
  /// Gets the radius of the sphere.
  /// </summary>
  public float Radius {
    get;
    private set;
  }

  /// <summary>
  /// Calculates the distance along the specified ray the first intersection with this object occurs.
  /// </summary>
  /// <param name="ray">The ray to test.</param>
  /// <returns>The distance along the ray the first intersection with this object occurs. If no intersection, returns a negative value.</returns>
  public override float IntersectDistance(Ray ray) {
    var P = ray.Start - Centre;
    var A = ray.Direction * ray.Direction;
    var B = 2 * P * ray.Direction;
    var C = P * P - Radius * Radius;
    var t = SolveQuadraticMinimumNonnegative(A, B, C);
    if (!t.HasValue) {
      return -1.0f;
    }
    return t.Value;
  }

  /// <summary>
  /// Calculates the normal vector to the surface of the sphere at the given point.
  /// </summary>
  /// <param name="point">The point on the surface of the sphere.</param>
  /// <returns>The normalised normal vector to the surface of the sphere at the given point.</returns>
  public override Vector GetNormalAtPoint(Point point) {
    // Assume that the given point is on the surface.
    return (point - Centre).Normalise();
  }
}
}