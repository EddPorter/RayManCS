using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;

namespace RayManCS.Test {

/// <summary>
/// Summary description for SceneTests
/// </summary>
[TestClass]
public class SceneTests {

  [TestMethod]
  public void Scene_Constructor_creates_new_object() {
    var output = new Mock<IOutput>().Object;
    new Scene(output);
  }

  [TestMethod]
  [ExpectedException(typeof(ArgumentNullException))]
  public void Scene_Constructor_throws_given_null_output() {
    IOutput output = null;
    new Scene(output);
  }
}
}