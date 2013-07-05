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
    Reflectance = 0.0f;
  }

  /// <summary>
  /// Gets and sets the material's main colour.
  /// </summary>
  public Color Colour {
    get;
    set;
  }

  /// <summary>
  /// Gets and sets the material's reflectance. Valid range is 0.0-1.0.
  /// </summary>
  public float Reflectance {
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

  /// <summary>
  /// Determines if two materials are different.
  /// </summary>
  /// <param name="lhs">The first material.</param>
  /// <param name="rhs">The second material.</param>
  /// <returns>If the two materials are different.</returns>
  public static bool operator !=(Material lhs, Material rhs) {
    return !(lhs == rhs);
  }

  /// <summary>
  /// Determines if two materials are equivalent.
  /// </summary>
  /// <param name="lhs">The first material.</param>
  /// <param name="rhs">The second material.</param>
  /// <returns>If the two materials are equivalent.</returns>
  public static bool operator ==(Material lhs, Material rhs) {
    if (object.ReferenceEquals(lhs, rhs)) {
      return true;
    }
    if (object.ReferenceEquals(lhs, null) || object.ReferenceEquals(rhs, null)) {
      return false;
    }
    return lhs.Colour == rhs.Colour &&
           lhs.Reflectance == rhs.Reflectance &&
           lhs.SpecularPower == rhs.SpecularPower &&
           lhs.SpecularTerm == rhs.SpecularTerm;
  }

  /// <summary>
  /// Determines whether the specified System.Object is equal to the current System.Object.
  /// </summary>
  /// <param name="obj">The object to compare with the current object.</param>
  /// <returns>true if the specified object is equal to the current Material; otherwise, false.</returns>
  public override bool Equals(object obj) {
    return this == (obj as Material);
  }

  /// <summary>
  /// Serves as a hash function for a material.
  /// </summary>
  /// <returns>A hash code for the current Material.</returns>
  public override int GetHashCode() {
    return new {
      Colour,
      Reflectance,
      SpecularPower,
      SpecularTerm
    } .GetHashCode();
  }
}
}