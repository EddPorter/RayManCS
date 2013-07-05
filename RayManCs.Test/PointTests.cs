using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RayManCS.Test {

[TestClass]
public class PointTests {

  [TestMethod]
  public void Point_constructor_does_not_throw() {
    Point p = new Point(0.0f, 0.0f, 0.0f);
    Assert.IsNotNull(p);
  }

  [TestMethod]
  public void Point_EqEq_compares_two_Points_successfully() {
    var m1 = new Point(1.0f, 1.2f, 1.9f);
    var m2 = new Point(1.0f, 1.2f, 1.9f);
    bool eqeq = m1 == m2;
    Assert.IsTrue(eqeq);
  }

  [TestMethod]
  public void Point_EqEq_differentiates_two_Points_successfully_on_x() {
    var m1 = new Point(1.0f, 1.2f, 1.9f);
    var m2 = new Point(-1.0f, 1.2f, 1.9f);
    bool eqeq = m1 == m2;
    Assert.IsFalse(eqeq);
  }

  [TestMethod]
  public void Point_EqEq_differentiates_two_Points_successfully_on_y() {
    var m1 = new Point(1.0f, 1.2f, 1.9f);
    var m2 = new Point(1.0f, -1.2f, 1.9f);
    bool eqeq = m1 == m2;
    Assert.IsFalse(eqeq);
  }

  [TestMethod]
  public void Point_EqEq_differentiates_two_Points_successfully_on_z() {
    var m1 = new Point(1.0f, 1.2f, 1.9f);
    var m2 = new Point(1.0f, 1.2f, -1.9f);
    bool eqeq = m1 == m2;
    Assert.IsFalse(eqeq);
  }

  [TestMethod]
  public void Point_EqEq_returns_false_given_null_lhs() {
    Point m1 = null;
    var m2 = new Point(1.0f, 1.2f, 1.9f);
    bool eqeq = m1 == m2;
    Assert.IsFalse(eqeq);
  }

  [TestMethod]
  public void Point_EqEq_returns_false_given_null_rhs() {
    var m1 = new Point(1.0f, 1.2f, 1.9f);
    Point m2 = null;
    bool eqeq = m1 == m2;
    Assert.IsFalse(eqeq);
  }

  [TestMethod]
  public void Point_EqEq_returns_true_given_same_object_twice() {
    var m1 = new Point(1.0f, 1.2f, 1.9f);
    var m2 = m1;
    bool eqeq = m1 == m2;
    Assert.IsTrue(eqeq);
  }

  [TestMethod]
  public void Point_EqEq_returns_true_given_two_nulls() {
    Point m1 = null;
    Point m2 = null;
    bool eqeq = m1 == m2;
    Assert.IsTrue(eqeq);
  }

  [TestMethod]
  public void Point_Equals_compares_two_Points_successfully() {
    var m1 = new Point(1.0f, 1.2f, 1.9f);
    var m2 = new Point(1.0f, 1.2f, 1.9f);
    bool eqeq = m1.Equals(m2);
    Assert.IsTrue(eqeq);
  }

  [TestMethod]
  public void Point_Equals_differentiates_two_Points_successfully_on_x() {
    var m1 = new Point(1.0f, 1.2f, 1.9f);
    var m2 = new Point(-1.0f, 1.2f, 1.9f);
    bool eqeq = m1.Equals(m2);
    Assert.IsFalse(eqeq);
  }

  [TestMethod]
  public void Point_Equals_differentiates_two_Points_successfully_on_y() {
    var m1 = new Point(1.0f, 1.2f, 1.9f);
    var m2 = new Point(1.0f, -1.2f, 1.9f);
    bool eqeq = m1.Equals(m2);
    Assert.IsFalse(eqeq);
  }

  [TestMethod]
  public void Point_Equals_differentiates_two_Points_successfully_on_z() {
    var m1 = new Point(1.0f, 1.2f, 1.9f);
    var m2 = new Point(1.0f, 1.2f, -1.9f);
    bool eqeq = m1.Equals(m2);
    Assert.IsFalse(eqeq);
  }

  [TestMethod]
  public void Point_Equals_returns_false_given_non_material() {
    var p = new Point(1.0f, 1.2f, 1.9f);
    var m = new Material() {
      Colour = System.Drawing.Color.Green,
      Reflectance = 0.3f,
      SpecularPower = 50,
      SpecularTerm = 1.2f
    };
    bool eqeq = p.Equals(m);
    Assert.IsFalse(eqeq);
  }

  [TestMethod]
  public void Point_Equals_returns_false_given_null_rhs() {
    var m1 = new Point(1.0f, 1.2f, 1.9f);
    Point m2 = null;
    bool eqeq = m1.Equals(m2);
    Assert.IsFalse(eqeq);
  }

  [TestMethod]
  public void Point_Equals_returns_true_given_same_object_twice() {
    var m1 = new Point(1.0f, 1.2f, 1.9f);
    var m2 = m1;
    bool eqeq = m1.Equals(m2);
    Assert.IsTrue(eqeq);
  }

  [TestMethod]
  public void Point_GetHashCode_returns() {
    var p = new Point(1.0f, 1.2f, 1.9f);
    p.GetHashCode();
  }

  [TestMethod]
  public void Point_GetHashCode_returns_different_hashes_for_different_objects() {
    var p1 = new Point(1.0f, 1.2f, 1.9f);
    var p2 = new Point(-1.0f, -1.2f, -1.9f);
    var hash1 = p1.GetHashCode();
    var hash2 = p2.GetHashCode();
    Assert.AreNotEqual(hash1, hash2);
  }

  [TestMethod]
  public void Point_GetHashCode_returns_same_hash_for_equivalent_objects() {
    var p1 = new Point(1.0f, 1.2f, 1.9f);
    var p2 = new Point(1.0f, 1.2f, 1.9f);
    var hash1 = p1.GetHashCode();
    var hash2 = p2.GetHashCode();
    Assert.AreEqual(hash1, hash2);
  }

  [TestMethod]
  public void Point_GetHashCode_returns_same_hash_for_same_object() {
    var p1 = new Point(1.0f, 1.2f, 1.9f);
    var p2 = p1;
    var hash1 = p1.GetHashCode();
    var hash2 = p2.GetHashCode();
    Assert.AreEqual(hash1, hash2);
  }

  [TestMethod]
  public void Point_Neq_compares_two_Points_successfully() {
    var m1 = new Point(1.0f, 1.2f, 1.9f);
    var m2 = new Point(1.0f, 1.2f, 1.9f);
    bool neq = m1 != m2;
    Assert.IsFalse(neq);
  }

  [TestMethod]
  public void Point_Neq_differentiates_two_Points_successfully_on_x() {
    var m1 = new Point(1.0f, 1.2f, 1.9f);
    var m2 = new Point(-1.0f, 1.2f, 1.9f);
    bool neq = m1 != m2;
    Assert.IsTrue(neq);
  }

  [TestMethod]
  public void Point_Neq_differentiates_two_Points_successfully_on_y() {
    var m1 = new Point(1.0f, 1.2f, 1.9f);
    var m2 = new Point(1.0f, -1.2f, 1.9f);
    bool neq = m1 != m2;
    Assert.IsTrue(neq);
  }

  [TestMethod]
  public void Point_Neq_differentiates_two_Points_successfully_on_z() {
    var m1 = new Point(1.0f, 1.2f, 1.9f);
    var m2 = new Point(1.0f, 1.2f, -1.9f);
    bool neq = m1 != m2;
    Assert.IsTrue(neq);
  }

  [TestMethod]
  public void Point_Neq_returns_false_given_same_object_twice() {
    var m1 = new Point(1.0f, 1.2f, 1.9f);
    var m2 = m1;
    bool neq = m1 != m2;
    Assert.IsFalse(neq);
  }

  [TestMethod]
  public void Point_Neq_returns_false_given_two_nulls() {
    Point m1 = null;
    Point m2 = null;
    bool neq = m1 != m2;
    Assert.IsFalse(neq);
  }

  [TestMethod]
  public void Point_Neq_returns_true_given_null_lhs() {
    Point m1 = null;
    var m2 = new Point(1.0f, 1.2f, 1.9f);
    bool neq = m1 != m2;
    Assert.IsTrue(neq);
  }

  [TestMethod]
  public void Point_Neq_returns_true_given_null_rhs() {
    var m1 = new Point(1.0f, 1.2f, 1.9f);
    Point m2 = null;
    bool neq = m1 != m2;
    Assert.IsTrue(neq);
  }
}
}