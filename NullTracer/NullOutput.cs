using RayManCS;
using System.Drawing;

namespace NullTracer {

  internal sealed class NullOutput : IOutput {

    public NullOutput(uint width, uint height) {
      Width = width;
      Height = height;
    }

    public uint Height {
      get;
      private set;
    }

    public uint Width {
      get;
      private set;
    }

    public void Write(uint x, uint y, Color colour) {
    }
  }
}