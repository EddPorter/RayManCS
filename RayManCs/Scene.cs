using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace RayManCS {

/// <summary>
/// Represents a scene to be ray traced.
/// </summary>
public sealed class Scene {
  private List<IObject> objects = new List<IObject>();
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
  /// The objects in the scene.
  /// </summary>
  public IReadOnlyCollection<IObject> Objects {
    get {
      return objects.AsReadOnly();
    }
  }

  /// <summary>
  /// Adds an object to the scene.
  /// </summary>
  /// <param name="o">The object to add.</param>
  public void AddObject(IObject o) {
    objects.Add(o);
  }

  /// <summary>
  /// Renders the image.
  /// </summary>
  public void Draw() {
    float widthRatio = (float)Camera.Width / output.Width;
    float heightRatio = (float)Camera.Height / output.Height;

    //ParallelOptions options = new ParallelOptions() {
    //  MaxDegreeOfParallelism = 1
    //};
    //Parallel.For(0, output.Height, options, (y) => {
    Parallel.For(0, output.Height, (y) => {
      for (var x = 0u; x < output.Width; ++x) {
        Ray r = Camera.GetRay(x * widthRatio, y * heightRatio);
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
    foreach (var o in Objects) {
      float t = o.IntersectDistance(ray);
      if (t >= 0.0f) {
        return Color.White;
      }
    }
    return Color.Black;
  }
}
}