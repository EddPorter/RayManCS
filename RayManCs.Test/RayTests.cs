using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RayManCS.Test {

[TestClass]
public class RayTests {

  [TestMethod]
  public void Ray_Constructor_creates_object() {
    Point start = new Point(0.0f, 0.0f, 0.0f);
    Vector direction = new Vector(1.0f, 1.0f, 1.0f);
    Ray r = new Ray(start, direction);
    Assert.IsNotNull(r);
  }

  [TestMethod]
  [ExpectedException(typeof(ArgumentNullException))]
  public void Ray_Constructor_throws_given_null_direction() {
    Point start = new Point(0.0f, 0.0f, 0.0f);
    Vector direction = null;
    new Ray(start, direction);
  }

  [TestMethod]
  [ExpectedException(typeof(ArgumentNullException))]
  public void Ray_Constructor_throws_given_null_start() {
    Point start = null;
    Vector direction = new Vector(1.0f, 1.0f, 1.0f);
    new Ray(start, direction);
  }

  [TestMethod]
  [ExpectedException(typeof(ArgumentOutOfRangeException))]
  public void Ray_Constructor_throws_given_zero_direction() {
    Point start = new Point(0.0f, 0.0f, 0.0f);
    Vector direction = new Vector(0.0f, 0.0f, 0.0f);
    new Ray(start, direction);
  }
}
}