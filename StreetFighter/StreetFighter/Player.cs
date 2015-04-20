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
        public string lastDir;
        public bool attacking;

        public Player(Vector2 position, int frames)
            : base(position, frames)
        {
            this.speed = 100;
            health = 100;
            attacking = false;
            isAlive = true;
            kOCount = 0;
        }

        public abstract void HandleInput(KeyboardState keyboard)
        {

        }
    }
}
