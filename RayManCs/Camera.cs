namespace RayManCS {

  /// <summary>
  /// Represents an abstract viewing camera for a 3-dimensional scene.
  /// </summary>
  public abstract class Camera {

    /// <summary>
    /// Creates a new camera for a 3-dimensional scene.
    /// </summary>
    /// <param name="position">Position of the camera in the 3-dimensional scene.</param>
    /// <param name="up">The up direction of the viewing plane.</param>
    /// <param name="right">The right direction of the viewing plane.</param>
    /// <param name="width">The width of the projection plane.</param>
    /// <param name="height">The height of the projection plane.</param>
    protected Camera(Point position, Vector up, Vector right, float width, float height) {
      Position = position;
      Up = up;
      Right = right;
      Width = width;
      Height = height;
    }

    /// <summary>
    /// Gets the projection plane height.
    /// </summary>
    public float Height {
      get;
      private set;
    }

    /// <summary>
    /// Gets the position of the camera in 3-dimensional space.
    /// </summary>
    public Point Position {
      get;
      private set;
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

    /// <summary>
    /// Gets the projection plane width.
    /// </summary>
    public float Width {
      get;
      private set;
    }

    /// <summary>
    /// Returns the ray passing through the given point on the view plane.
    /// </summary>
    /// <param name="x">The local x co-ordinate on the 2-dimensional view plane.</param>
    /// <param name="y">The local y co-ordinate on the 2-dimensional view plane.</param>
    /// <returns>A ray passing through specified point on the view plane with the correct direction for the camera type.</returns>
    internal abstract Ray GetRay(float x, float y);
  }
}