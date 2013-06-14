using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Drawing;

namespace RayManCS.Test {

  [TestClass]
  public class ColourTests {

    [TestMethod]
    public void Colour_implicit_cast_to_color_with_null_object_returns_the_empty_color() {
      Colour colour = null;
      Color color = (Color)colour;
      Assert.AreEqual(Color.Empty, color);
    }
  }
}