using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Drawing;

namespace Lab4
{
    internal class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            using (var window = new Window3D())
            {
                window.Run(60.0);
            }
        }
    }
}
