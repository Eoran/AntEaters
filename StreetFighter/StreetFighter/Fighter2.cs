using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetFighter
{
    class Fighter2 : Player
    {
        public Fighter2(Vector2 position, int frames) : base(position, frames)
        {
            this.effect = SpriteEffects.FlipHorizontally;
        }

        public override void Update(GameTime gameTime)
        {
            velocity = Vector2.Zero;

            HandleInput(Keyboard.GetState());

            velocity *= speed;

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Position += (velocity * deltaTime);

            base.Update(gameTime);
        }

        public override void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>(@"KenIdle");

            CreateAnimation("KenIdleRight", 4, 0, 0, 50, 91, Vector2.Zero, 4, texture);

            //Texture2D textureCrouch = content.Load<Texture2D>(@"KenCrouch");

            //CreateAnimation("kenCrouchRight", 1, 0, 1, 49, 91, Vector2.Zero, 1, textureCrouch);

            //Texture2D textureLPunch = content.Load<Texture2D>(@"KenforwardL.Punch");

            //CreateAnimation("KenLPunch", 3, 0, 0, 61, 94, Vector2.Zero, 3, textureLPunch);

            //Texture2D textureWalk = content.Load<Texture2D>(@"Kenwalking");

            //CreateAnimation("KenWalk", 5, 0, 0, 48, 90, Vector2.Zero, 5, textureWalk);

            PlayAnimation("KenIdleRight");

            base.LoadContent(content);
        }

        public override void HandleInput(KeyboardState keyboard)
        {
            if (!attacking)
            {
                if (keyboard.IsKeyDown(Keys.Down))
                {
                    PlayAnimation("KenCrouchLeft");
                }
                else if (keyboard.IsKeyDown(Keys.L))
                {
                    PlayAnimation("KenLPunch");

                    attacking = true;

                }
                else if (keyboard.IsKeyDown(Keys.Left) && position.X > 0)
                {
                    //Left
                    PlayAnimation("KenWalk");
                    velocity += new Vector2(-1, 0);
                }
                else if (keyboard.IsKeyDown(Keys.Right) && position.X < 800 - rectangles[currentIndex].Width)
                {
                    PlayAnimation("KenWalk");
                    velocity += new Vector2(1, 0);
                }
                else
                {
                    PlayAnimation("KenIdleRight");
                }
            }
        }

        public override void OnCollisionEnter(SpriteObject other)
        {
            if (other.AnimName == "LPunch")
            {
                health -= 10;
            }
        }

        public override void AnimationDone(string name)
        {
            if (name == "KenLPunch")
            {
                attacking = false;
            }
        }
    }


}
