using System;

namespace RayManCS {

  /// <summary>
  /// Intermediate helper class for objects in the scene.
  /// </summary>
  public abstract class Object : IObject {

    /// <summary>
    /// Sets properties to default values.
    /// </summary>
    protected Object() {
      Material = new Material();
    }

    /// <summary>
    /// Gets and sets the object's material.
    /// </summary>
    public Material Material {
      get;
      set;
    }

    /// <summary>
    /// Calculates the normal vector to the surface of the object at the given point.
    /// </summary>
    /// <param name="point">The point on the surface of the object.</param>
    /// <returns>The normalised normal vector to the surface of the object at the given point.</returns>
    public abstract Vector GetNormalAtPoint(Point point);

    /// <summary>
    /// Calculates the distance along the specified ray the first intersection with this object occurs.
    /// </summary>
    /// <param name="ray">The ray to test.</param>
    /// <returns>The distance along the ray the first intersection with this object occurs. If no intersection, returns a negative value.</returns>
    public abstract float IntersectDistance(Ray ray);

    /// <summary>
    /// Solves a quadratic equation given the three coefficients for x^2, x, and contant terms. Returns the smaller of the two answers that is non-negative.
    /// </summary>
    /// <param name="a">The coefficient of x^2.</param>
    /// <param name="b">The coefficient of x.</param>
    /// <param name="c">The constant term.</param>
    /// <returns>The smaller of the two answers that is non-negative or null if there are no non-negative answers.</returns>
    protected internal static float? SolveQuadraticMinimumNonnegative(float a, float b, float c) {
      if (a == 0.0f) {
        throw new ArgumentOutOfRangeException("a");
      }

      float d = b * b - 4 * a * c;
      if (d < 0.0f) {
        return null;
      }
      double sqrtD = Math.Sqrt(d);
      double t1 = (-b - sqrtD) / 2.0d / a;
      double t2 = (-b + sqrtD) / 2.0d / a;
      if (t1 <= t2 && t1 >= 0.0d) {
        return (float)t1;
      } else if (t2 >= 0.0d) {
        return (float)t2;
      } else {
        return null;
      }
    }
  }
}