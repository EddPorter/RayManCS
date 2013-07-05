using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RayManCS {

/// <summary>
/// Represents a scene to be ray traced.
/// </summary>
public sealed class Scene {
  private const uint MAX_ITERATIONS = 10;
  private List<Light> lights = new List<Light>();
  private List<IObject> objects = new List<IObject>();
  private IOutput output;

  /// <summary>
  /// Constructs a new scene with a given output receiver.
  /// </summary>
  /// <param name="output">The class to which to send the generated image.</param>
  public Scene(IOutput output) {
    if (output == null) {
      throw new ArgumentNullException("output");
    }
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
    float exposure = CalculateExposure();

    float widthRatio = (float)Camera.Width / output.Width;
    float heightRatio = (float)Camera.Height / output.Height;

    ParallelOptions options = new ParallelOptions() {
#if DEBUG
      //MaxDegreeOfParallelism = 1
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

            Colour exposedColour = new Colour(1.0f - (float)Math.Exp(c.Red * exposure),
            1.0f - (float)Math.Exp(c.Green * exposure),
            1.0f - (float)Math.Exp(c.Blue * exposure));

            outputColour += exposedColour * weight;
          }
        }

        Colour sRgbColour = outputColour.ToSrgb();
        output.Write((uint)x, (uint)y, sRgbColour);
      }
    });
  }

  private float CalculateExposure() {
    const uint SAMPLE_COUNT = 16;
    uint sampleFactor = (uint)(Math.Min(Camera.Width - 1, Camera.Height - 1) / (float)SAMPLE_COUNT);
    const float weight = 1.0f / (SAMPLE_COUNT * SAMPLE_COUNT);
    float luminanceSquared = 0.0f;
    ParallelOptions options = new ParallelOptions() {
#if DEBUG
      MaxDegreeOfParallelism = 1
#endif
    };
    Parallel.For(0, SAMPLE_COUNT, (yCount) => {
      uint y = (uint)yCount * sampleFactor;
      for (var x = 0u; x < Camera.Width; x += sampleFactor) {
        Ray r = Camera.GetRay(x, y);
        Colour c = ShootRay(r);

        float luminance = 0.2126f * c.Red + 0.715160f * c.Green + 0.072169f * c.Blue;
        luminanceSquared += weight * (luminance * luminance);
      }
    });

    float sqrtLuminance = (float)Math.Sqrt(luminanceSquared);
    if (sqrtLuminance > 0.0f) {
      // put the medium luminance to an intermediate gray value
      //return logf(0.6f) / mediumLuminance;
      //return - logf(1.0f - myScene.tonemap.fMidPoint) / mediumLuminance;
      return (float)Math.Log(0.6) / sqrtLuminance;
    }

    return -1.0f;
  }

  /// <summary>
  /// Shoot a ray into the scene and determine the colour at the impact point.
  /// </summary>
  /// <param name="ray">The ray to shoot into the scene.</param>
  /// <returns>The colour of the impacted point in the scene.</returns>
  private Colour ShootRay(Ray ray) {
    Colour finalOutput = new Colour(0.0f, 0.0f, 0.0f);
    float coefficient = 1.0f;
    uint count = 0u;

    do {
      Colour output = new Colour(0.0f, 0.0f, 0.0f);
      IObject closestObject = null;
      float closestDistance = float.MaxValue;
      foreach (var o in Objects) {
        float t = o.IntersectDistance(ray);
        if (t > 0.001f && t < closestDistance) {
          closestObject = o;
          closestDistance = t;
        }
      }
      if (closestObject == null) {
        break;
      }

      // Calculate the point of intersection.
      Point intersection = ray.Start + closestDistance * ray.Direction;

      // Get normal of object surface at impact of ray.
      Vector normal = closestObject.GetNormalAtPoint(intersection);

      foreach (var l in Lights) {
        Vector toLightSource = (l.Location - intersection).Normalise();
        float cosineLightAngle = normal * toLightSource;
        if (cosineLightAngle <= 0.0f) {
          // The light is below the surface.
          continue;
        }

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
          var lambertianReflectance = (Colour)closestObject.Material.Colour * (Colour)l.Colour * cosineLightAngle;
          output += lambertianReflectance;

          var halfwayVector = (toLightSource - ray.Direction).Normalise();
          var halfwayNormalAngle = halfwayVector * normal;
          var blinnTerm = (Colour)l.Colour * closestObject.Material.SpecularTerm * (float)Math.Pow(Math.Max(halfwayNormalAngle, 0.0f), closestObject.Material.SpecularPower);
          output += blinnTerm;
        }
      }

      finalOutput += output * coefficient;

      var newRayDirection = (ray.Direction - 2 * normal * (normal * ray.Direction)).Normalise();
      ray = new Ray(intersection, newRayDirection);
      coefficient *= closestObject.Material.Reflectance;
    } while (++count < MAX_ITERATIONS && coefficient > 0.0f);
    return finalOutput;
  }
}
}