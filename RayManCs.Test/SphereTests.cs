using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RayManCS.Test {

[TestClass]
public class SphereTests {
  private const float EPSILON = 0.00001f;

  [TestMethod]
  public void Sphere_Constructor_creates_new_object() {
    var centre = new Point(0.0f, 0.0f, 0.0f);
    var radius = 10.0f;
    new Sphere(centre, radius);
  }

  [TestMethod]
  public void Sphere_Constructor_saves_centre() {
    var centre = new Point(50.0f, -12.0f, 4.2f);
    var radius = 10.0f;
    var s = new Sphere(centre, radius);
    Assert.AreEqual(centre, s.Centre);
  }

  [TestMethod]
  public void Sphere_Constructor_saves_radius() {
    var centre = new Point(50.0f, -12.0f, 4.2f);
    var radius = 12.2f;
    var s = new Sphere(centre, radius);
    Assert.AreEqual(radius, s.Radius);
  }

  [TestMethod]
  [ExpectedException(typeof(ArgumentNullException))]
  public void Sphere_Constructor_throws_given_null_centre() {
    Point centre = null;
    var radius = 10.0f;
    new Sphere(centre, radius);
  }

  [TestMethod]
  [ExpectedException(typeof(ArgumentOutOfRangeException))]
  public void Sphere_Constructor_throws_given_zero_radius() {
    var centre = new Point(50.0f, -12.0f, 4.2f);
    var radius = 0.0f;
    new Sphere(centre, radius);
  }

  [TestMethod]
  public void Sphere_GetNormalAtPoint_returns_normalised_vector() {
    var centre = new Point(50.0f, -12.0f, 4.2f);
    var radius = 10.0f;
    var s = new Sphere(centre, radius);

    var actual = s.GetNormalAtPoint(new Point(60.0f, -12.0f, 4.2f));

    Assert.AreEqual(1.0f, actual.Norm(), EPSILON);
  }

  [TestMethod]
  public void Sphere_GetNormalAtPoint_returns_vector_in_correct_direction() {
    var centre = new Point(50.0f, -12.0f, 4.2f);
    var radius = 10.0f;
    var s = new Sphere(centre, radius);

    var actual = s.GetNormalAtPoint(new Point(60.0f, -12.0f, 4.2f));

    Assert.AreEqual(new Vector(1.0f, 0.0f, 0.0f), actual);
  }

  [TestMethod]
  public void Sphere_IntersectDistance_gives_correct_distance() {
    Ray ray = new Ray(new Point(0.0f, -12.0f, 4.2f), new Vector(1.0f, 0.0f, 0.0f));
    var centre = new Point(50.0f, -12.0f, 4.2f);
    var radius = 10.0f;
    var s = new Sphere(centre, radius);

    var distance = s.IntersectDistance(ray);

    Assert.AreEqual(40.0f, distance, EPSILON);
  }

  [TestMethod]
  public void Sphere_IntersectDistance_negative_value_given_nonintersecting_ray() {
    Ray ray = new Ray(new Point(0.0f, 0.0f, 0.0f), new Vector(1.0f, 0.0f, 0.0f));
    var centre = new Point(50.0f, -12.0f, 4.2f);
    var radius = 10.0f;
    var s = new Sphere(centre, radius);

    var distance = s.IntersectDistance(ray);

    Assert.IsTrue(distance < 0.0f);
  }

  [TestMethod]
  [ExpectedException(typeof(ArgumentNullException))]
  public void Sphere_IntersectDistance_throws_given_null_ray() {
    Ray ray = null;
    var centre = new Point(50.0f, -12.0f, 4.2f);
    var radius = 10.0f;
    var s = new Sphere(centre, radius);

    s.IntersectDistance(ray);
  }
}
}