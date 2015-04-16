using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetFighter
{
    class SpriteObject
    {
        protected Texture2D texture;
        private Vector2 position;
        private Vector2 origin;
        private int layer;
        private int scale;
        protected Color color;
        protected float speed;
        protected Vector2 velocity;
        private Rectangle[] rectangles;
        private SpriteEffects effect;
        private int frame;
        private int currentIndex;
        private float timeElapsed;
        protected float fps;
        private Vector2 offset;
        private Vector2 boxTexture;
        private Dictionary<String, Animation> animations;
        public Rectangle collisionRect;

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public SpriteObject(Vector2 position, int frames)
        {

        }

        public void LoadContent(ContentManager content)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {

        }

        public void Update(GameTime gameTime)
        {

        }

        protected void CreateAnimation(string name, int frames, int posY, int xStartFrame, int width, int height, Vector2 offset, float fps, Texture2D texture)
        {

        }

        protected void PlayAnimation(string name)
        {

        }

        private void HandleCollision()
        {

        }

        private bool PixelCollision()
        {
            return false;
        }

        public void OnCollisionEnter(SpriteObject other)
        {

        }

        public void OnCollisionExit(SpriteObject other)
        {

        }

        public void AnimationDone(string name)
        {

        }
    }
}
