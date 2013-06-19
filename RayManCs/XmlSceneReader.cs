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

      AddCamera(document["Scene"], scene);
      AddLights(document["Scene"], scene);
      AddObjects(document["Scene"], scene);

      return scene;
    }

    private void AddCamera(XmlNode sceneNode, Scene scene) {
      var cameraNode = sceneNode["Camera"];
      var camera = cameraNode.ChildNodes[0];

      var objectType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == camera.Name);
      // Position
      Point position = CreatePosition(camera["Position"].InnerText);
      // Up
      Vector up = CreateVector(camera["Up"].InnerText);
      // Right
      Vector right = CreateVector(camera["Right"].InnerText);
      // Width
      float width = float.Parse(camera["Width"].InnerText);
      // Height
      float height = float.Parse(camera["Height"].InnerText);

      scene.Camera = Activator.CreateInstance(objectType, new object[] { position, up, right, width, height }) as Camera;
    }

    private void AddLights(XmlNode sceneNode, Scene scene) {
      var lightNodes = sceneNode["Lights"];
      foreach (XmlNode light in lightNodes.ChildNodes) {
        var objectType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == light.Name);
        Point position = CreatePosition(light["Position"].InnerText);
        var l = Activator.CreateInstance(objectType, new object[] { position }) as Light;
        l.Colour = CreateColour(light["Colour"].InnerText);
        ;
        scene.AddLight(l);
      }
    }

    private void AddObjects(XmlNode sceneNode, Scene scene) {
      var objectNodes = sceneNode["Objects"];
      foreach (XmlNode o in objectNodes.ChildNodes) {
        var objectType = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(t => t.Name == o.Name);
        Point centre = CreatePosition(o["Centre"].InnerText);
        float size = float.Parse(o["Size"].InnerText);
        var obj = Activator.CreateInstance(objectType, new object[] { centre, size }) as Object;
        obj.Material = CreateMaterial(sceneNode, o["Material"]);
        scene.AddObject(obj);
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

      return m;
    }

    private Point CreatePosition(string position) {
      var splitPosition = position.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
      return new Point(float.Parse(splitPosition[0]), float.Parse(splitPosition[1]), float.Parse(splitPosition[2]));
    }

    private Vector CreateVector(string vector) {
      var splitVector = vector.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);
      return new Vector(float.Parse(splitVector[0]), float.Parse(splitVector[1]), float.Parse(splitVector[2]));
    }
  }
}