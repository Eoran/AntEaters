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
    class Fighter1 : Player
    {
        List<SpecialAttack> specAttack = new List<SpecialAttack>();

        public Fighter1(Vector2 position, int frames)
            : base(position, frames)
        {
            attacking = false;
        }

        public override void Update(GameTime gameTime)
        {
            //PlayAnimation("IdleRight");

            HandleInput(Keyboard.GetState());

            base.Update(gameTime);
        }

        public override void HandleInput(KeyboardState keyboard)
        {
            if (!attacking)
            {
                if (keyboard.IsKeyDown(Keys.S))
                {
                    PlayAnimation("CrouchRight");
                }
                else if(keyboard.IsKeyDown(Keys.F))
                {
                    PlayAnimation("LPunch");
                    
                    attacking = true;

                }
                else
                {
                    PlayAnimation("IdleRight");
                }                

                if (keyboard.IsKeyDown(Keys.W))
                {
                    //Jump
                    PlayAnimation("");
                }
                if (keyboard.IsKeyDown(Keys.A))
                {
                    //Left
                    PlayAnimation("");
                    velocity += new Vector2 (-1,0);
                }
                if (keyboard.IsKeyDown(Keys.D))
                {
                    PlayAnimation("");
                    velocity += new Vector2(1, 0);
                }
            }

            if (attacking)
            {
                if (keyboard.IsKeyDown(Keys.Q))
                {
                    PlayAnimation("FireBall");
                    specAttack.Add(SpecialAttackPool.Create(lastDir, this, new Vector2(position.X + rectangles[currentIndex].Width, position.Y - rectangles[currentIndex].Height / 2), 2));
                }
            }

            //base.HandleInput(keyboard);
        }

        public override void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>(@"idle");

            CreateAnimation("IdleRight", 4, 0, 0, 50, 93, Vector2.Zero, 4, texture);

            Texture2D textureCrouch = content.Load<Texture2D>(@"Crouch");

            CreateAnimation("CrouchRight", 1, 0, 1, 49, 91, Vector2.Zero, 1, textureCrouch);

            Texture2D textureLPunch = content.Load<Texture2D>(@"L.punch_S");

            CreateAnimation("LPunch", 3, 0, 0, 61, 94, Vector2.Zero, 3, textureLPunch);

            base.LoadContent(content);
        }

        public override void AnimationDone(string name)
        {
            if (name == "LPunch")
            {
                attacking = false;
            }
        }
    }
}
