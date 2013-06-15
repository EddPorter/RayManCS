using RayManCS;

namespace NullTracer {

internal static class Program {

  public static void Main(string[] args) {
    const uint WIDTH = 640;
    const uint HEIGHT = 480;
    var output = new NullOutput(WIDTH, HEIGHT);
    var scene = new Scene(output);
    scene.Camera = new OrthographicCamera(new Point(0.0f, 0.0f, 0.0f), new Vector(0.0f, 1.0f, 0.0f), new Vector(1.0f, 0.0f, 0.0f), WIDTH, HEIGHT);
    scene.Draw();
  }
}
}