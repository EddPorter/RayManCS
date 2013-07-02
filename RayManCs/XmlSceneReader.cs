using System;
using System.Linq;
using System.Reflection;
using System.Xml;

namespace RayManCS {

/// <summary>
///
/// </summary>
public sealed class XmlSceneReader {
  private XmlDocument document;

  /// <summary>
  /// Initializes a new instance of the RayManCS.XmlSceneReader class.
  /// </summary>
  public XmlSceneReader() {
    document = new XmlDocument();
  }

  /// <summary>
  /// Loads the XML scene document from the specified URL.
  /// </summary>
  /// <param name="filename">URL for the file containing the XML document to load. The URL can be either a local file or an HTTP URL (a Web address).</param>
  /// <param name="output"></param>
  public Scene Load(string filename, IOutput output) {
    document.Load(filename);
    Scene scene = new Scene(output);

    ConfigureScene(document["RayMan"], scene);
    AddCamera(document["RayMan"], scene);
    AddLights(document["RayMan"], scene);
    AddObjects(document["RayMan"], scene);

    return scene;
  }

  private void AddCamera(XmlNode rayManNode, Scene scene) {
    var cameraNode = rayManNode["Camera"];
    var camera = cameraNode.ChildNodes[0];

    var objectType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == camera.Name);
    // Position
    Point position = CreatePoint(camera["Position"].InnerText);
    // Width
    float width = float.Parse(camera["Width"].InnerText);
    // Height
    float height = float.Parse(camera["Height"].InnerText);
    if (camera["Up"] != null) {
      // Up
      Vector up = CreateVector(camera["Up"].InnerText);
      // Right
      Vector right = CreateVector(camera["Right"].InnerText);
      scene.Camera = Activator.CreateInstance(objectType, new object[] { position, up, right, width, height }) as Camera;
    } else {
      Point lookAt = CreatePoint(camera["LookAt"].InnerText);
      scene.Camera = Activator.CreateInstance(objectType, new object[] { position, lookAt, width, height }) as Camera;
    }
  }

  private void AddLights(XmlNode rayManNode, Scene scene) {
    var lightNodes = rayManNode["Lights"];
    foreach (XmlNode light in lightNodes.ChildNodes) {
      var objectType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == light.Name);
      Point position = CreatePoint(light["Position"].InnerText);
      var l = Activator.CreateInstance(objectType, new object[] { position }) as Light;
      l.Colour = CreateColour(light["Colour"].InnerText);
      ;
      scene.AddLight(l);
    }
  }

  private void AddObjects(XmlNode rayManNode, Scene scene) {
    var objectNodes = rayManNode["Objects"];
    foreach (XmlNode o in objectNodes.ChildNodes) {
      var objectType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == o.Name);
      Object obj = null;
      switch (o.Name) {
        case "Sphere":
          Point centre = CreatePoint(o["Centre"].InnerText);
          float size = float.Parse(o["Size"].InnerText);
          obj = Activator.CreateInstance(objectType, new object[] { centre, size }) as Object;
          break;

        case "Triangle":
          Point p1 = CreatePoint(o["P1"].InnerText);
          Point p2 = CreatePoint(o["P2"].InnerText);
          Point p3 = CreatePoint(o["P3"].InnerText);
          obj = Activator.CreateInstance(objectType, new object[] { p1, p2, p3 }) as Object;
          break;
      }
      obj.Material = CreateMaterial(rayManNode, o["Material"]);
      scene.AddObject(obj);
    }
  }

  private void ConfigureScene(XmlNode rayManNode, Scene scene) {
    var sceneNode = rayManNode["Scene"];

    foreach (XmlNode node in sceneNode.ChildNodes) {
      switch (node.Name) {
        case "SubSampling":
          scene.SubSampling = uint.Parse(node.InnerText);
          break;

        default:
          throw new InvalidOperationException("Scene file is not recognised.");
      }
    }
  }

  private Colour CreateColour(string colour) {
    var splitColour = colour.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
    return new Colour(float.Parse(splitColour[0]), float.Parse(splitColour[1]), float.Parse(splitColour[2]));
  }

  private Material CreateMaterial(XmlNode sceneNode, XmlNode material) {
    var id = material.Attributes["id"];
    if (id != null) {
      material = sceneNode.SelectSingleNode("Materials/Material[@id='" + id.Value + "']");
    }

    Material m = new Material();
    m.Colour = CreateColour(material["Colour"].InnerText);
    if (material["SpecularTerm"] != null) {
      m.SpecularTerm = float.Parse(material["SpecularTerm"].InnerText);
    }
    if (material["SpecularPower"] != null) {
      m.SpecularPower = float.Parse(material["SpecularPower"].InnerText);
    }
    if (material["Reflectance"] != null) {
      m.Reflectance = float.Parse(material["Reflectance"].InnerText);
    }

    return m;
  }

  private Point CreatePoint(string position) {
    var splitPosition = position.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
    return new Point(float.Parse(splitPosition[0]), float.Parse(splitPosition[1]), float.Parse(splitPosition[2]));
  }

  private Vector CreateVector(string vector) {
    var splitVector = vector.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
    return new Vector(float.Parse(splitVector[0]), float.Parse(splitVector[1]), float.Parse(splitVector[2]));
  }
}
}