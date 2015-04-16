using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetFighter
{
    class Animation
    {
        private Vector2 offset;
        private float fps;
        private Rectangle[] rectangles;

        public Vector2 Offset
        {
            get { return offset; }
            set { offset = value; }
        }

        public float Fps
        {
            get { return fps; }
            set { fps = value; }
        }

        public Rectangle[] Rectangles
        {
            get { return rectangles; }
            set { rectangles = value; }
        }
        private Color[][] color;

        public Color[][] Color
        {
            get { return color; }
            set { color = value; }
        }

        public Animation(int frames, int posY, int xStartFrame, int width, int height, Vector2 offset, float finFps, Texture2D texture)
        {

        }
    }
}
