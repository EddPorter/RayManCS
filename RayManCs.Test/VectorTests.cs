using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RayManCS.Test {

  [TestClass]
  public class VectorTests {

    [TestMethod]
    public void Vector_constructor_does_not_throw() {
      Vector v = new Vector(0.0f, 0.0f, 0.0f);
      Assert.IsNotNull(v);
    }

    [TestMethod]
    public void Vector_Norm_returns_correctly_for_pythagorean_quadruple_1() {
      Vector v = new Vector(1.0f, 2.0f, 2.0f);
      float actual = v.Norm();
      Assert.AreEqual(3.0f, actual);
    }

    [TestMethod]
    public void Vector_Norm_returns_correctly_for_pythagorean_quadruple_2() {
      Vector v = new Vector(4.0f, 8.0f, 19.0f);
      float actual = v.Norm();
      Assert.AreEqual(21.0f, actual);
    }

    [TestMethod]
    public void Vector_Norm_returns_correctly_for_pythagorean_quadruple_3() {
      Vector v = new Vector(3.0f, 16.0f, 24.0f);
      float actual = v.Norm();
      Assert.AreEqual(29.0f, actual);
    }

    [TestMethod]
    public void Vector_Norm_returns_correctly_for_pythagorean_quadruple_with_negatives_1() {
      Vector v = new Vector(1.0f, -2.0f, -2.0f);
      float actual = v.Norm();
      Assert.AreEqual(3.0f, actual);
    }

    [TestMethod]
    public void Vector_Norm_returns_correctly_for_pythagorean_quadruple_with_negatives_2() {
      Vector v = new Vector(-4.0f, -8.0f, 19.0f);
      float actual = v.Norm();
      Assert.AreEqual(21.0f, actual);
    }

    [TestMethod]
    public void Vector_Norm_returns_correctly_for_pythagorean_quadruple_with_negatives_3() {
      Vector v = new Vector(-3.0f, 16.0f, -24.0f);
      float actual = v.Norm();
      Assert.AreEqual(29.0f, actual);
    }

    [TestMethod]
    public void Vector_Norm_returns_zero_for_zero_vector() {
      Vector v = new Vector(0.0f, 0.0f, 0.0f);
      float actual = v.Norm();
      Assert.AreEqual(0.0f, actual);
    }
  }
}