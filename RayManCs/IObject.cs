namespace RayManCS {

/// <summary>
/// An interface for objects in the scene.
/// </summary>
public interface IObject {

  /// <summary>
  /// Calculates the distance along the specified ray the first intersection with this object occurs.
  /// </summary>
  /// <param name="ray">The ray to test.</param>
  /// <returns>The distance along the ray the first intersection with this object occurs. If no intersection, returns a negative value.</returns>
  float IntersectDistance(Ray ray);

  /// <summary>
  /// Calculates the normal vector to the surface of the object at the given point.
  /// </summary>
  /// <param name="point">The point on the surface of the object.</param>
  /// <returns>The normalised normal vector to the surface of the object at the given point.</returns>
  Vector GetNormalAtPoint(Point point);
}
}