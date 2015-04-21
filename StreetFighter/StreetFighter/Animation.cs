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
        private Texture2D texture;

        public Texture2D Texture
        {
            get { return texture; }
        }

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
        private Color[][] colors;

        public Color[][] Colors
        {
            get { return colors; }
            set { colors = value; }
        }

        public Animation(int frames, int posY, int xStartFrame, int width, int height, Vector2 offset, float fps, Texture2D texture)
        {
            rectangles = new Rectangle[frames];

            this.texture = texture;

            colors = new Color[frames][];

            for (int i = 0; i < frames; i++)
            {
                colors[i] = new Color[width * height];

                rectangles[i] = new Rectangle((i + xStartFrame) * width, posY, width, height);

                texture.GetData<Color>(0, rectangles[i], colors[i], 0, width * height);
            }

            this.fps = fps;
            this.offset = offset;
        }
    }
}
