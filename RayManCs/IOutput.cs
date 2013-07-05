using System.Drawing;

namespace RayManCS {

/// <summary>
/// An interface to consume the generated output from the ray tracer.
/// </summary>
public interface IOutput {

  /// <summary>
  /// Gets the height of the final image.
  /// </summary>
  uint Height {
    get;
  }

  /// <summary>
  /// Gets the width of the final image.
  /// </summary>
  uint Width {
    get;
  }

  /// <summary>
  /// Called when a new pixel colour is generated at position (x,y) in the image.
  /// </summary>
  /// <param name="x">The x co-ordinate of the pixel being reported.</param>
  /// <param name="y">The y co-ordinate of the pixel being reported.</param>
  /// <param name="colour">The colour of the pixel being reported.</param>
  void Write(uint x, uint y, Color colour);
}
}