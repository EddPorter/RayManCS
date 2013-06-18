﻿using System.Drawing;

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
  }

  /// <summary>
  /// Gets and sets the material's main colour.
  /// </summary>
  public Color Colour {
    get;
    set;
  }
}
}