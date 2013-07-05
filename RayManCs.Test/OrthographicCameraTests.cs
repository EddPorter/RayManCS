using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RayManCS.Test {

[TestClass]
public class OrthographicCameraTests {
  private const float EPSILON = 0.00001f;

  [TestMethod]
  public void OrthographicCamera_4Arg_Constructor_Creates_New_Object() {
    var position = new Point(150.0f, 200.0f, -100.0f);
    var lookAt = new Point(0.0f, 0.0f, 0.0f);
    var width = 640u;
    var height = 480u;

    var camera = new OrthographicCamera(position, lookAt, width, height);
    Assert.IsNotNull(camera);
  }

  [TestMethod]
  public void OrthographicCamera_5Arg_Constructor_Creates_New_Object() {
    var position = new Point(150.0f, 200.0f, -100.0f);
    var up = new Vector(0.0f, 1.0f, 0.0f);
    var right = new Vector(1.0f, 0.0f, 0.0f);
    var width = 640u;
    var height = 480u;

    var camera = new OrthographicCamera(position, up, right, width, height);
    Assert.IsNotNull(camera);
  }

  [TestMethod]
  public void OrthographicCamera_5Arg_Constructor_With_Non_Normalised_Vectors_Normalises_Vectors() {
    var position = new Point(150.0f, 200.0f, -100.0f);
    var up = new Vector(0.0f, 1.0f, 1.0f);
    var right = new Vector(2.0f, 0.0f, 0.0f);
    var width = 640u;
    var height = 480u;

    var camera = new OrthographicCamera(position, up, right, width, height);
    Assert.AreEqual(0.0f, camera.Up.X, EPSILON);
    Assert.AreEqual(0.707106769f, camera.Up.Y, EPSILON);
    Assert.AreEqual(0.707106769f, camera.Up.Z, EPSILON);
    Assert.AreEqual(1.0f, camera.Right.X, EPSILON);
    Assert.AreEqual(0.0, camera.Right.Y, EPSILON);
    Assert.AreEqual(0.0, camera.Right.Z, EPSILON);
  }

  [TestMethod]
  public void OrthographicCamera_5Arg_Constructor_With_Non_Perpendicular_Vectors_Recalculates_From_Up() {
    var position = new Point(150.0f, 200.0f, -100.0f);
    var up = new Vector(1.0f, 1.0f, 0.0f);
    var right = new Vector(0.0f, -1.0f, 0.0f);
    var width = 640u;
    var height = 480u;

    var camera = new OrthographicCamera(position, up, right, width, height);
    Assert.AreEqual(0.707106769f, camera.Up.X, EPSILON);
    Assert.AreEqual(0.707106769f, camera.Up.Y, EPSILON);
    Assert.AreEqual(0.0f, camera.Up.Z, EPSILON);
    Assert.AreEqual(0.707106769f, camera.Right.X, EPSILON);
    Assert.AreEqual(-0.707106769f, camera.Right.Y, EPSILON);
    Assert.AreEqual(0.0, camera.Right.Z, EPSILON);
  }

  [TestMethod]
  public void OrthographicCamera_GetRay_center_gives_camera_position() {
    var position = new Point(10.0f, 20.0f, -100.0f);
    var up = new Vector(0.0f, 1.0f, 0.0f);
    var right = new Vector(1.0f, 0.0f, 0.0f);
    var width = 10u;
    var height = 10u;
    var camera = new OrthographicCamera(position, up, right, width, height);

    var ray = camera.GetRay(5.0f, 5.0f);

    Assert.AreEqual(position, ray.Start);
    Assert.AreEqual(new Vector(0.0f, 0.0f, 1.0f), ray.Direction);
  }

  [TestMethod]
  [ExpectedException(typeof(ArgumentOutOfRangeException))]
  public void OrthographicCamera_GetRay_throws_given_too_large_x() {
    var position = new Point(10.0f, 20.0f, -100.0f);
    var up = new Vector(0.0f, 1.0f, 0.0f);
    var right = new Vector(1.0f, 0.0f, 0.0f);
    var width = 10u;
    var height = 10u;
    var camera = new OrthographicCamera(position, up, right, width, height);

    camera.GetRay(10.0f, 5.0f);
  }

  [TestMethod]
  [ExpectedException(typeof(ArgumentOutOfRangeException))]
  public void OrthographicCamera_GetRay_throws_given_too_large_y() {
    var position = new Point(10.0f, 20.0f, -100.0f);
    var up = new Vector(0.0f, 1.0f, 0.0f);
    var right = new Vector(1.0f, 0.0f, 0.0f);
    var width = 10u;
    var height = 10u;
    var camera = new OrthographicCamera(position, up, right, width, height);

    camera.GetRay(5.0f, 10.0f);
  }

  [TestMethod]
  public void OrthographicCamera_GetRay_zeros_give_bottom_left_corner() {
    var position = new Point(10.0f, 20.0f, -100.0f);
    var up = new Vector(0.0f, 1.0f, 0.0f);
    var right = new Vector(1.0f, 0.0f, 0.0f);
    var width = 10u;
    var height = 10u;
    var camera = new OrthographicCamera(position, up, right, width, height);

    var ray = camera.GetRay(0.0f, 0.0f);

    Assert.AreEqual(new Point(5.0f, 15.0f, -100.0f), ray.Start);
    Assert.AreEqual(new Vector(0.0f, 0.0f, 1.0f), ray.Direction);
  }
}
}