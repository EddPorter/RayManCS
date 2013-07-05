using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RayManCS.Test {

  [TestClass]
  public class VectorTests {
    private const float EPSILON = 0.000001f;

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Vector_Add_a_null_point_throws() {
      Point p = null;
      Vector v = new Vector(-1.0f, 1.0f, 0.5f);
      var actual = v + p;
    }

    [TestMethod]
    public void Vector_Add_a_point_returns_destination_point() {
      Point p = new Point(1.0f, 1.0f, 1.0f);
      Vector v = new Vector(-1.0f, 1.0f, 0.5f);
      var actual = v + p;
      Assert.AreEqual(0.0f, actual.X, EPSILON);
      Assert.AreEqual(2.0f, actual.Y, EPSILON);
      Assert.AreEqual(1.5f, actual.Z, EPSILON);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Vector_Add_a_point_when_null_throws() {
      Point p = new Point(-1.0f, 1.0f, 0.5f);
      Vector v = null;
      var actual = v + p;
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Vector_Add_to_a_null_point_throws() {
      Point p = null;
      Vector v = new Vector(-1.0f, 1.0f, 0.5f);
      var actual = p + v;
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Vector_Add_to_a_point_when_null_throws() {
      Point p = new Point(-1.0f, 1.0f, 0.5f);
      Vector v = null;
      var actual = p + v;
    }

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
    [ExpectedException(typeof(ArgumentNullException))]
    public void Vector_Dot_Product_throws_given_null_lhs_vector() {
      Vector v1 = null;
      Vector v2 = new Vector(0.0f, 1.0f, 1.0f).Normalise();
      var actual = v1 * v2;
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Vector_Dot_Product_throws_given_null_rhs_vector() {
      Vector v1 = new Vector(0.0f, 1.0f, 1.0f).Normalise();
      Vector v2 = null;
      var actual = v1 * v2;
    }

    [TestMethod]
    public void Vector_EqEq_compares_two_Vectors_successfully() {
      var v1 = new Vector(1.0f, 1.2f, 1.9f);
      var v2 = new Vector(1.0f, 1.2f, 1.9f);
      bool eqeq = v1 == v2;
      Assert.IsTrue(eqeq);
    }

    [TestMethod]
    public void Vector_EqEq_differentiates_two_Vectors_successfully_on_x() {
      var v1 = new Vector(1.0f, 1.2f, 1.9f);
      var v2 = new Vector(-1.0f, 1.2f, 1.9f);
      bool eqeq = v1 == v2;
      Assert.IsFalse(eqeq);
    }

    [TestMethod]
    public void Vector_EqEq_differentiates_two_Vectors_successfully_on_y() {
      var v1 = new Vector(1.0f, 1.2f, 1.9f);
      var v2 = new Vector(1.0f, -1.2f, 1.9f);
      bool eqeq = v1 == v2;
      Assert.IsFalse(eqeq);
    }

    [TestMethod]
    public void Vector_EqEq_differentiates_two_Vectors_successfully_on_z() {
      var v1 = new Vector(1.0f, 1.2f, 1.9f);
      var v2 = new Vector(1.0f, 1.2f, -1.9f);
      bool eqeq = v1 == v2;
      Assert.IsFalse(eqeq);
    }

    [TestMethod]
    public void Vector_EqEq_returns_false_given_null_lhs() {
      Vector v1 = null;
      var v2 = new Vector(1.0f, 1.2f, 1.9f);
      bool eqeq = v1 == v2;
      Assert.IsFalse(eqeq);
    }

    [TestMethod]
    public void Vector_EqEq_returns_false_given_null_rhs() {
      var v1 = new Vector(1.0f, 1.2f, 1.9f);
      Vector v2 = null;
      bool eqeq = v1 == v2;
      Assert.IsFalse(eqeq);
    }

    [TestMethod]
    public void Vector_EqEq_returns_true_given_same_object_twice() {
      var v1 = new Vector(1.0f, 1.2f, 1.9f);
      var v2 = v1;
      bool eqeq = v1 == v2;
      Assert.IsTrue(eqeq);
    }

    [TestMethod]
    public void Vector_EqEq_returns_true_given_two_nulls() {
      Vector v1 = null;
      Vector v2 = null;
      bool eqeq = v1 == v2;
      Assert.IsTrue(eqeq);
    }

    [TestMethod]
    public void Vector_Equals_compares_two_Vectors_successfully() {
      var v1 = new Vector(1.0f, 1.2f, 1.9f);
      var v2 = new Vector(1.0f, 1.2f, 1.9f);
      bool eqeq = v1.Equals(v2);
      Assert.IsTrue(eqeq);
    }

    [TestMethod]
    public void Vector_Equals_differentiates_two_Vectors_successfully_on_x() {
      var v1 = new Vector(1.0f, 1.2f, 1.9f);
      var v2 = new Vector(-1.0f, 1.2f, 1.9f);
      bool eqeq = v1.Equals(v2);
      Assert.IsFalse(eqeq);
    }

    [TestMethod]
    public void Vector_Equals_differentiates_two_Vectors_successfully_on_y() {
      var v1 = new Vector(1.0f, 1.2f, 1.9f);
      var v2 = new Vector(1.0f, -1.2f, 1.9f);
      bool eqeq = v1.Equals(v2);
      Assert.IsFalse(eqeq);
    }

    [TestMethod]
    public void Vector_Equals_differentiates_two_Vectors_successfully_on_z() {
      var v1 = new Vector(1.0f, 1.2f, 1.9f);
      var v2 = new Vector(1.0f, 1.2f, -1.9f);
      bool eqeq = v1.Equals(v2);
      Assert.IsFalse(eqeq);
    }

    [TestMethod]
    public void Vector_Equals_returns_false_given_non_material() {
      var v = new Vector(1.0f, 1.2f, 1.9f);
      var m = new Material() {
        Colour = System.Drawing.Color.Green,
        Reflectance = 0.3f,
        SpecularPower = 50,
        SpecularTerm = 1.2f
      };
      bool eqeq = v.Equals(m);
      Assert.IsFalse(eqeq);
    }

    [TestMethod]
    public void Vector_Equals_returns_false_given_null_rhs() {
      var v1 = new Vector(1.0f, 1.2f, 1.9f);
      Vector v2 = null;
      bool eqeq = v1.Equals(v2);
      Assert.IsFalse(eqeq);
    }

    [TestMethod]
    public void Vector_Equals_returns_true_given_same_object_twice() {
      var v1 = new Vector(1.0f, 1.2f, 1.9f);
      var v2 = v1;
      bool eqeq = v1.Equals(v2);
      Assert.IsTrue(eqeq);
    }

    [TestMethod]
    public void Vector_GetHashCode_returns() {
      var v = new Vector(1.0f, 1.2f, 1.9f);
      v.GetHashCode();
    }

    [TestMethod]
    public void Vector_GetHashCode_returns_different_hashes_for_different_objects() {
      var v1 = new Vector(1.0f, 1.2f, 1.9f);
      var v2 = new Vector(-1.0f, -1.2f, -1.9f);
      var hash1 = v1.GetHashCode();
      var hash2 = v2.GetHashCode();
      Assert.AreNotEqual(hash1, hash2);
    }

    [TestMethod]
    public void Vector_GetHashCode_returns_same_hash_for_equivalent_objects() {
      var v1 = new Vector(1.0f, 1.2f, 1.9f);
      var v2 = new Vector(1.0f, 1.2f, 1.9f);
      var hash1 = v1.GetHashCode();
      var hash2 = v2.GetHashCode();
      Assert.AreEqual(hash1, hash2);
    }

    [TestMethod]
    public void Vector_GetHashCode_returns_same_hash_for_same_object() {
      var v1 = new Vector(1.0f, 1.2f, 1.9f);
      var v2 = v1;
      var hash1 = v1.GetHashCode();
      var hash2 = v2.GetHashCode();
      Assert.AreEqual(hash1, hash2);
    }

    [TestMethod]
    public void Vector_Neq_compares_two_Vectors_successfully() {
      var v1 = new Vector(1.0f, 1.2f, 1.9f);
      var v2 = new Vector(1.0f, 1.2f, 1.9f);
      bool neq = v1 != v2;
      Assert.IsFalse(neq);
    }

    [TestMethod]
    public void Vector_Neq_differentiates_two_Vectors_successfully_on_x() {
      var v1 = new Vector(1.0f, 1.2f, 1.9f);
      var v2 = new Vector(-1.0f, 1.2f, 1.9f);
      bool neq = v1 != v2;
      Assert.IsTrue(neq);
    }

    [TestMethod]
    public void Vector_Neq_differentiates_two_Vectors_successfully_on_y() {
      var v1 = new Vector(1.0f, 1.2f, 1.9f);
      var v2 = new Vector(1.0f, -1.2f, 1.9f);
      bool neq = v1 != v2;
      Assert.IsTrue(neq);
    }

    [TestMethod]
    public void Vector_Neq_differentiates_two_Vectors_successfully_on_z() {
      var v1 = new Vector(1.0f, 1.2f, 1.9f);
      var v2 = new Vector(1.0f, 1.2f, -1.9f);
      bool neq = v1 != v2;
      Assert.IsTrue(neq);
    }

    [TestMethod]
    public void Vector_Neq_returns_false_given_same_object_twice() {
      var v1 = new Vector(1.0f, 1.2f, 1.9f);
      var v2 = v1;
      bool neq = v1 != v2;
      Assert.IsFalse(neq);
    }

    [TestMethod]
    public void Vector_Neq_returns_false_given_two_nulls() {
      Vector v1 = null;
      Vector v2 = null;
      bool neq = v1 != v2;
      Assert.IsFalse(neq);
    }

    [TestMethod]
    public void Vector_Neq_returns_true_given_null_lhs() {
      Vector v1 = null;
      var v2 = new Vector(1.0f, 1.2f, 1.9f);
      bool neq = v1 != v2;
      Assert.IsTrue(neq);
    }

    [TestMethod]
    public void Vector_Neq_returns_true_given_null_rhs() {
      var v1 = new Vector(1.0f, 1.2f, 1.9f);
      Vector v2 = null;
      bool neq = v1 != v2;
      Assert.IsTrue(neq);
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
    public void Vector_Normalise_returns_zero_vector_given_zero_vector() {
      Vector zeroVector = new Vector(0.0f, 0.0f, 0.0f);
      var normalisedVector = zeroVector.Normalise();
      Assert.AreEqual(zeroVector.X, normalisedVector.X);
      Assert.AreEqual(zeroVector.Y, normalisedVector.Y);
      Assert.AreEqual(zeroVector.Z, normalisedVector.Z);
    }

    [TestMethod]
    public void Vector_ScaleOp_scales_vector_on_left_correctly() {
      float factor = 2.0f;
      Vector v = new Vector(1.0f, -1.0f, 1.0f);
      var actual = v * factor;
      Assert.AreEqual(new Vector(2.0f, -2.0f, 2.0f), actual);
    }

    [TestMethod]
    public void Vector_ScaleOp_scales_vector_on_right_correctly() {
      float factor = 2.0f;
      Vector v = new Vector(1.0f, -1.0f, 1.0f);
      var actual = factor * v;
      Assert.AreEqual(new Vector(2.0f, -2.0f, 2.0f), actual);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Vector_ScaleOp_throws_given_null_vector_on_lhs() {
      float factor = 2.0f;
      Vector v = null;
      var actual = v * factor;
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Vector_ScaleOp_throws_given_null_vector_on_rhs() {
      float factor = 2.0f;
      Vector v = null;
      var actual = factor * v;
    }

    [TestMethod]
    public void Vector_Substract_correctly_subtracts_two_vectors() {
      Vector v1 = new Vector(1.0f, 2.0f, 3.0f);
      Vector v2 = new Vector(1.0f, -1.0f, 4.0f);
      var actual = v1 - v2;
      Assert.AreEqual(new Vector(0.0f, 3.0f, -1.0f), actual);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Vector_Substract_throws_given_null_lhs() {
      Vector v1 = null;
      Vector v2 = new Vector(1.0f, 1.0f, 1.0f);
      var actual = v1 - v2;
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Vector_Substract_throws_given_null_rhs() {
      Vector v1 = new Vector(1.0f, 1.0f, 1.0f);
      Vector v2 = null;
      var actual = v1 - v2;
    }
  }
}