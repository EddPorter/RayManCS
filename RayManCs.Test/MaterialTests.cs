using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace RayManCS.Test {

  [TestClass]
  public class MaterialTests {
    private const float EPSILON = 0.00001f;

    [TestMethod]
    public void Material_Constructor_Creates_New_Object() {
      var material = new Material();
      Assert.IsNotNull(material);
    }

    [TestMethod]
    public void Material_Constructor_Creates_One_Specular_Power() {
      var material = new Material();
      Assert.AreEqual(1.0f, material.SpecularPower, EPSILON);
    }

    [TestMethod]
    public void Material_Constructor_Creates_White_Material() {
      var material = new Material();
      Assert.AreEqual(System.Drawing.Color.White, material.Colour);
    }

    [TestMethod]
    public void Material_Constructor_Creates_Zero_Reflectance() {
      var material = new Material();
      Assert.AreEqual(0.0f, material.Reflectance, EPSILON);
    }

    [TestMethod]
    public void Material_Constructor_Creates_Zero_Specular_Term() {
      var material = new Material();
      Assert.AreEqual(0.0f, material.SpecularTerm, EPSILON);
    }

    [TestMethod]
    public void Material_EqEq_compares_two_materials_successfully() {
      var m1 = new Material() {
        Colour = System.Drawing.Color.Green,
        Reflectance = 0.3f,
        SpecularPower = 50,
        SpecularTerm = 1.2f
      };
      var m2 = new Material() {
        Colour = System.Drawing.Color.Green,
        Reflectance = 0.3f,
        SpecularPower = 50,
        SpecularTerm = 1.2f
      };
      bool eqeq = m1 == m2;
      Assert.IsTrue(eqeq);
    }

    [TestMethod]
    public void Material_EqEq_differentiates_two_materials_successfully_on_colour() {
      var m1 = new Material() {
        Colour = System.Drawing.Color.Green,
        Reflectance = 0.3f,
        SpecularPower = 50,
        SpecularTerm = 1.2f
      };
      var m2 = new Material() {
        Colour = System.Drawing.Color.Teal,
        Reflectance = 0.3f,
        SpecularPower = 50,
        SpecularTerm = 1.2f
      };
      bool eqeq = m1 == m2;
      Assert.IsFalse(eqeq);
    }

    [TestMethod]
    public void Material_EqEq_differentiates_two_materials_successfully_on_reflectance() {
      var m1 = new Material() {
        Colour = System.Drawing.Color.Green,
        Reflectance = 0.3f,
        SpecularPower = 50,
        SpecularTerm = 1.2f
      };
      var m2 = new Material() {
        Colour = System.Drawing.Color.Green,
        Reflectance = 0.5f,
        SpecularPower = 50,
        SpecularTerm = 1.2f
      };
      bool eqeq = m1 == m2;
      Assert.IsFalse(eqeq);
    }

    [TestMethod]
    public void Material_EqEq_differentiates_two_materials_successfully_on_specular_power() {
      var m1 = new Material() {
        Colour = System.Drawing.Color.Green,
        Reflectance = 0.3f,
        SpecularPower = 50,
        SpecularTerm = 1.2f
      };
      var m2 = new Material() {
        Colour = System.Drawing.Color.Green,
        Reflectance = 0.3f,
        SpecularPower = 80,
        SpecularTerm = 1.2f
      };
      bool eqeq = m1 == m2;
      Assert.IsFalse(eqeq);
    }

    [TestMethod]
    public void Material_EqEq_differentiates_two_materials_successfully_on_specular_term() {
      var m1 = new Material() {
        Colour = System.Drawing.Color.Green,
        Reflectance = 0.3f,
        SpecularPower = 50,
        SpecularTerm = 1.2f
      };
      var m2 = new Material() {
        Colour = System.Drawing.Color.Green,
        Reflectance = 0.3f,
        SpecularPower = 50,
        SpecularTerm = 0.8f
      };
      bool eqeq = m1 == m2;
      Assert.IsFalse(eqeq);
    }

    [TestMethod]
    public void Material_EqEq_returns_false_given_null_lhs() {
      Material m1 = null;
      var m2 = new Material();
      bool eqeq = m1 == m2;
      Assert.IsFalse(eqeq);
    }

    [TestMethod]
    public void Material_EqEq_returns_false_given_null_rhs() {
      var m1 = new Material();
      Material m2 = null;
      bool eqeq = m1 == m2;
      Assert.IsFalse(eqeq);
    }

    [TestMethod]
    public void Material_EqEq_returns_true_given_same_object_twice() {
      var m1 = new Material();
      var m2 = m1;
      bool eqeq = m1 == m2;
      Assert.IsTrue(eqeq);
    }

    [TestMethod]
    public void Material_EqEq_returns_true_given_two_nulls() {
      Material m1 = null;
      Material m2 = null;
      bool eqeq = m1 == m2;
      Assert.IsTrue(eqeq);
    }

    [TestMethod]
    public void Material_GetHashCode_returns() {
      Material m = new Material();
      m.GetHashCode();
    }

    [TestMethod]
    public void Material_GetHashCode_returns_different_hashes_for_different_objects() {
      var m1 = new Material() {
        Colour = System.Drawing.Color.Green,
        Reflectance = 0.3f,
        SpecularPower = 50,
        SpecularTerm = 1.2f
      };
      var m2 = new Material() {
        Colour = System.Drawing.Color.Teal,
        Reflectance = 0.5f,
        SpecularPower = 80,
        SpecularTerm = 0.8f
      };
      var hash1 = m1.GetHashCode();
      var hash2 = m2.GetHashCode();
      Assert.AreNotEqual(hash1, hash2);
    }

    [TestMethod]
    public void Material_GetHashCode_returns_same_hash_for_equivalent_objects() {
      var m1 = new Material() {
        Colour = System.Drawing.Color.Green,
        Reflectance = 0.3f,
        SpecularPower = 50,
        SpecularTerm = 1.2f
      };
      var m2 = new Material() {
        Colour = System.Drawing.Color.Green,
        Reflectance = 0.3f,
        SpecularPower = 50,
        SpecularTerm = 1.2f
      };
      var hash1 = m1.GetHashCode();
      var hash2 = m2.GetHashCode();
      Assert.AreEqual(hash1, hash2);
    }

    [TestMethod]
    public void Material_GetHashCode_returns_same_hash_for_same_object() {
      var m1 = new Material();
      var m2 = m1;
      var hash1 = m1.GetHashCode();
      var hash2 = m2.GetHashCode();
      Assert.AreEqual(hash1, hash2);
    }

    [TestMethod]
    public void Material_Neq_compares_two_materials_successfully() {
      var m1 = new Material() {
        Colour = System.Drawing.Color.Green,
        Reflectance = 0.3f,
        SpecularPower = 50,
        SpecularTerm = 1.2f
      };
      var m2 = new Material() {
        Colour = System.Drawing.Color.Green,
        Reflectance = 0.3f,
        SpecularPower = 50,
        SpecularTerm = 1.2f
      };
      bool neq = m1 != m2;
      Assert.IsFalse(neq);
    }

    [TestMethod]
    public void Material_Neq_differentiates_two_materials_successfully_on_colour() {
      var m1 = new Material() {
        Colour = System.Drawing.Color.Green,
        Reflectance = 0.3f,
        SpecularPower = 50,
        SpecularTerm = 1.2f
      };
      var m2 = new Material() {
        Colour = System.Drawing.Color.Teal,
        Reflectance = 0.3f,
        SpecularPower = 50,
        SpecularTerm = 1.2f
      };
      bool neq = m1 != m2;
      Assert.IsTrue(neq);
    }

    [TestMethod]
    public void Material_Neq_differentiates_two_materials_successfully_on_reflectance() {
      var m1 = new Material() {
        Colour = System.Drawing.Color.Green,
        Reflectance = 0.3f,
        SpecularPower = 50,
        SpecularTerm = 1.2f
      };
      var m2 = new Material() {
        Colour = System.Drawing.Color.Green,
        Reflectance = 0.5f,
        SpecularPower = 50,
        SpecularTerm = 1.2f
      };
      bool neq = m1 != m2;
      Assert.IsTrue(neq);
    }

    [TestMethod]
    public void Material_Neq_differentiates_two_materials_successfully_on_specular_power() {
      var m1 = new Material() {
        Colour = System.Drawing.Color.Green,
        Reflectance = 0.3f,
        SpecularPower = 50,
        SpecularTerm = 1.2f
      };
      var m2 = new Material() {
        Colour = System.Drawing.Color.Green,
        Reflectance = 0.3f,
        SpecularPower = 80,
        SpecularTerm = 1.2f
      };
      bool neq = m1 != m2;
      Assert.IsTrue(neq);
    }

    [TestMethod]
    public void Material_Neq_differentiates_two_materials_successfully_on_specular_term() {
      var m1 = new Material() {
        Colour = System.Drawing.Color.Green,
        Reflectance = 0.3f,
        SpecularPower = 50,
        SpecularTerm = 1.2f
      };
      var m2 = new Material() {
        Colour = System.Drawing.Color.Green,
        Reflectance = 0.3f,
        SpecularPower = 50,
        SpecularTerm = 0.8f
      };
      bool neq = m1 != m2;
      Assert.IsTrue(neq);
    }

    [TestMethod]
    public void Material_Neq_returns_false_given_same_object_twice() {
      var m1 = new Material();
      var m2 = m1;
      bool neq = m1 != m2;
      Assert.IsFalse(neq);
    }

    [TestMethod]
    public void Material_Neq_returns_false_given_two_nulls() {
      Material m1 = null;
      Material m2 = null;
      bool neq = m1 != m2;
      Assert.IsFalse(neq);
    }

    [TestMethod]
    public void Material_Neq_returns_true_given_null_lhs() {
      Material m1 = null;
      var m2 = new Material();
      bool neq = m1 != m2;
      Assert.IsTrue(neq);
    }

    [TestMethod]
    public void Material_Neq_returns_true_given_null_rhs() {
      var m1 = new Material();
      Material m2 = null;
      bool neq = m1 != m2;
      Assert.IsTrue(neq);
    }




    [TestMethod]
    public void Material_Equals_compares_two_materials_successfully() {
      var m1 = new Material() {
        Colour = System.Drawing.Color.Green,
        Reflectance = 0.3f,
        SpecularPower = 50,
        SpecularTerm = 1.2f
      };
      var m2 = new Material() {
        Colour = System.Drawing.Color.Green,
        Reflectance = 0.3f,
        SpecularPower = 50,
        SpecularTerm = 1.2f
      };
      bool eqeq = m1.Equals( m2);
      Assert.IsTrue(eqeq);
    }

    [TestMethod]
    public void Material_Equals_differentiates_two_materials_successfully_on_colour() {
      var m1 = new Material() {
        Colour = System.Drawing.Color.Green,
        Reflectance = 0.3f,
        SpecularPower = 50,
        SpecularTerm = 1.2f
      };
      var m2 = new Material() {
        Colour = System.Drawing.Color.Teal,
        Reflectance = 0.3f,
        SpecularPower = 50,
        SpecularTerm = 1.2f
      };
      bool eqeq = m1.Equals(m2);
      Assert.IsFalse(eqeq);
    }

    [TestMethod]
    public void Material_Equals_differentiates_two_materials_successfully_on_reflectance() {
      var m1 = new Material() {
        Colour = System.Drawing.Color.Green,
        Reflectance = 0.3f,
        SpecularPower = 50,
        SpecularTerm = 1.2f
      };
      var m2 = new Material() {
        Colour = System.Drawing.Color.Green,
        Reflectance = 0.5f,
        SpecularPower = 50,
        SpecularTerm = 1.2f
      };
      bool eqeq = m1.Equals(m2);
      Assert.IsFalse(eqeq);
    }

    [TestMethod]
    public void Material_Equals_differentiates_two_materials_successfully_on_specular_power() {
      var m1 = new Material() {
        Colour = System.Drawing.Color.Green,
        Reflectance = 0.3f,
        SpecularPower = 50,
        SpecularTerm = 1.2f
      };
      var m2 = new Material() {
        Colour = System.Drawing.Color.Green,
        Reflectance = 0.3f,
        SpecularPower = 80,
        SpecularTerm = 1.2f
      };
      bool eqeq = m1.Equals(m2);
      Assert.IsFalse(eqeq);
    }

    [TestMethod]
    public void Material_Equals_differentiates_two_materials_successfully_on_specular_term() {
      var m1 = new Material() {
        Colour = System.Drawing.Color.Green,
        Reflectance = 0.3f,
        SpecularPower = 50,
        SpecularTerm = 1.2f
      };
      var m2 = new Material() {
        Colour = System.Drawing.Color.Green,
        Reflectance = 0.3f,
        SpecularPower = 50,
        SpecularTerm = 0.8f
      };
      bool eqeq = m1.Equals(m2);
      Assert.IsFalse(eqeq);
    }

    [TestMethod]
    public void Material_Equals_returns_false_given_non_material() {
      var m = new Material() {
        Colour = System.Drawing.Color.Green,
        Reflectance = 0.3f,
        SpecularPower = 50,
        SpecularTerm = 1.2f
      };
      var p = new Point(0.0f, 0.0f, 0.0f);
      bool eqeq = m.Equals(p);
      Assert.IsFalse(eqeq);
    }

    [TestMethod]
    public void Material_Equals_returns_false_given_null_rhs() {
      var m1 = new Material();
      Material m2 = null;
      bool eqeq = m1 == m2;
      Assert.IsFalse(eqeq);
    }


    [TestMethod]
    public void Material_Equals_returns_true_given_same_object_twice() {
      var m1 = new Material();
      var m2 = m1;
      bool eqeq = m1.Equals(m2);
      Assert.IsTrue(eqeq);
    }
  }
}