using System;

namespace RayManCS {

/// <summary>
/// Represents an orthographic porjection camera for a 3-dimensional scene.
/// </summary>
public sealed class OrthographicCamera : Camera {

  /// <summary>
  /// Creates a new orthographic camera for a 3-dimensional scene.
  /// </summary>
  /// <param name="position">Position of the camera in the 3-dimensional scene.</param>
  /// <param name="up">The up direction of the viewing plane.</param>
  /// <param name="right">The right direction of the viewing plane.</param>
  /// <param name="width">The width of the projection plane.</param>
  /// <param name="height">The height of the projection plane.</param>
  public OrthographicCamera(Point position, Vector up, Vector right, uint width, uint height)
  : base(position, up, right, width, height) {
  }

  internal override Ray GetRay(uint xp, uint yp) {
    if (xp >= Width) {
      throw new ArgumentOutOfRangeException("xp");
    }
    if (yp >= Height) {
      throw new ArgumentOutOfRangeException("yp");
    }

    var planePosition = Position + ((xp / (float)Width) - 0.5 * Width) * Right + ((yp / (float)Height) - 0.5 * Height) * Up;
    var viewDirection = Right % Up;

    return new Ray(planePosition, viewDirection);
  }
}
}