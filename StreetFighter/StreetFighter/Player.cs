using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace StreetFighter
{
    class Player : SpriteObject
    {
        protected int health;
        protected bool isAlive;
        protected int kOCount;
        private string lastDir;
        private bool attacking;

        public void HandleInput(KeyboardState keyboard)
        {

        }

        public Player(Vector2 position, int frames) : base (position, frames)
        {

        }
    }
}
