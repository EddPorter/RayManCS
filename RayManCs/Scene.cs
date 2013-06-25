using System.Collections.Generic;
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

    SubSampling = 1u;
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
  /// Gets and sets the length of side of the sub-sampling square to use. Default = 1 (no sub-sampling).
  /// </summary>
  public uint SubSampling {
    get;
    set;
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
#if DEBUG
      //      MaxDegreeOfParallelism = 1
#endif
    };
    Parallel.For(0, output.Height, options, (y) => {
      for (var x = 0u; x < output.Width; ++x) {
        float sampleWidth = 1.0f / SubSampling;
        float weight = sampleWidth / SubSampling;

        Colour outputColour = new Colour(0.0f, 0.0f, 0.0f);

        uint countX = 0u;
        for (float sampleX = x; countX < SubSampling; sampleX += sampleWidth, ++countX) {
          uint countY = 0u;
          for (float sampleY = y; countY < SubSampling; sampleY += sampleWidth, ++countY) {
            Ray r = Camera.GetRay(sampleX * widthRatio, sampleY * heightRatio);
            Colour c = ShootRay(r);
            outputColour += c * weight;
          }
        }

        output.Write((uint)x, (uint)y, outputColour);
      }
    });
  }

  /// <summary>
  /// Shoot a ray into the scene and determine the colour at the impact point.
  /// </summary>
  /// <param name="ray">The ray to shoot into the scene.</param>
  /// <returns>The colour of the impacted point in the scene.</returns>
  private Colour ShootRay(Ray ray) {
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
      Vector toLightSource = (l.Location - intersection).Normalise();

      bool inShadow = false;
      foreach (var o in Objects) {
        if (o == closestObject) {
          continue;
        }
        if (o.IntersectDistance(new Ray(intersection, toLightSource)) > 0.0f) {
          inShadow = true;
          break;
        }
      }
      
      if (!inShadow) {
        var lambertianReflectance = new Colour(0.0f, 0.0f, 0.0f);
        float cosineLightAngle = normal * toLightSource;
        if (cosineLightAngle > 0.0f) {
          // Light is above the surface: -90degrees < light < 90degrees.
          lambertianReflectance = (Colour)closestObject.Material.Colour * (Colour)l.Colour * cosineLightAngle;
        }
        output += lambertianReflectance;
      }
    }

    return output;
  }
}
}