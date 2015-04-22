using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework;

namespace StreetFighter
{
    abstract class Player : SpriteObject
    {
        private int health;

        public int Health
        {
            get { return health; }
            set { health = value; }
        }

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

        public abstract void HandleInput(KeyboardState keyboard);

        public override void OnCollisionEnter(SpriteObject other)
        {
            
        }

        public override void OnCollisionExit(SpriteObject other)
        {
            
        }

        public override void AnimationDone(string name)
        {
            
        }
    }
}
