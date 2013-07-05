using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RayManCS.Test {

  [TestClass]
  public class CameraTests {

    [TestMethod]
    public void Camera_Constructor_returns_object_given_valid_parameters() {
      Point position = new Point(0.0f, 0.0f, 0.0f);
      float width = 10.0f;
      float height = 10.0f;

      var camera = new TestCamera(position, width, height);

      Assert.IsNotNull(camera);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Camera_Constructor_throws_given_nonpositive_height() {
      Point position = new Point(0.0f, 0.0f, 0.0f);
      float width = 10.0f;
      float height = -10.0f;

      new TestCamera(position, width, height);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Camera_Constructor_throws_given_nonpositive_width() {
      Point position = new Point(0.0f, 0.0f, 0.0f);
      float width = -10.0f;
      float height = 10.0f;

      new TestCamera(position, width, height);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Camera_Constructor_throws_given_null_position() {
      Point position = null;
      float width = 10.0f;
      float height = 10.0f;

      new TestCamera(position, width, height);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Camera_Constructor_throws_given_zero_height() {
      Point position = new Point(0.0f, 0.0f, 0.0f);
      float width = 10.0f;
      float height = 0.0f;

      new TestCamera(position, width, height);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Camera_Constructor_throws_given_zero_width() {
      Point position = new Point(0.0f, 0.0f, 0.0f);
      float width = 0.0f;
      float height = 10.0f;

      new TestCamera(position, width, height);
    }

    private class TestCamera : Camera {

      public TestCamera(Point position, float width, float height)
        : base(position, width, height) {
      }

      internal override Ray GetRay(float x, float y) {
        throw new NotImplementedException();
      }
    }
  }
}