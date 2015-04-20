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
            }

            else if (direction == "left")
            {
                velocity += new Vector2(-1, 0);
            }

            base.Update(gameTime);
        }

        public override void LoadContent(ContentManager content)
        {
            //texture = content.Load<Texture2D>(@"");

            //SpecialAttack Animations

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
            texture = content.Load<Texture2D>(@"");

            //SpecialAttack Animations

            base.LoadContent(content);
        }
    }
}
