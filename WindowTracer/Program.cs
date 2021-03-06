﻿using System;
using System.Windows.Forms;

namespace WindowTracer {

  internal static class Program {

    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    private static void Main(string[] args) {
      Application.EnableVisualStyles();
      Application.SetCompatibleTextRenderingDefault(false);
      Application.Run(new RealtimeWindow(args[0]));
    }
  }
}