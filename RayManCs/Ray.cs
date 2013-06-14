namespace RayManCS {

/// <summary>
/// Represents a ray in 3-dimensional space.
/// </summary>
public sealed class Ray {

  /// <summary>
  /// Constructs a ray in 3-dimensional space.
  /// </summary>
  /// <param name="start">The starting point of the ray.</param>
  /// <param name="direction">The direction of the ray.</param>
  public Ray(Point start, Vector direction) {
    Start = start;
    Direction = direction;
  }

  /// <summary>
  /// Gets the direction of the ray.
  /// </summary>
  public Vector Direction {
    get;
    private set;
  }

  /// <summary>
  /// Gets the starting point of the ray.
  /// </summary>
  public Point Start {
    get;
    private set;
  }
}
}