using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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

        }

        public override void HandleInput(KeyboardState keyState)
        {
            if (!attacking)
            {
                if (keyState.IsKeyDown(Keys.Right))
                {
                    //move right
                    lastDir = "Right";
                    velocity += new Vector2(1, 0);
                }
                if (keyState.IsKeyDown(Keys.Left))
                {
                    //move left
                    lastDir = "Left";
                    velocity += new Vector2(-1, 0);
                }
                if (keyState.IsKeyDown(Keys.Up))
                {
                    //Jump
                    //ikke helt sikker på hvad vi gør her.
                    lastDir = "Jump";
                    velocity += new Vector2();
                }
                if (keyState.IsKeyDown(Keys.Down))
                {
                    //crouch
                    //ikke helt sikker på hvad vi gør her.
                    lastDir = "Crouch";
                    velocity += new Vector2();
                }
                if (attacking)
                {
                    if (keyState.IsKeyDown(Keys.U))
                    {
                        //punch medium
                    }
                    if (keyState.IsKeyDown(Keys.I))
                    {
                        //punch ligth
                    }
                    if (keyState.IsKeyDown(Keys.O))
                    {
                        //punch Hard
                    }
                    if (keyState.IsKeyDown(Keys.J))
                    {
                        //Kick medium
                    }
                    if (keyState.IsKeyDown(Keys.K))
                    {
                        //Kick Hard
                    }
                    if (keyState.IsKeyDown(Keys.L))
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
