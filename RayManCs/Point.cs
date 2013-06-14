namespace RayManCS {

/// <summary>
/// Represents a single point in 3-dimensional space.
/// </summary>
public sealed class Point {

  /// <summary>
  /// Constructs a point at the specified co-ordinates in 3-dimensional space.
  /// </summary>
  /// <param name="x">The x co-ordinate.</param>
  /// <param name="y">The y co-ordinate.</param>
  /// <param name="z">The z co-ordinate.</param>
  public Point(float x, float y, float z) {
    X = x;
    Y = y;
    Z = z;
  }

  /// <summary>
  /// Get the x co-ordinate.
  /// </summary>
  public float X {
    get;
    private set;
  }

  /// <summary>
  /// Get the y co-ordinate.
  /// </summary>
  public float Y {
    get;
    private set;
  }

  /// <summary>
  /// Get the z co-ordinate.
  /// </summary>
  public float Z {
    get;
    private set;
  }
}
}