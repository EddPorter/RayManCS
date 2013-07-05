using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RayManCS.Test {

[TestClass]
public class TriangleTests {
  public const float EPSILON = 0.00001f;

  [TestMethod]
  public void Triangle_Constructor_creates_new_object() {
    var p1 = new Point(0.0f, 0.0f, 0.0f);
    var p2 = new Point(1.0f, 0.0f, 0.0f);
    var p3 = new Point(1.0f, 1.0f, 0.0f);
    new Triangle(p1, p2, p3);
  }

  [TestMethod]
  public void Triangle_Constructor_saves_p1() {
    var p1 = new Point(0.0f, 0.0f, 0.0f);
    var p2 = new Point(1.0f, 0.0f, 0.0f);
    var p3 = new Point(1.0f, 1.0f, 0.0f);
    var t = new Triangle(p1, p2, p3);
    Assert.AreEqual(p1, t.P1);
  }

  [TestMethod]
  public void Triangle_Constructor_saves_p2() {
    var p1 = new Point(0.0f, 0.0f, 0.0f);
    var p2 = new Point(1.0f, 0.0f, 0.0f);
    var p3 = new Point(1.0f, 1.0f, 0.0f);
    var t = new Triangle(p1, p2, p3);
    Assert.AreEqual(p2, t.P2);
  }

  [TestMethod]
  public void Triangle_Constructor_saves_p3() {
    var p1 = new Point(0.0f, 0.0f, 0.0f);
    var p2 = new Point(1.0f, 0.0f, 0.0f);
    var p3 = new Point(1.0f, 1.0f, 0.0f);
    var t = new Triangle(p1, p2, p3);
    Assert.AreEqual(p3, t.P3);
  }

  [TestMethod]
  [ExpectedException(typeof(ArgumentNullException))]
  public void Triangle_Constructor_throws_given_null_p1() {
    Point p1 = null;
    Point p2 = new Point(1.0f, 0.0f, 0.0f);
    Point p3 = new Point(1.0f, 1.0f, 0.0f);
    new Triangle(p1, p2, p3);
  }

  [TestMethod]
  [ExpectedException(typeof(ArgumentNullException))]
  public void Triangle_Constructor_throws_given_null_p2() {
    Point p1 = new Point(1.0f, 0.0f, 0.0f);
    Point p2 = null;
    Point p3 = new Point(1.0f, 1.0f, 0.0f);
    new Triangle(p1, p2, p3);
  }

  [TestMethod]
  [ExpectedException(typeof(ArgumentNullException))]
  public void Triangle_Constructor_throws_given_null_p3() {
    Point p1 = new Point(1.0f, 0.0f, 0.0f);
    Point p2 = new Point(1.0f, 0.0f, 0.0f);
    Point p3 = null;
    new Triangle(p1, p2, p3);
  }

  [TestMethod]
  public void Triangle_GetNormalAtPoint_returns_normalised_vector() {
    var p1 = new Point(0.0f, 0.0f, 0.0f);
    var p2 = new Point(1.0f, 0.0f, 0.0f);
    var p3 = new Point(1.0f, 1.0f, 0.0f);
    var t = new Triangle(p1, p2, p3);

    var actual = t.GetNormalAtPoint(new Point(0.5f, 0.5f, 0.0f));

    Assert.AreEqual(1.0f, actual.Norm(), EPSILON);
  }

  //[TestMethod]
  //public void Triangle_GetNormalAtPoint_returns_vector_in_correct_direction() {
  //  var centre = new Point(50.0f, -12.0f, 4.2f);
  //  var radius = 10.0f;
  //  var s = new Triangle(centre, radius);

  //  var actual = s.GetNormalAtPoint(new Point(60.0f, -12.0f, 4.2f));

  //  Assert.AreEqual(new Vector(1.0f, 0.0f, 0.0f), actual);
  //}

  [TestMethod]
  public void Triangle_IntersectDistance_gives_correct_distance() {
    Ray ray = new Ray(new Point(0.1f, 0.1f, -10.0f), new Vector(0.0f, 0.0f, 1.0f));
    var p1 = new Point(0.0f, 0.0f, 0.0f);
    var p2 = new Point(1.0f, 0.0f, 0.0f);
    var p3 = new Point(1.0f, 1.0f, 0.0f);
    var t = new Triangle(p1, p2, p3);

    var distance = t.IntersectDistance(ray);

    Assert.AreEqual(10.0f, distance, EPSILON);
  }

  [TestMethod]
  public void Triangle_IntersectDistance_ray_intersecting_p1_gives_correct_distance() {
    Ray ray = new Ray(new Point(0.0f, 0.0f, -10.0f), new Vector(0.0f, 0.0f, 1.0f));
    var p1 = new Point(0.0f, 0.0f, 0.0f);
    var p2 = new Point(1.0f, 0.0f, 0.0f);
    var p3 = new Point(1.0f, 1.0f, 0.0f);
    var t = new Triangle(p1, p2, p3);

    var distance = t.IntersectDistance(ray);

    Assert.AreEqual(10.0f, distance, EPSILON);
  }

  [TestMethod]
  public void Triangle_IntersectDistance_ray_intersecting_p2_gives_correct_distance() {
    Ray ray = new Ray(new Point(1.0f, 0.0f, -10.0f), new Vector(0.0f, 0.0f, 1.0f));
    var p1 = new Point(0.0f, 0.0f, 0.0f);
    var p2 = new Point(1.0f, 0.0f, 0.0f);
    var p3 = new Point(1.0f, 1.0f, 0.0f);
    var t = new Triangle(p1, p2, p3);

    var distance = t.IntersectDistance(ray);

    Assert.AreEqual(10.0f, distance, EPSILON);
  }

  [TestMethod]
  public void Triangle_IntersectDistance_ray_intersecting_p3_gives_correct_distance() {
    Ray ray = new Ray(new Point(1.0f, 1.0f, -10.0f), new Vector(0.0f, 0.0f, 1.0f));
    var p1 = new Point(0.0f, 0.0f, 0.0f);
    var p2 = new Point(1.0f, 0.0f, 0.0f);
    var p3 = new Point(1.0f, 1.0f, 0.0f);
    var t = new Triangle(p1, p2, p3);

    var distance = t.IntersectDistance(ray);

    Assert.AreEqual(10.0f, distance, EPSILON);
  }

  [TestMethod]
  [ExpectedException(typeof(ArgumentNullException))]
  public void Triangle_IntersectDistance_throws_given_null_ray() {
    Ray ray = null;
    var p1 = new Point(0.0f, 0.0f, 0.0f);
    var p2 = new Point(1.0f, 0.0f, 0.0f);
    var p3 = new Point(1.0f, 1.0f, 0.0f);
    var t = new Triangle(p1, p2, p3);

    t.IntersectDistance(ray);
  }

  [TestMethod]
  public void Triangle_IntersectDistance_negative_value_given_nonintersecting_ray_1() {
    Ray ray = new Ray(new Point(-10.0f, -10.0f, -10.0f), new Vector(0.0f, 0.0f, 1.0f));
    var p1 = new Point(0.0f, 0.0f, 0.0f);
    var p2 = new Point(1.0f, 0.0f, 0.0f);
    var p3 = new Point(1.0f, 1.0f, 0.0f);
    var t = new Triangle(p1, p2, p3);

    var distance = t.IntersectDistance(ray);

    Assert.IsTrue(distance < 0.0f);
  }

  [TestMethod]
  public void Triangle_IntersectDistance_negative_value_given_nonintersecting_ray_2() {
    Ray ray = new Ray(new Point(10.0f, 10.0f, -10.0f), new Vector(0.0f, 0.0f, 1.0f));
    var p1 = new Point(0.0f, 0.0f, 0.0f);
    var p2 = new Point(1.0f, 0.0f, 0.0f);
    var p3 = new Point(1.0f, 1.0f, 0.0f);
    var t = new Triangle(p1, p2, p3);

    var distance = t.IntersectDistance(ray);

    Assert.IsTrue(distance < 0.0f);
  }
  [TestMethod]
  public void Triangle_IntersectDistance_negative_value_given_nonintersecting_ray_3() {
    Ray ray = new Ray(new Point(0.0f, 10.0f, -10.0f), new Vector(0.0f, 0.0f, 1.0f));
    var p1 = new Point(0.0f, 0.0f, 0.0f);
    var p2 = new Point(1.0f, 0.0f, 0.0f);
    var p3 = new Point(1.0f, 1.0f, 0.0f);
    var t = new Triangle(p1, p2, p3);

    var distance = t.IntersectDistance(ray);

    Assert.IsTrue(distance < 0.0f);
  }
  [TestMethod]
  public void Triangle_IntersectDistance_negative_value_given_orthogonal_ray() {
    Ray ray = new Ray(new Point(0.0f, 0.0f, -10.0f), new Vector(1.0f, 0.0f, 0.0f));
    var p1 = new Point(0.0f, 0.0f, 0.0f);
    var p2 = new Point(1.0f, 0.0f, 0.0f);
    var p3 = new Point(1.0f, 1.0f, 0.0f);
    var t = new Triangle(p1, p2, p3);

    var distance = t.IntersectDistance(ray);

    Assert.IsTrue(distance < 0.0f);
  }

  [TestMethod]
  [ExpectedException(typeof(ArgumentOutOfRangeException))]
  public void Triangle_Constructor_throws_if_p3_forms_a_line() {
    Point p1 = new Point(0.0f, 0.0f, 0.0f);
    Point p2 = new Point(1.0f, 0.0f, 0.0f);
    Point p3 = new Point(2.0f, 0.0f, 0.0f);
    new Triangle(p1, p2, p3);
  }
}
}