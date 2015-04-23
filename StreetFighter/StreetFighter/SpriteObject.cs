using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetFighter
{
    public abstract class SpriteObject
    {
        protected bool colliding;
        
        protected Texture2D texture;
        protected Vector2 position;
        private Vector2 origin;
        private int layer;
        protected int scale;
        protected Color color;
        protected float speed;
        protected Vector2 velocity;
        protected Rectangle[] rectangles;
        protected SpriteEffects effect;
        private int frame;
        protected int currentIndex;
        private float timeElapsed;
        protected float fps;
        private Vector2 offset;
        private Vector2 boxTexture;
        private Dictionary<String, Animation> animations;
        private string animName;

        public string AnimName
        {
            get { return animName; }
            set { animName = value; }
        }
        
        public Rectangle CollisionRect
        {
            get
            {
                return new Rectangle
                (
                (int)(position.X + offset.X), 
                (int)(position.Y + offset.Y),
                rectangles[0].Width, rectangles[0].Height
                );
            }
            
        }

        public Vector2 Position
        {
            get { return position; }
            set { position = value; }
        }

        public SpriteObject(Vector2 position, int frames)
        {
            this.position = position;
            this.frame = frames;
            color = Color.White;
            origin = new Vector2(0,0);
            effect = SpriteEffects.None;
            layer = 1;
            scale = 1;
            fps = 10;

            colliding = false;

            animations = new Dictionary<string, Animation>();
        }

        public virtual void LoadContent(ContentManager content)
        {

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(animations[animName].Texture, position + offset, rectangles[currentIndex], color, 0f, origin, scale, effect, layer);
        }

        public virtual void Update(GameTime gameTime)
        {
            timeElapsed += (float)gameTime.ElapsedGameTime.TotalSeconds;

            currentIndex = (int)(timeElapsed * fps);

            if (currentIndex > rectangles.Length - 1)
            {
                timeElapsed = 0;
                currentIndex = 0;
                AnimationDone(animName);
            }

            HandleCollision();
        }

        protected void CreateAnimation(string name, int frames, int posY, int xStartFrame, int width, int height, Vector2 offset, float fps, Texture2D texture)
        {
            if (!animations.ContainsKey(name))
            {
                animations.Add(name, new Animation(frames, posY, xStartFrame, width, height, offset, fps, texture));
            }
        }

        protected void PlayAnimation(string name)
        {
            animName = name;
            //rectangles = new Rectangle[animations[name].Rectangles.Length];
            //for (int i = 0; i < animations[name].Rectangles.Length; i++)
            //{
            //    rectangles[i] = animations[name].Rectangles[i];

            //}
            rectangles = animations[name].Rectangles;
            offset = animations[name].Offset;
            fps = animations[name].Fps;
        }

        private void HandleCollision()
        {
            foreach (SpriteObject obj in Game1.AllObjects)
            {
                if (obj != this && obj.GetType() != this.GetType() && obj.CollisionRect.Intersects(this.CollisionRect))
                {

                    colliding = true;

                    if (PixelCollision(obj))
                    {
                        if (!Game1.CollidingObjects.Exists(x => x == obj))
                        {
                            Game1.CollidingObjects.Add(obj);
                            OnCollisionEnter(obj);
                        }
                    }
                    else if (Game1.CollidingObjects.Exists(x => x == obj))
                    {
                        Game1.CollidingObjects.Remove(obj);
                        OnCollisionExit(obj);
                    }
                }

                else
                {
                    colliding = false;
                }
            }
        }

        private bool PixelCollision(SpriteObject other)
        {
            int top = Math.Max(this.CollisionRect.Top, other.CollisionRect.Top);
            int bottom = Math.Min(this.CollisionRect.Bottom, other.CollisionRect.Bottom);
            int left = Math.Max(this.CollisionRect.Left, other.CollisionRect.Left);
            int right = Math.Min(this.CollisionRect.Right, other.CollisionRect.Right);

            for (int y = top; y < bottom; y++)
            {
                for (int x = left; x < right; x++)
                {
                    Color colorA = animations[animName].Colors[currentIndex]
                    [(x - CollisionRect.Left) + (y - CollisionRect.Top) * CollisionRect.Width];

                    Color colorB = other.animations[other.animName].Colors[other.currentIndex]
                    [(x - other.CollisionRect.Left) + (y - other.CollisionRect.Top) * other.CollisionRect.Width];

                    if(colorA.A != 0 && colorB.A != 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public abstract void OnCollisionEnter(SpriteObject other);


        public abstract void OnCollisionExit(SpriteObject other);


        public abstract void AnimationDone(string name);

    }
}
