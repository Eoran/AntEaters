using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
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

        }

        public void Update(GameTime gametime)
        {
           
        }

        public void LoadContent(ContentManager content)
        {

        }
    }
}
