using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;

namespace RayManCS {

/// <summary>
/// Represents a scene to be ray traced.
/// </summary>
public sealed class Scene {
  private List<Light> lights = new List<Light>();
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
  /// The lights in the scene.
  /// </summary>
  public IReadOnlyCollection<Light> Lights {
    get {
      return lights.AsReadOnly();
    }
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
  /// Adds a light to the scene.
  /// </summary>
  /// <param name="l">The light to add.</param>
  public void AddLight(Light l) {
    lights.Add(l);
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

    ParallelOptions options = new ParallelOptions() {
      MaxDegreeOfParallelism = 1
    };
    Parallel.For(0, output.Height, options, (y) => {
    //Parallel.For(0, output.Height, (y) => {
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
    Colour output = new Colour(0.0f, 0.0f, 0.0f);

    IObject closestObject = null;
    float closestDistance = float.MaxValue;
    foreach (var o in Objects) {
      float t = o.IntersectDistance(ray);
      if (t >= 0.0f && t < closestDistance) {
        closestObject = o;
        closestDistance = t;
      }
    }
    if (closestObject == null) {
      return output;
    }

    // Calculate the point of intersection.
    Point intersection = ray.Start + closestDistance * ray.Direction;

    // Get normal of object surface at impact of ray.
    Vector normal = closestObject.GetNormalAtPoint(intersection);

    foreach (var l in Lights) {
      var lambertianReflectance = new Colour(0.0f, 0.0f, 0.0f);

      Vector toLightSource = (l.Location - intersection).Normalise();
      float cosineLightAngle = normal * toLightSource;
      if (cosineLightAngle > 0.0f) {
        // Light is above the surface: -90degrees < light < 90degrees.
        var lightColour = new Colour(1.0f, 1.0f, 1.0f);
        lambertianReflectance = lightColour * cosineLightAngle;
      }

      output += lambertianReflectance;
    }

    return output;
  }
}
}