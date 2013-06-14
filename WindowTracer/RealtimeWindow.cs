using RayManCS;
using System;
using System.Drawing.Imaging;
using System.Threading;
using System.Windows.Forms;

namespace WindowTracer {

internal sealed partial class RealtimeWindow : Form {
  private RealtimeWindowOutput output;
  private Scene s;
  private Thread t;

  public RealtimeWindow() {
    InitializeComponent();
    output = new RealtimeWindowOutput(640, 480, this);
    s = new Scene(output);
    s.Camera = new OrthographicCamera(new RayManCS.Point(0.0f, 0.0f, 0.0f), new Vector(0.0f, 1.0f, 0.0f), new Vector(1.0f, 0.0f, 0.0f), 320, 240);
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
    s.Draw();
  }
}
}