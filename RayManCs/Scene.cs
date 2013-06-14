﻿using System.Drawing;
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

      Parallel.For(0, output.Width * output.Height, (p) => {
        uint x = (uint)p % output.Width;
        uint y = (uint)p / output.Width;

        Ray r = Camera.GetRay((uint)(x * widthRatio), (uint)(y * heightRatio));
        Color c = ShootRay(r);

        output.Write(x, y, c);
      });
    }

    private Color ShootRay(Ray r) {
      return Color.Black;
    }
  }
}