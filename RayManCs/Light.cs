using System.Drawing;

namespace RayManCS {

/// <summary>
/// An abstract light source.
/// </summary>
public abstract class Light {

  /// <summary>
  /// Creates a new light.
  /// </summary>
  /// <param name="location">The location of the light.</param>
  public Light(Point location) {
    Location = location;

    Colour = Color.White;
  }

  /// <summary>
  /// The colour of the light.
  /// </summary>
  public Color Colour {
    get;
    set;
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