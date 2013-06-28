using System.Drawing;

namespace RayManCS {

/// <summary>
/// The material of an object.
/// </summary>
public sealed class Material {

  /// <summary>
  /// Constructs a new material with default property values.
  /// </summary>
  public Material() {
    Colour = Color.White;
    SpecularTerm = 0.0f;
    SpecularPower = 1.0f;
  }

  /// <summary>
  /// Gets and sets the material's main colour.
  /// </summary>
  public Color Colour {
    get;
    set;
  }

  /// <summary>
  /// Gets and sets the material's specular power.
  /// </summary>
  public float SpecularPower {
    get;
    set;
  }

  /// <summary>
  /// Gets and sets the material's specular term.
  /// </summary>
  public float SpecularTerm {
    get;
    set;
  }
}
}