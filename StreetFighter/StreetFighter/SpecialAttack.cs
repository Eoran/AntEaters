using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace StreetFighter
{
    class SpecialAttack : SpriteObject
    {
        bool reset;
        
        bool initDone;
        bool hit;
        
        private string direction;
        private Player player;
        DateTime cated = DateTime.Now;

        public DateTime Cated
        {
            get { return cated;  }
        }

        public string TmpData { get; set; }
        public SpecialAttack(string direction, Player player, Vector2 position, int frames) : base(position, frames)
        {
            reset = false;
            hit = false;
            initDone = false;
            this.player = player;
            this.LoadContent(Game1.myContent);
            this.direction = direction;
            speed = 100;

            //this.position = new Vector2(player.Position.X + player.Rectangles[player.CurrentIndex].Width, player.Position.Y);

            //PlayAnimation("FireBall");
        }

        public override void Update(GameTime gameTime)
        {
            if(reset)
            {
                this.position = new Vector2(player.Position.X + player.Rectangles[player.CurrentIndex].Width, player.Position.Y);
                PlayAnimation("FireBallStart");
                reset = false;
            }
            
            velocity = Vector2.Zero;

            if (direction == "right" && !hit)
            {
                velocity += new Vector2(1, 0);
                if(initDone)
                {
                    PlayAnimation("FireBallFlight");
                }
                //PlayAnimation("FireBall");
            }

            else if (direction == "left")
            {
                velocity += new Vector2(-1, 0);
                //PlayAnimation("FireBall");
            }

            else if (hit)
            {
                PlayAnimation("FireBallHit");
            }

            velocity *= speed;
            float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
            Position += (velocity * deltaTime);

            if(position.X + rectangles[currentIndex].Width >= 800)
            {
                reset = true;
                hit = false;
                SpecialAttackPool.ReleaseObjcet(this);
                Game1.ObjectsToRemove.Add(this);
            }

            //PlayAnimation("FireBall");

            base.Update(gameTime);
        }

        public override void LoadContent(ContentManager content)
        {
            //texture = content.Load<Texture2D>(@"");

            //SpecialAttack Animations
            texture = content.Load<Texture2D>(@"KenFireball_S");

            CreateAnimation("FireBallStart", 2, 0, 0, 38, 40, Vector2.Zero, 2, texture);
            CreateAnimation("FireBallFlight", 1, 0, 2, 38, 40, Vector2.Zero, 1, texture);
            CreateAnimation("FireBallHit", 3, 0, 3, 38, 40, Vector2.Zero, 3, texture);

            PlayAnimation("FireBallStart");

            base.LoadContent(content);
        }

        public override void OnCollisionEnter(SpriteObject other)
        {
            Player tempPlayer = other as Player;
            
            //if (tempPlayer != player)
            //{
            //    initDone = false;
            //    colliding = true;
            //}
            tempPlayer.Health -= 20;
            if (tempPlayer.Health <= 0)
            {
                player.Winner = true;
            }

            initDone = false;
            hit = true;

        }

        public override void OnCollisionExit(SpriteObject other)
        {

        }

        public override void AnimationDone(string name)
        {
            if(name == "FireBallStart")
            {
                initDone = true;
            }
            else if (name == "FireBallHit")
            {
                reset = true;
                hit = false;
                SpecialAttackPool.ReleaseObjcet(this);
                Game1.ObjectsToRemove.Add(this);
            }
        }
    }
}
