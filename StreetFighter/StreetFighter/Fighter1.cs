using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace StreetFighter
{
    class Fighter1 : Player
    {
        public Fighter1(Vector2 position, int frames) : base(position, frames)
        {

        }

        public override void HandleInput(KeyboardState keyState)
        {
            if (!attacking)
            {
                if (keyState.IsKeyDown(Keys.D))
                {
                    //move right
                    lastDir = "Right";
                    velocity += new Vector2(1, 0);
                }
                if (keyState.IsKeyDown(Keys.A))
                {
                    //move left
                    lastDir = "Left";
                    velocity += new Vector2(-1, 0);
                }
                if (keyState.IsKeyDown(Keys.W))
                {
                    //Jump
                    //ikke helt sikker på hvad vi gør her.
                    lastDir = "Jump";
                    velocity += new Vector2();
                }
                if (keyState.IsKeyDown(Keys.S))
                {
                    //crouch
                    //ikke helt sikker på hvad vi gør her.
                    lastDir = "Crouch";
                    velocity += new Vector2();
                }
                if (attacking)
                {
                    if (keyState.IsKeyDown(Keys.Q))
                    {
                        //punch medium
                    }
                    if (keyState.IsKeyDown(Keys.E))
                    {
                        //punch ligth
                    }
                    if (keyState.IsKeyDown(Keys.R))
                    {
                        //punch Hard
                    }
                    if (keyState.IsKeyDown(Keys.Z))
                    {
                        //Kick medium
                    }
                    if (keyState.IsKeyDown(Keys.X))
                    {
                        //Kick Hard
                    }
                    if (keyState.IsKeyDown(Keys.R))
                    {
                        //Kick Light
                    }
                }
            }
        }

        public void Update(GameTime gameTime)
        {

        }

        public void LoadContent(ContentManager content)
        {

        }
    }
}
