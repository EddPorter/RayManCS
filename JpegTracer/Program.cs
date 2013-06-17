﻿using RayManCS;

namespace JpegTracer {

  internal static class Program {

    public static void Main(string[] args) {
      var output = new JpegOutput(640, 480);
      var scene = new Scene(output);
      scene.Camera = new OrthographicCamera(new Point(0.0f, 0.0f, 0.0f), new Vector(0.0f, 1.0f, 0.0f), new Vector(1.0f, 0.0f, 0.0f), 80, 60);

      scene.AddObject(new Sphere(new Point(-5.0f, -5.0f, 50.0f), 10.0f));
      scene.AddObject(new Sphere(new Point(-20.0f, 10.0f, 150.0f), 5.0f));
      scene.AddObject(new Sphere(new Point(20.0f, 10.0f, 100.0f), 15.0f));
      scene.AddObject(new Sphere(new Point(0.0f, -15.0f, 150.0f), 5.0f));

      scene.AddLight(new DiffuseLight(new Point(-50.0f, 0.0f, 0.0f), new Vector(50.0f, 0.0f, 100.0f)));
      scene.AddLight(new DiffuseLight(new Point(0.0f, 1000.0f, 1000.0f), new Vector(0.0f, -1000.0f, -1000.0f)));


      //scene.AddObject(new Sphere(new Point(0.0f, 0.0f, 150.0f), 5.0f));

      //scene.AddLight(new DiffuseLight(new Point(0.0f, 1000.0f, 150.0f), new Vector(0.0f, -1000.0f, 0.0f)));

      scene.Draw();
      output.Save("output.jpg");
    }
  }
}