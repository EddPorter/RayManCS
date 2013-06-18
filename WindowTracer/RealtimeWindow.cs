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
    scene.Camera = new OrthographicCamera(new Point(320.0f, 240.0f, -1000.0f), new Vector(0.0f, 1.0f, 0.0f), new Vector(1.0f, 0.0f, 0.0f), 640, 480);

    scene.AddObject(new Sphere(new Point(400.0f, 290.0f, 320.0f), 50.0f) {
      Material = new Material {
        Colour = System.Drawing.Color.FromArgb((int)(0.35f * 255), (int)(0.25f * 255), (int)(0.01f * 255))
      }
    });
    scene.AddObject(new Sphere(new Point(600.0f, 290.0f, 480.0f), 100.0f) {
      Material = new Material {
        Colour = System.Drawing.Color.White
      }
    });
    scene.AddObject(new Sphere(new Point(450.0f, 140.0f, 400.0f), 50.0f) {
      Material = new Material {
        Colour = System.Drawing.Color.FromArgb((int)(0.5f * 255), (int)(0.5f * 255), (int)(0.5f * 255))
      }
    });

    var blobColour = System.Drawing.Color.White;
    var blobMaterial = new Material {
      Colour = blobColour
    };
    scene.AddObject(new Sphere(new Point(60.0f, 290.0f, 320.0f), 80.0f) {
      Material = blobMaterial
    });
    scene.AddObject(new Sphere(new Point(400.0f, 290.0f, 480.0f), 80.0f) {
      Material = blobMaterial
    });
    scene.AddObject(new Sphere(new Point(250.0f, 140.0f, 400.0f), 80.0f) {
      Material = blobMaterial
    });


    scene.AddLight(new DiffuseLight(new Point(0.0f, 240.0f, 300.0f)) {
      Colour = System.Drawing.Color.White
    });
    scene.AddLight(new DiffuseLight(new Point(640.0f, 480.0f, -100.0f)) {
      Colour = System.Drawing.Color.FromArgb((int)(0.6f * 255), (int)(0.7f * 255), (int)(1.0f * 255))
    });
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