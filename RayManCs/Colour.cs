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
  /// Converts the Colour object to a .NET Color object.
  /// </summary>
  /// <param name="colour">The Colour to convert.</param>
  /// <returns>The converted Colour object.</returns>
  public static implicit operator System.Drawing.Color(Colour colour) {
    return System.Drawing.Color.FromArgb((int)(colour.Red * 255), (int)(colour.Green * 255), (int)(colour.Blue * 255));
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