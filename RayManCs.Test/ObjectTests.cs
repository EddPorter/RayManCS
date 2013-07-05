using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RayManCS.Test {

  [TestClass]
  public class ObjectTests {
    private class TestObject : Object {
      public override Vector GetNormalAtPoint(Point point) {
        throw new NotImplementedException();
      }

      public override float IntersectDistance(Ray ray) {
        throw new NotImplementedException();
      }
    }

    [TestMethod]
    public void Object_Constructor_Creates_new_object() {
      var o = new TestObject();
      Assert.IsNotNull(o);
    }
    [TestMethod]
    public void Object_Constructor_Creates_material() {
      var o = new TestObject();
      Assert.IsNotNull(o.Material);
    }
    [TestMethod]
    public void Object_Constructor_Creates_default_material() {
      var o = new TestObject();
      Assert.AreEqual(new Material(), o.Material);
    }

    [TestMethod]
    public void Object_SolveQuadraticMinimumNonNegative_given_x2_1_returns_null() {
      float a = 1.0f;
      float b = 0.0f;
      float c = 1.0f;

      float? actual = Object.SolveQuadraticMinimumNonnegative(a, b, c);

      Assert.IsFalse(actual.HasValue);
    }

    [TestMethod]
    public void Object_SolveQuadraticMinimumNonNegative_given_x2_4x_4_returns_null() {
      float a = 1.0f;
      float b = 4.0f;
      float c = 4.0f;

      float? actual = Object.SolveQuadraticMinimumNonnegative(a, b, c);

      Assert.IsFalse(actual.HasValue);
    }

    [TestMethod]
    public void Object_SolveQuadraticMinimumNonNegative_given_x2_minus_1_returns_1() {
      float a = 1.0f;
      float b = 0.0f;
      float c = -1.0f;

      float? actual = Object.SolveQuadraticMinimumNonnegative(a, b, c);

      Assert.AreEqual(1.0f, actual.Value);
    }

    [TestMethod]
    public void Object_SolveQuadraticMinimumNonNegative_given_x2_minus_2x_1_returns_1() {
      float a = 1.0f;
      float b = -2.0f;
      float c = 1.0f;

      float? actual = Object.SolveQuadraticMinimumNonnegative(a, b, c);

      Assert.AreEqual(1.0f, actual.Value);
    }

    [TestMethod]
    public void Object_SolveQuadraticMinimumNonNegative_given_x2_returns_0() {
      float a = 1.0f;
      float b = 0.0f;
      float c = 0.0f;

      float? actual = Object.SolveQuadraticMinimumNonnegative(a, b, c);

      Assert.AreEqual(0.0f, actual.Value);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Object_SolveQuadraticMinimumNonNegative_given_zero_throws_exception() {
      float a = 0.0f;
      float b = 0.0f;
      float c = 0.0f;

      Object.SolveQuadraticMinimumNonnegative(a, b, c);
    }
  }
}