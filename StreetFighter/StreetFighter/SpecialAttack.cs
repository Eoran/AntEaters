using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetFighter
{
    class SpecialAttack : SpriteObject
    {
        private string direction;
        private Player player;
        DateTime cated = DateTime.Now;

        public DateTime Cated
        {
            get { return cated;  }
        }

        public string TmpData { get; set; }
        public SpecialAttack(string direction, Player player, Vector2 position, int frames) : base(position, frames)
        {
            speed = 50;
        }

        public override void Update(GameTime gameTime)
        {
            velocity = Vector2.Zero;
            velocity *= speed;
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Position += (velocity * deltaTime);

            if (direction == "right")
            {
                velocity += new Vector2(1, 0);
                PlayAnimation("FireBall");
            }

            else if (direction == "left")
            {
                velocity += new Vector2(-1, 0);
                PlayAnimation("FireBall");
            }

            base.Update(gameTime);
        }

        public override void LoadContent(ContentManager content)
        {
            //texture = content.Load<Texture2D>(@"");

            //SpecialAttack Animations
            texture = content.Load<Texture2D>(@"KenFireball");
            Texture2D textureFireBall = content.Load<Texture2D>(@"KenFireball");

            CreateAnimation("FireBall", 6, 0, 0, 49, 91, Vector2.Zero, 6, textureFireBall);
            base.LoadContent(content);
        }

        public override void OnCollisionEnter(SpriteObject other)
        {
            
        }

        public override void OnCollisionExit(SpriteObject other)
        {

        }

        public override void AnimationDone(string name)
        {

        }
    }
}
