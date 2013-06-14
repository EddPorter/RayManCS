using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RayManCS.Test {

  [TestClass]
  public class RayTests {

    [TestMethod]
    public void Ray_constructor_does_not_throw() {
      Point start = new Point(0.0f, 0.0f, 0.0f);
      Vector direction = new Vector(1.0f, 1.0f, 1.0f);
      Ray r = new Ray(start, direction);
      Assert.IsNotNull(r);
    }
  }
}