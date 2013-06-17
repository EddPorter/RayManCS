using RayManCS;
using System.Drawing;
using System.Drawing.Imaging;

namespace JpegTracer {

internal sealed class JpegOutput : IOutput {
  private Bitmap image;

  public JpegOutput(uint width, uint height) {
    Width = width;
    Height = height;
    image = new Bitmap((int)width, (int)height);
  }

  public uint Height {
    get;
    private set;
  }

  public uint Width {
    get;
    private set;
  }

  public void Save(string fileName) {
    lock (image) {
      image.Save(fileName, ImageFormat.Jpeg);
    }
  }

  public void Write(uint x, uint y, Color colour) {
    Pen p = new Pen(colour);
    lock (image) {
      image.SetPixel((int)x, (int)(Height - y - 1), colour);
    }
  }
}
}