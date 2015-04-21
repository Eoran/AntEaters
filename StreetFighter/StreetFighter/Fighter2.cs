using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
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
            this.effect = SpriteEffects.FlipVertically;
        }

        public override void Update(GameTime gameTime)
        {

        }

        public override void LoadContent(ContentManager content)
        {

        }

        public override void HandleInput(Microsoft.Xna.Framework.Input.KeyboardState keyboard)
        {
            
        }
    }
}
