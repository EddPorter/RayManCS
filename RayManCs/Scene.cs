using System.Drawing;
using System.Threading.Tasks;

namespace RayManCS {

/// <summary>
/// Represents a scene to be ray traced.
/// </summary>
public sealed class Scene {
  private IOutput output;

  /// <summary>
  /// Constructs a new scene with a given output receiver.
  /// </summary>
  /// <param name="output">The class to which to send the generated image.</param>
  public Scene(IOutput output) {
    this.output = output;
  }

  /// <summary>
  /// Gets or sets the camera for the scene.
  /// </summary>
  public Camera Camera {
    get;
    set;
  }

  /// <summary>
  /// Renders the image.
  /// </summary>
  public void Draw() {
    float widthRatio = (float)Camera.Width / output.Width;
    float heightRatio = (float)Camera.Height / output.Height;

    Parallel.For(0, output.Height, (y) => {
      for (var x = 0u; x < output.Width; ++x) {
        Ray r = Camera.GetRay((uint)(x * widthRatio), (uint)(y * heightRatio));
        Color c = ShootRay(r);

        output.Write((uint)x, (uint)y, c);
      }
    });
  }

  /// <summary>
  /// Shoot a ray into the scene and determine the colour at the impact point.
  /// </summary>
  /// <param name="ray">The ray to shoot into the scene.</param>
  /// <returns>The colour of the impacted point in the scene.</returns>
  private Color ShootRay(Ray ray) {
    return Color.Black;
  }
}
}