namespace RayManCS {

/// <summary>
/// An abstract light source.
/// </summary>
public abstract class Light {

  /// <summary>
  /// Creates a new light.
  /// </summary>
  /// <param name="location">The location of the light.</param>
  /// <param name="direction">The direction of the light.</param>
  public Light(Point location, Vector direction) {
    Location = location;
    Direction = direction.Normalise();
  }

  /// <summary>
  /// Gets the direction of the light.
  /// </summary>
  public Vector Direction {
    get;
    private set;
  }

  /// <summary>
  /// The location of the light source.
  /// </summary>
  public Point Location {
    get;
    private set;
  }
}
}