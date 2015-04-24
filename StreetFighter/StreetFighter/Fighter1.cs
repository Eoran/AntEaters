using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace StreetFighter
{
    class Fighter1 : Player
    {
        Stopwatch delay;

        public Stopwatch Delay
        {
            get { return delay; }
        }
        
        List<SpecialAttack> specAttack = new List<SpecialAttack>();

        public Fighter1(Vector2 position, int frames)
            : base(position, frames)
        {
            delay = new Stopwatch();
            attacking = false;
            this.Winner = false;
        }

        public override void Update(GameTime gameTime)
        {
            //PlayAnimation("IdleRight");

            velocity = Vector2.Zero;

            HandleInput(Keyboard.GetState());

            velocity *= speed;

            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

            Position += (velocity * deltaTime);

            base.Update(gameTime);
        }

        public override void HandleInput(KeyboardState keyboard)
        {
            if (!attacking)
            {
                if (keyboard.IsKeyDown(Keys.S))
                {
                    PlayAnimation("CrouchRight");
                    Crouched = true;
                }
                else if (keyboard.IsKeyDown(Keys.F))
                {
                    PlayAnimation("LPunch");
                    curAtk = "LPunch";
                    attacking = true;
                }
                else if (keyboard.IsKeyDown(Keys.G))
                {
                    PlayAnimation("LKick");
                    curAtk = "LKick";
                    attacking = true;
                }
                else if (keyboard.IsKeyDown(Keys.A) && position.X > 0)
                {
                    //Left
                    PlayAnimation("Walk");
                    velocity += new Vector2 (-1,0);
                }
                else if (keyboard.IsKeyDown(Keys.D) && position.X < 800 - Rectangles[CurrentIndex].Width && !colliding)
                {
                    PlayAnimation("Walk");
                    velocity += new Vector2(1, 0);
                }
                else if (keyboard.IsKeyDown(Keys.Q) && delay.ElapsedMilliseconds == 0)
                {
                    delay.Start();
                    Game1.ObjectsToAdd.Add(SpecialAttackPool.Create("right", this, new Vector2(position.X + this.Rectangles[CurrentIndex].Width, position.Y), 2));
                }
                else
                {
                    PlayAnimation("IdleRight");
                    Crouched = false;
                }
            }

            if (delay.ElapsedMilliseconds >= 5000)
            {
                delay.Reset();
            }

            //base.HandleInput(keyboard);
        }

        public override void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>(@"idle");

            CreateAnimation("IdleRight", 4, 0, 0, 50, 93, new Vector2(0, -3), 4, texture);

            Texture2D textureCrouch = content.Load<Texture2D>(@"Crouch");

            CreateAnimation("CrouchRight", 1, 0, 1, 49, 91, new Vector2(0, -1), 1, textureCrouch);

            Texture2D textureLPunch = content.Load<Texture2D>(@"L.punch_S");

            CreateAnimation("LPunch", 3, 0, 0, 61, 94, new Vector2(0, -4), 3, textureLPunch);

            Texture2D textureWalk = content.Load<Texture2D>(@"walking");

            CreateAnimation("Walk", 5, 0, 0, 48, 90, Vector2.Zero, 5 ,textureWalk);

            Texture2D textureLKick = content.Load<Texture2D>(@"fowardL.kick_S.png");

            CreateAnimation("LKick", 3, 0, 0, 77, 103, new Vector2(0, -13), 3, textureLKick);

            PlayAnimation("IdleRight");

            base.LoadContent(content);
        }

        public override void OnCollisionEnter(SpriteObject other)
        {
            Fighter2 tempFighter = other as Fighter2;

            if (attacking)
            {
                if (curAtk == "LPunch")
                {
                    if (!tempFighter.Crouched)
                    {
                        tempFighter.Health -= 10;
                        if(tempFighter.Health <= 0)
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
            if(name == "LPunch" || name == "LKick")
            {
                attacking = false;
            }
        }
    }
}
