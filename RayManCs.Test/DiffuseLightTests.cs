using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RayManCS.Test {

  [TestClass]
  public class DiffuseLightTests {

    [TestMethod]
    public void DiffuseLight_Constructor_Creates_New_Object() {
      var location = new Point(150.0f, 200.0f, -100.0f);
      var dl = new DiffuseLight(location);
      Assert.IsNotNull(dl);
    }

    [TestMethod]
    public void DiffuseLight_Constructor_Creates_White_Light() {
      var location = new Point(150.0f, 200.0f, -100.0f);
      var dl = new DiffuseLight(location);
      Assert.AreEqual(System.Drawing.Color.White, dl.Colour);
    }

    [TestMethod]
    public void DiffuseLight_Constructor_Stores_Location() {
      var location = new Point(150.0f, 200.0f, -100.0f);
      var dl = new DiffuseLight(location);
      Assert.AreEqual(location, dl.Location);
    }
  }
}