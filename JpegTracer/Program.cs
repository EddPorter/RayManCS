using RayManCS;

namespace JpegTracer {

internal static class Program {

  public static void Main(string[] args) {
    var output = new JpegOutput(640, 480);
    var scene = new Scene(output);
    scene.Camera = new OrthographicCamera(new Point(320.0f, 240.0f, -1000.0f), new Vector(0.0f, 1.0f, 0.0f), new Vector(1.0f, 0.0f, 0.0f), 640, 480);

    scene.AddObject(new Sphere(new Point(233.0f, 290.0f, 0.0f), 100.0f));
    scene.AddObject(new Sphere(new Point(407.0f, 290.0f, 0.0f), 100.0f) {
      Material = new Material {
        Colour = System.Drawing.Color.Cyan
      }
    });
    scene.AddObject(new Sphere(new Point(320.0f, 140.0f, 0.0f), 100.0f) {
      Material = new Material {
        Colour = System.Drawing.Color.Magenta
      }
    });

    scene.AddLight(new DiffuseLight(new Point(0.0f, 240.0f, -100.0f)) {
      Colour = System.Drawing.Color.White
    });
    scene.AddLight(new DiffuseLight(new Point(640.0f, 240.0f, -10000.0f)) {
      Colour = System.Drawing.Color.FromArgb((int)(0.6f * 255), (int)(0.7f * 255), 255)
    });

    scene.Draw();
    output.Save("output.jpg");
  }
}
}