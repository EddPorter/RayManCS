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
  public OrthographicCamera(Point position, Vector up, Vector right, float width, float height)
  : base(position, width, height) {
    Up = up.Normalise();
    Right = right.Normalise();

    if (Right * Up != 0.0f) {
      var normal = (Right % Up).Normalise();
      Right = (Up % normal).Normalise();
      Up = (normal % Right).Normalise();
    }
  }

  /// <summary>
  /// Creates a new orthopgrhic camera for a 3-dimensional scene, looking at a particular point.
  /// </summary>
  /// <param name="position">Position of the camera in 3-dimensional space.</param>
  /// <param name="lookAt">The point the camera should look at.</param>
  /// <param name="width">The width of the projection plane.</param>
  /// <param name="height">The height of the projection plane.</param>
  public OrthographicCamera(Point position, Point lookAt, float width, float height)
  : base(position, width, height) {
    var normal = (lookAt - position).Normalise();
    var yAxis = new Vector(0.0f, 1.0f, 0.0f);
    Right = (yAxis % normal).Normalise();
    Up = (normal % Right).Normalise();
  }

  /// <summary>
  /// Gets the right direction of the viewing plane.
  /// </summary>
  public Vector Right {
    get;
    private set;
  }

  /// <summary>
  /// Gets the "up" position of the projection plane.
  /// </summary>
  public Vector Up {
    get;
    private set;
  }

  internal override Ray GetRay(float xp, float yp) {
    if (xp >= Width) {
      throw new ArgumentOutOfRangeException("xp");
    }
    if (yp >= Height) {
      throw new ArgumentOutOfRangeException("yp");
    }

    var planePosition = Position + (xp - 0.5 * Width) * Right + (yp - 0.5 * Height) * Up;
    var viewDirection = Right % Up;

    return new Ray(planePosition, viewDirection);
  }
}
}