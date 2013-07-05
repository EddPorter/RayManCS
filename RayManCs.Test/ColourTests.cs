using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace RayManCS.Test {

  [TestClass]
  public class ColourTests {
    private float EPSILON = 0.000001f;

    [TestMethod]
    public void Colour_Constructor_does_not_limit_blue_to_one() {
      float red = 0.0f;
      float green = 1.0f;
      float blue = 1.5f;

      var colour = new Colour(red, green, blue);

      Assert.AreEqual(colour.Blue, 1.5f, EPSILON);
    }

    [TestMethod]
    public void Colour_Constructor_does_not_limit_green_to_one() {
      float red = 0.0f;
      float green = 1.5f;
      float blue = 0.5f;

      var colour = new Colour(red, green, blue);

      Assert.AreEqual(colour.Green, 1.5f, EPSILON);
    }

    [TestMethod]
    public void Colour_Constructor_does_not_limit_red_to_one() {
      float red = 1.5f;
      float green = 1.0f;
      float blue = 0.5f;

      var colour = new Colour(red, green, blue);

      Assert.AreEqual(colour.Red, 1.5f, EPSILON);
    }

    [TestMethod]
    public void Colour_Constructor_returns_object_given_valid_parameters() {
      float red = 0.0f;
      float green = 1.0f;
      float blue = 0.5f;

      var colour = new Colour(red, green, blue);

      Assert.IsNotNull(colour);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Colour_Constructor_throws_given_nonpositive_blue() {
      float red = 0.0f;
      float green = 1.0f;
      float blue = -0.5f;

      new Colour(red, green, blue);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Colour_Constructor_throws_given_nonpositive_gren() {
      float red = 0.0f;
      float green = -1.0f;
      float blue = 0.5f;

      new Colour(red, green, blue);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Colour_Constructor_throws_given_nonpositive_red() {
      float red = -1.0f;
      float green = 1.0f;
      float blue = 0.5f;

      new Colour(red, green, blue);
    }

    [TestMethod]
    public void Operator_Add_combines_two_colours_correctly() {
      Colour lhs = new Colour(0.5f, 0.3f, 0.55f);
      Colour rhs = new Colour(0.6f, 0.3f, 0.4f);
      var newColour = lhs + rhs;
      Assert.AreEqual(1.1f, newColour.Red, EPSILON);
      Assert.AreEqual(0.6f, newColour.Green, EPSILON);
      Assert.AreEqual(0.95f, newColour.Blue, EPSILON);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Operator_Add_throws_given_null_lhs() {
      Colour lhs = null;
      Colour rhs = new Colour(0.5f, 0.3f, 1.0f);
      var scaledColour = lhs + rhs;
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Operator_Add_throws_given_null_rhs() {
      Colour lhs = new Colour(0.5f, 0.3f, 1.0f);
      Colour rhs = null;
      var scaledColour = lhs + rhs;
    }

    [TestMethod]
    public void Operator_Color_converts_color_correctly() {
      var color = System.Drawing.Color.Bisque;
      var colour = (Colour)color;
      Assert.AreEqual((float)color.R / color.G, colour.Red / colour.Green, EPSILON);
      Assert.AreEqual((float)color.G / color.B, colour.Green / colour.Blue, EPSILON);
      Assert.AreEqual((float)color.B / color.R, colour.Blue / colour.Red, EPSILON);
    }

    [TestMethod]
    public void Operator_Color_creates_new_colour_object() {
      var color = System.Drawing.Color.Bisque;
      var colour = (Colour)color;
      Assert.IsNotNull(colour);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Operator_Color_throws_given_null_colour() {
      Colour colour = null;
      System.Drawing.Color color = (System.Drawing.Color)colour;
    }

    [TestMethod]
    public void Operator_Colour_converts_to_color_correctly() {
      var colour = new Colour(1.0f, 0.8f, 0.5f);
      var color = (System.Drawing.Color)colour;
      Assert.AreEqual((float)color.R / color.G, colour.Red / colour.Green, 2.0f / 255);
      Assert.AreEqual((float)color.G / color.B, colour.Green / colour.Blue, 2.0f / 255);
      Assert.AreEqual((float)color.B / color.R, colour.Blue / colour.Red, 2.0f / 255);
    }

    [TestMethod]
    public void Operator_Multiply_combines_two_colours_correctly() {
      Colour lhs = new Colour(0.5f, 0.3f, 0.9f);
      Colour rhs = new Colour(0.5f, 1.0f, 0.8f);
      var newColour = lhs * rhs;
      Assert.AreEqual(0.25f, newColour.Red, EPSILON);
      Assert.AreEqual(0.3f, newColour.Green, EPSILON);
      Assert.AreEqual(0.72f, newColour.Blue, EPSILON);
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentOutOfRangeException))]
    public void Operator_Multiply_throws_given_negative_factor() {
      var colour = new Colour(1.0f, 0.8f, 0.5f);
      var scaledColour = colour * -1.0f;
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Operator_Multiply_throws_given_null_colour() {
      Colour colour = null;
      var scaledColour = colour * 0.5f;
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Operator_Multiply_throws_given_null_lhs() {
      Colour lhs = null;
      Colour rhs = new Colour(0.5f, 0.3f, 1.0f);
      var scaledColour = lhs * rhs;
    }

    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void Operator_Multiply_throws_given_null_rhs() {
      Colour lhs = new Colour(0.5f, 0.3f, 1.0f);
      Colour rhs = null;
      var scaledColour = lhs * rhs;
    }

    [TestMethod]
    public void Operator_Multipy_scales_colour_correctly() {
      var colour = new Colour(1.0f, 0.8f, 0.5f);
      var scaledColour = colour * 1.1f;
      Assert.AreEqual(scaledColour.Red, 1.1f, EPSILON);
      Assert.AreEqual(scaledColour.Green, 0.88f, EPSILON);
      Assert.AreEqual(scaledColour.Blue, 0.55f, EPSILON);
    }

    [TestMethod]
    public void Colour_ToSrgb_Converts_White_Rgb_Values_Correctly() {
      var colour = new Colour(1.0f, 1.0f, 1.0f);
      var srgb = colour.ToSrgb();
      Assert.AreEqual(srgb.Red, 1.0f,EPSILON);
      Assert.AreEqual(srgb.Green, 1.0f,EPSILON);
      Assert.AreEqual(srgb.Blue, 1.0f,EPSILON);
    }
    [TestMethod]
    public void Colour_ToSrgb_Converts_Clips_Larger_Than_White_Rgb_Values_Correctly() {
      var colour = new Colour(1.5f, 2.0f, 5.0f);
      var srgb = colour.ToSrgb();
      Assert.AreEqual(srgb.Red, 1.0f, EPSILON);
      Assert.AreEqual(srgb.Green, 1.0f, EPSILON);
      Assert.AreEqual(srgb.Blue, 1.0f, EPSILON);
    }

    [TestMethod]
    public void Colour_ToSrgb_Converts_Black_Rgb_Values_Correctly() {
      var colour = new Colour(0.0f, 0.0f, 0.0f);
      var srgb = colour.ToSrgb();
      Assert.AreEqual(srgb.Red, 0.0f, EPSILON);
      Assert.AreEqual(srgb.Green, 0.0f, EPSILON);
      Assert.AreEqual(srgb.Blue, 0.0f, EPSILON);
    }
  }
}