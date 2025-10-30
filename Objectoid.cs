using System;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System.Drawing;
using System.Collections.Generic;


namespace Lab4
{
    class Objectoid
    {
        private bool visibility;
        private bool isGravityBound;
        private Color color;
        private List<Vector3d> coordList;
        private Randomizer rando;

        private const int GRAVITY_OFFSET = 1;

        public Objectoid(bool gravity_status)
        {
            rando = new Randomizer();

            visibility = true;
            isGravityBound = gravity_status;
            color = rando.RandomColor();

            coordList = new List<Vector3d>();
            int size_offset = rando.RandomInt(3,7);
            int height_offset = rando.RandomInt(40,60);
            int radial_offset = rando.RandomInt(5,15);

            coordList.Add(new Vector3d(0 * size_offset + radial_offset, 0 * size_offset + height_offset, 1 * size_offset + radial_offset)); 
            coordList.Add(new Vector3d(0 * size_offset + radial_offset, 0 * size_offset + height_offset, 0 * size_offset + radial_offset));
            coordList.Add(new Vector3d(1 * size_offset + radial_offset,0 * size_offset + height_offset,1 * size_offset + radial_offset));
            coordList.Add(new Vector3d(1 * size_offset + radial_offset,0 * size_offset + height_offset,0 * size_offset + radial_offset));
            coordList.Add(new Vector3d(1 * size_offset + radial_offset,1 * size_offset + height_offset,1 * size_offset + radial_offset));
            coordList.Add(new Vector3d(1 * size_offset + radial_offset,1 * size_offset + height_offset,0 * size_offset + radial_offset));
            coordList.Add(new Vector3d(0 * size_offset + radial_offset,1 * size_offset + height_offset,1 * size_offset + radial_offset));
            coordList.Add(new Vector3d(0 * size_offset + radial_offset,1 * size_offset + height_offset,0 * size_offset + radial_offset));
            coordList.Add(new Vector3d(0 * size_offset + radial_offset, 0 * size_offset + height_offset, 1 * size_offset + radial_offset));
            coordList.Add(new Vector3d(0 * size_offset + radial_offset, 0 * size_offset + height_offset, 0 * size_offset + radial_offset));
        }

        public void Draw()
        {
            if (visibility)
            {
                GL.Color3(color);
                GL.Begin(PrimitiveType.QuadStrip);
                foreach (var vert in coordList)
                {
                    GL.Vertex3(vert);
                }
                GL.End();
            }
        }

        public void updatePosition(bool gravity_status)
        {
            if (gravity_status && visibility && !groundCollision())
            {
                for (int i = 0; i < coordList.Count; i++)
                {
                    coordList[i] = new Vector3d(coordList[i].X, coordList[i].Y - GRAVITY_OFFSET, coordList[i].Z);
                }
            }
        }

        public bool groundCollision()
        {
            foreach (Vector3 v in coordList)
            {
                if (v.Y <= 0)
                {
                    return true;
                }
            }
            return false;
        }

        public void ToggleVisibility()
        {
            visibility = !visibility;
        }

        public void ToggleGravity()
        {
            isGravityBound = !isGravityBound;
        }

        public void setGravity()
        {
            isGravityBound = true;
        }

        public void unsetGravity()
        {
            isGravityBound = false;
        }
    }
}
