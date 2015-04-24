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
            attacking = false;
            this.Winner = false;
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

            CreateAnimation("KenIdleRight", 4, 0, 0, 50, 91, new Vector2(0, -1), 4, texture);

            Texture2D textureCrouch = content.Load<Texture2D>(@"KenCrouch");

            CreateAnimation("kenCrouchRight", 1, 0, 1, 46, 90, Vector2.Zero, 1, textureCrouch);

            Texture2D textureLPunch = content.Load<Texture2D>(@"KenfowardL.Punch_S");

            CreateAnimation("KenLPunch", 3, 0, 0, 61, 93, new Vector2(-11, -3), 3, textureLPunch);

            Texture2D textureWalk = content.Load<Texture2D>(@"Kenwalking");

            CreateAnimation("KenWalk", 5, 0, 0, 48, 93, new Vector2(0, -3), 5, textureWalk);

            Texture2D textureLKick = content.Load<Texture2D>(@"KenforwardL.Kick_S");

            CreateAnimation("KenLKick", 3, 0, 0, 77, 106, new Vector2(-27, -16), 3, textureLKick);

            PlayAnimation("KenIdleRight");

            base.LoadContent(content);
        }

        public override void HandleInput(KeyboardState keyboard)
        {
            if (!attacking)
            {
                
                if (keyboard.IsKeyDown(Keys.Down))
                {
                    PlayAnimation("kenCrouchRight");
                    Crouched = true;
                }
                else if (keyboard.IsKeyDown(Keys.L))
                {
                    PlayAnimation("KenLPunch");
                    curAtk = "LPunch";
                    attacking = true;
                }
                else if (keyboard.IsKeyDown(Keys.K))
                {
                    PlayAnimation("KenLKick");
                    curAtk = "LKick";
                    attacking = true;
                }
                else if (keyboard.IsKeyDown(Keys.Left) && position.X > 0 && !colliding)
                {
                    //Left
                    PlayAnimation("KenWalk");
                    velocity += new Vector2(-1, 0);
                }
                else if (keyboard.IsKeyDown(Keys.Right) && position.X < 800 - Rectangles[CurrentIndex].Width)
                {
                    PlayAnimation("KenWalk");
                    velocity += new Vector2(1, 0);
                }
                else
                {
                    PlayAnimation("KenIdleRight");
                    Crouched = false;
                }
            }
        }

        public override void OnCollisionEnter(SpriteObject other)
        {
            Fighter1 tempFighter = other as Fighter1;

            if (attacking)
            {
                if (curAtk == "LPunch")
                {
                    if (!tempFighter.Crouched)
                    {
                        tempFighter.Health -= 10;
                        if (tempFighter.Health <= 0)
                        {
                            this.Winner = true;
                        }
                    }
                }
                else if (curAtk == "LKick")
                {
                    if (tempFighter.Crouched)
                    {
                        tempFighter.Health -= 10;
                        if (tempFighter.Health <= 0)
                        {
                            this.Winner = true;
                        }
                    }
                    else if (!tempFighter.Crouched)
                    {
                        tempFighter.Health -= 5;
                        if (tempFighter.Health <= 0)
                        {
                            this.Winner = true;
                        }
                    }
                }
            }
        }

        public override void AnimationDone(string name)
        {
            if (name == "KenLPunch" || name == "KenLKick")
            {
                attacking = false;
            }
        }
    }


}
