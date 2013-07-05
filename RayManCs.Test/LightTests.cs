using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RayManCS.Test {

[TestClass]
public class LightTests {

  [TestMethod]
  public void Light_Constructor_Creates_New_Object() {
    var location = new Point(150.0f, 200.0f, -100.0f);
    var light = new TestLight(location);
    Assert.IsNotNull(light);
  }

  [TestMethod]
  public void Light_Constructor_Creates_White_Light() {
    var location = new Point(150.0f, 200.0f, -100.0f);
    var light = new TestLight(location);
    Assert.AreEqual(System.Drawing.Color.White, light.Colour);
  }

  [TestMethod]
  public void Light_Constructor_Stores_Location() {
    var location = new Point(150.0f, 200.0f, -100.0f);
    var light = new TestLight(location);
    Assert.AreEqual(location, light.Location);
  }

  [TestMethod]
  [ExpectedException(typeof(ArgumentNullException))]
  public void Light_Constructor_throws_given_null_location() {
    Point location = null;
    new TestLight(location);
  }

  private class TestLight : Light {

    public TestLight(Point location)
    : base(location) {
    }
  }
}
}