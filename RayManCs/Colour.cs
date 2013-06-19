using System;

namespace RayManCS {

  /// <summary>
  /// Represents a colour.
  /// </summary>
  public sealed class Colour {

    /// <summary>
    /// Constructs a new colour object.
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
    /// Converts a .NET Color object to a new Colour object.
    /// </summary>
    /// <param name="colour">The Color to convert.</param>
    /// <returns>The new Colour object.</returns>
    public static implicit operator Colour(System.Drawing.Color colour) {
      return new Colour(colour.R / 255.0f, colour.G / 255.0f, colour.B / 255.0f);
    }

    /// <summary>
    /// Converts the Colour object to a .NET Color object.
    /// </summary>
    /// <param name="colour">The Colour to convert.</param>
    /// <returns>The converted Colour object.</returns>
    public static implicit operator System.Drawing.Color(Colour colour) {
      return System.Drawing.Color.FromArgb(Math.Min((int)(colour.Red * 255), 255), Math.Min((int)(colour.Green * 255), 255), Math.Min((int)(colour.Blue * 255), 255));
    }

    /// <summary>
    /// Scales a colour by a given factor.
    /// </summary>
    /// <param name="colour">The colour to scale.</param>
    /// <param name="factor">The scaling factor.</param>
    /// <returns>The scaled colour.</returns>
    public static Colour operator *(Colour colour, float factor) {
      return new Colour(colour.Red * factor, colour.Green * factor, colour.Blue * factor);
    }

    /// <summary>
    /// Multiplies two colours together, componentwise.
    /// </summary>
    /// <param name="lhs">The first colour to multiply.</param>
    /// <param name="rhs">The second colour to multiply.</param>
    /// <returns>The new colour.</returns>
    public static Colour operator *(Colour lhs, Colour rhs) {
      return new Colour(lhs.Red * rhs.Red, lhs.Green * rhs.Green, lhs.Blue * rhs.Blue);
    }

    /// <summary>
    /// Adds two colours together.
    /// </summary>
    /// <param name="lhs">The first colour to add.</param>
    /// <param name="rhs">The second colour to add.</param>
    /// <returns>The combined colour.</returns>
    public static Colour operator +(Colour lhs, Colour rhs) {
      return new Colour(lhs.Red + rhs.Red, lhs.Green + rhs.Green, lhs.Blue + rhs.Blue);
    }
  }
}