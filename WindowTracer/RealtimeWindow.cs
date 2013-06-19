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
      XmlSceneReader reader = new XmlSceneReader();
      scene = reader.Load("Scene.xml", output);
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