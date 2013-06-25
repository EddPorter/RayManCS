using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RayManCS.Test {

[TestClass]
public class VectorTests {
  private const float EPSILON = 0.000001f;

  [TestMethod]
  public void Vector_Add_to_point_returns_destination_point() {
    Point p = new Point(1.0f, 1.0f, 1.0f);
    Vector v = new Vector(-1.0f, 1.0f, 0.5f);
    var actual = p + v;
    Assert.AreEqual(0.0f, actual.X, EPSILON);
    Assert.AreEqual(2.0f, actual.Y, EPSILON);
    Assert.AreEqual(1.5f, actual.Z, EPSILON);
  }

  [TestMethod]
  public void Vector_constructor_does_not_throw() {
    Vector v = new Vector(0.0f, 0.0f, 0.0f);
    Assert.IsNotNull(v);
  }

  [TestMethod]
  public void Vector_Cross_Product_is_anti_commutative() {
    Vector v1 = new Vector(1.0f, 0.5f, 2.0f);
    Vector v2 = new Vector(0.0f, 6.0f, -4.5f);
    var actual1 = v1 % v2;
    var actual2 = v2 % v1;
    Assert.AreEqual(actual1.X, -actual2.X, EPSILON);
    Assert.AreEqual(actual1.Y, -actual2.Y, EPSILON);
    Assert.AreEqual(actual1.Z, -actual2.Z, EPSILON);
  }

  [TestMethod]
  public void Vector_Cross_Product_returns_perpendicular_vector() {
    Vector v1 = new Vector(1.0f, 0.0f, 0.0f);
    Vector v2 = new Vector(0.0f, 1.0f, 0.0f);
    var actual = v1 % v2;
    Assert.AreEqual(0.0f, actual.X, EPSILON);
    Assert.AreEqual(0.0f, actual.Y, EPSILON);
    Assert.AreEqual(1.0f, actual.Z, EPSILON);
  }

  [TestMethod]
  public void Vector_Dot_Product_returns_cosine_of_vector_angle_45() {
    Vector v1 = new Vector(0.0f, 1.0f, 0.0f);
    Vector v2 = new Vector(0.0f, 1.0f, 1.0f).Normalise();
    float COS_45 = (float)Math.Cos(Math.PI / 4.0f);
    var actual = v1 * v2;
    Assert.AreEqual(COS_45, actual, EPSILON);
  }

  [TestMethod]
  public void Vector_Dot_Product_returns_cosine_of_vector_angle_90() {
    Vector v1 = new Vector(1.0f, 0.0f, 0.0f);
    Vector v2 = new Vector(0.0f, 1.0f, 0.0f);
    const float COS_90 = 0.0f;
    var actual = v1 * v2;
    Assert.AreEqual(COS_90, actual, EPSILON);
  }

  [TestMethod]
  public void Vector_Norm_returns_correctly_for_pythagorean_quadruple_1() {
    Vector v = new Vector(1.0f, 2.0f, 2.0f);
    float actual = v.Norm();
    Assert.AreEqual(3.0f, actual, EPSILON);
  }

  [TestMethod]
  public void Vector_Norm_returns_correctly_for_pythagorean_quadruple_2() {
    Vector v = new Vector(4.0f, 8.0f, 19.0f);
    float actual = v.Norm();
    Assert.AreEqual(21.0f, actual, EPSILON);
  }

  [TestMethod]
  public void Vector_Norm_returns_correctly_for_pythagorean_quadruple_3() {
    Vector v = new Vector(3.0f, 16.0f, 24.0f);
    float actual = v.Norm();
    Assert.AreEqual(29.0f, actual, EPSILON);
  }

  [TestMethod]
  public void Vector_Norm_returns_correctly_for_pythagorean_quadruple_with_negatives_1() {
    Vector v = new Vector(1.0f, -2.0f, -2.0f);
    float actual = v.Norm();
    Assert.AreEqual(3.0f, actual, EPSILON);
  }

  [TestMethod]
  public void Vector_Norm_returns_correctly_for_pythagorean_quadruple_with_negatives_2() {
    Vector v = new Vector(-4.0f, -8.0f, 19.0f);
    float actual = v.Norm();
    Assert.AreEqual(21.0f, actual, EPSILON);
  }

  [TestMethod]
  public void Vector_Norm_returns_correctly_for_pythagorean_quadruple_with_negatives_3() {
    Vector v = new Vector(-3.0f, 16.0f, -24.0f);
    float actual = v.Norm();
    Assert.AreEqual(29.0f, actual, EPSILON);
  }

  [TestMethod]
  public void Vector_Norm_returns_zero_for_zero_vector() {
    Vector v = new Vector(0.0f, 0.0f, 0.0f);
    float actual = v.Norm();
    Assert.AreEqual(0.0f, actual, EPSILON);
  }

  [TestMethod]
  public void Vector_Normalise_returns_vector_in_same_direction() {
    float x = 5.0f;
    float y = -4.5f;
    float z = 7.2f;
    Vector v = new Vector(x, y, z);
    var normalisedVector = v.Normalise();

    float xRatio = x / normalisedVector.X;
    float yRatio = y / normalisedVector.Y;
    float zRatio = z / normalisedVector.Z;

    Assert.AreEqual(xRatio, yRatio, EPSILON);
    Assert.AreEqual(yRatio, zRatio, EPSILON);
    Assert.AreEqual(zRatio, xRatio, EPSILON);
  }

  [TestMethod]
  public void Vector_Normalise_returns_vector_with_unit_length_1() {
    Vector v = new Vector(-2.0f, 2.0f, 2.0f);
    var normalisedVector = v.Normalise();
    var actualLength = normalisedVector.Norm();

    Assert.AreEqual(1.0f, actualLength, EPSILON);
  }

  [TestMethod]
  public void Vector_Normalise_returns_vector_with_unit_length_2() {
    Vector v = new Vector(0.0f, 4.5f, -6.0f);
    var normalisedVector = v.Normalise();
    var actualLength = normalisedVector.Norm();

    Assert.AreEqual(1.0f, actualLength, EPSILON);
  }

  [TestMethod]
  public void Vector_Normalise_returns_vector_with_unit_length_3() {
    Vector v = new Vector(6.0f, -3.3f, -7.2f);
    var normalisedVector = v.Normalise();
    var actualLength = normalisedVector.Norm();

    Assert.AreEqual(1.0f, actualLength, EPSILON);
  }

  [TestMethod]
  [ExpectedException(typeof(InvalidOperationException))]
  public void Vector_Normalise_returns_zero_vector_given_zero_vector() {
    Vector v = new Vector(0.0f, 0.0f, 0.0f);
    v.Normalise();
  }
}
}