using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RayManCS.Test {

  [TestClass]
  public class PointTests {

    [TestMethod]
    public void Point_constructor_does_not_throw() {
      Point p = new Point(0.0f, 0.0f, 0.0f);
      Assert.IsNotNull(p);
    }
  }
}