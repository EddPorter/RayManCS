using RayManCS;
using System;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;

namespace WindowTracer {

internal sealed partial class RealtimeWindow : Form {
  private RealtimeWindowOutput output;
  private Scene scene;
  private Thread t;

  public RealtimeWindow() {
    InitializeComponent();
    output = new RealtimeWindowOutput(640, 480, this);
    scene = new Scene(output);
    scene.Camera = new OrthographicCamera(new RayManCS.Point(0.0f, 0.0f, 0.0f), new Vector(0.0f, 1.0f, 0.0f), new Vector(1.0f, 0.0f, 0.0f), 80, 60);

    scene.AddObject(new Sphere(new Point(-5.0f, -5.0f, 50.0f), 10.0f));
    scene.AddObject(new Sphere(new Point(-20.0f, -20.0f, 150.0f), 5.0f));
    scene.AddObject(new Sphere(new Point(20.0f, 10.0f, 100.0f), 15.0f));
    scene.AddObject(new Sphere(new Point(0.0f, -15.0f, 150.0f), 5.0f));

    scene.AddLight(new DiffuseLight(new Point(-50.0f, 0.0f, 0.0f), new Vector(50.0f, 0.0f, 100.0f)));
  }

  private void Form1_FormClosing(object sender, FormClosingEventArgs e) {
    if (t.IsAlive) {
      t.Abort();
    } else {
      BackgroundImage.Save("output.jpg", ImageFormat.Jpeg);
    }
  }

  private void Form1_Load(object sender, EventArgs e) {
    t = new Thread(start);
    t.Start();
  }

  private void start(object obj) {
    scene.Draw();
  }
}
}