using RayManCS;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowTracer {

  internal sealed class RealtimeWindowOutput : IOutput {
    private Form form;
    private MyMethodInvoker func;
    private Graphics g;
    private Bitmap image;

    public RealtimeWindowOutput(uint width, uint height, Form form) {
      Width = width;
      Height = height;

      image = new Bitmap((int)Width, (int)Height);

      this.form = form;
      form.Width = (int)Width;
      form.Height = (int)Height;
      form.FormBorderStyle = FormBorderStyle.FixedSingle;
      form.BackColor = Color.White;
      form.BackgroundImage = image;

      g = form.CreateGraphics();

      func = new MyMethodInvoker(WritePixel);
    }

    private delegate void MyMethodInvoker(uint x, uint y, Color c);

    public uint Height {
      get;
      private set;
    }

    public uint Width {
      get;
      private set;
    }

    public void Write(uint x, uint y, Color c) {
      try {
        form.Invoke(func, x, y, c);
      } catch (InvalidOperationException) {
      }
    }

    private void WritePixel(uint x, uint y, Color c) {
      lock (g) {
        g.DrawLine(new Pen(c), (float)x, (float)(Height - y - 1), (float)x + 0.5f, (float)(Height - y - 0.5f));
        image.SetPixel((int)x, (int)(Height - y - 1), c);
      }
    }
  }
}