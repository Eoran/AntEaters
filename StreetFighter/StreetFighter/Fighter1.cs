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
        public Fighter1(Vector2 position, int frames) : base(position, frames)
        {

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
                    
                }
            }

            //base.HandleInput(keyboard);
        }

        public override void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>(@"Ryu");

            CreateAnimation("IdleRight", 4, 9, 0, 33, 60, Vector2.Zero, 4, texture);

            CreateAnimation("CrouchRight", 1, 9, 23, 33, 60, Vector2.Zero, 1, texture);

            PlayAnimation("IdleRight");

            base.LoadContent(content);
        }
    }
}
