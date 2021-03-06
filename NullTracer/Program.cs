﻿using RayManCS;

namespace NullTracer {

internal static class Program {

  public static void Main(string[] args) {
    var output = new NullOutput(640, 480);
    XmlSceneReader reader = new XmlSceneReader();
    Scene scene = reader.Load(args[0], output);
    scene.Draw();
  }
}
}