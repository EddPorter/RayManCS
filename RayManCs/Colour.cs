using System;
using System.Drawing;

namespace RayManCS {

  /// <summary>
  /// Represents a colour.
  /// </summary>
  public sealed class Colour {

    /// <summary>
    /// Creates a new colour.
    /// </summary>
    /// <param name="red">The red component of the colour.</param>
    /// <param name="green">The green component of the colour.</param>
    /// <param name="blue">The blue component of the colour.</param>
    public Colour(float red, float green, float blue) {
      Red = red;
      Green = green;
      Blue = blue;
    }

    /// <summary>
    /// Gets the blue component of the colour.
    /// </summary>
    public float Blue {
      get;
      private set;
    }

    /// <summary>
    /// Gets the green component of the colour.
    /// </summary>
    public float Green {
      get;
      private set;
    }

    /// <summary>
    /// Gets the red component of the colour.
    /// </summary>
    public float Red {
      get;
      private set;
    }

    /// <summary>
    /// Converts to a .NET Color object.
    /// </summary>
    /// <param name="colour">The internal colour object.</param>
    /// <returns>The Colour object converted to a .NET Color object.</returns>
    public static implicit operator Color(Colour colour) {
      if (colour == null) {
        return Color.Empty;
      }
      return colour.ToColor();
    }

    /// <summary>
    /// Converts to a .NET Color object.
    /// </summary>
    /// <returns>This Colour object converted to a .NET Color object.</returns>
    public Color ToColor() {
      return Color.FromArgb((int)(Red * 255), (int)(Green * 255), (int)(Blue * 255));
    }
  }
}