namespace RayManCS {

/// <summary>
/// A diffuse light source.
/// </summary>
public sealed class DiffuseLight : Light {

  /// <summary>
  /// Creates a new diffuse light source.
  /// </summary>
  /// <param name="location">The location of the light source.</param>
  public DiffuseLight(Point location)
  : base(location) {
  }
}
}