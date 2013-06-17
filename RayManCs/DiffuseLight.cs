namespace RayManCS {

/// <summary>
/// A diffuse light source.
/// </summary>
public sealed class DiffuseLight : Light {

  /// <summary>
  /// Creates a new diffuse light source.
  /// </summary>
  /// <param name="location">The location of the light source.</param>
  /// <param name="direction">The direction of the light source.</param>
  public DiffuseLight(Point location, Vector direction)
  : base(location, direction) {
  }
}
}