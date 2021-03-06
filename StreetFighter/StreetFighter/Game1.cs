﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace StreetFighter
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Game
    {
        bool newGame;
        
        KeyboardState keyBoard;
        bool restart;

        public static SpriteFont text;
        public static SpriteFont smallText;

        public static ContentManager myContent;
        
        //Singleton
        #region Singleton
        static Game1 instance;

        public static Game1 Instance
        {
            get
            {
                if(instance == null)
                {
                    instance = new Game1();
                }
                return instance;
            }
        }
        #endregion

        private Texture2D w1;
        private Texture2D w2;
        private string theWinner;
        
        private Texture2D healthText;
        private Texture2D dmgText;

        private Fighter1 f1;
        private Fighter2 f2;

        private Texture2D background;
        private const float delay = 90; //seconds
        private float remainingDelay = delay;

        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        private static List<SpriteObject> allObjects;
        private static List<SpriteObject> objectsToAdd;
        private static List<SpriteObject> objectsToRemove;
        private static List<SpriteObject> collidingObjects;

        public static List<SpriteObject> AllObjects
        {
            get { return allObjects; }
            set { allObjects = value; }
        }


        public static List<SpriteObject> ObjectsToAdd
        {
            get { return objectsToAdd; }
            set { objectsToAdd = value; }
        }


        public static List<SpriteObject> ObjectsToRemove
        {
            get { return objectsToRemove; }
            set { objectsToRemove = value; }
        }


        public static List<SpriteObject> CollidingObjects
        {
            get { return Game1.collidingObjects; }
            set { Game1.collidingObjects = value; }
        }

        private Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            allObjects = new List<SpriteObject>();
            collidingObjects = new List<SpriteObject>();
            objectsToAdd = new List<SpriteObject>();
            objectsToRemove = new List<SpriteObject>();

            newGame = true;

            restart = false;

            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            myContent = Content;

            //allObjects.Add(f1 = new Fighter1(new Vector2(100, 350), 4));

            //allObjects.Add(f2 = new Fighter2(new Vector2(700, 350), 4));

            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            text = Content.Load<SpriteFont>(@"newFont");
            smallText = Content.Load<SpriteFont>(@"smallFont");

            background = Content.Load<Texture2D>("background");

            // TODO: use this.Content to load your game content here
            healthText = Content.Load<Texture2D>(@"Health");
            dmgText = Content.Load<Texture2D>(@"Dmg");

            w1 = Content.Load<Texture2D>(@"F1Won");
            w2 = Content.Load<Texture2D>(@"F2Won");

            foreach(SpriteObject obj in allObjects)
            {
                obj.LoadContent(Content);
            }
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            var timer = (float)gameTime.ElapsedGameTime.TotalSeconds;
            remainingDelay -= timer;

            // TODO: Add your update logic here

            keyBoard = Keyboard.GetState();

            if(keyBoard.IsKeyDown(Keys.N) && newGame)
            {
                newGame = false;

                allObjects.Add(f1 = new Fighter1(new Vector2(100, 350), 4));

                allObjects.Add(f2 = new Fighter2(new Vector2(700, 350), 4));
            }

            if (keyBoard.IsKeyDown(Keys.R) && restart)
            {
                restart = false;
                theWinner = "";
                objectsToAdd.Add(f1 = new Fighter1(new Vector2(100, 350), 4));
                objectsToAdd.Add(f2 = new Fighter2(new Vector2(700, 350), 4));

            }

            foreach (SpriteObject dead in objectsToRemove)
            {
                allObjects.Remove(dead);
            }

            allObjects.AddRange(objectsToAdd);

            objectsToAdd.Clear();
            objectsToRemove.Clear();

            foreach (SpriteObject obj in allObjects)
            {
                obj.Update(gameTime);
            }

            if (!newGame)
            {
                if (f1.Winner || f2.Winner)
                {
                    if (f1.Winner)
                    {
                        theWinner = "f1";
                        allObjects.Clear();
                    }
                    else if (f2.Winner)
                    {
                        theWinner = "f2";
                        allObjects.Clear();
                    }
                }
            }

            if (remainingDelay <= 0)
            {
                //Dislay winner with most health left. Can be a method we call from somewhere ells.
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // TODO: Add your drawing code here
            spriteBatch.Begin();

            spriteBatch.Draw(background, new Rectangle(0, 0, 800, 480), Color.White);

            //Display start menu
            if(newGame)
            {
                spriteBatch.DrawString(text, "Press N to start game!", new Vector2(Window.ClientBounds.Width / 2 - text.MeasureString("Press N to start game!").X / 2, 50), Color.Magenta);

                //Instructions for fighter1
                spriteBatch.DrawString(smallText, "Controls for fighter1", new Vector2(50, 150), Color.Blue);
                spriteBatch.DrawString(smallText, "Use A and D for movement and S for Crouching", new Vector2(50, 175), Color.Blue);
                spriteBatch.DrawString(smallText, "Press F for punch and G for kick", new Vector2(50, 200), Color.Blue);
                spriteBatch.DrawString(smallText, "Press Q for specialattack", new Vector2(50, 225), Color.Blue);

                //Instructions for fighter2
                spriteBatch.DrawString(smallText, "Controls for fighter2", new Vector2(Window.ClientBounds.Width - smallText.MeasureString("Controls for fighter2").X - 50, 150), Color.Red);
                spriteBatch.DrawString(smallText, "Use arrowkey left and arrowkey right for movement", new Vector2(Window.ClientBounds.Width - smallText.MeasureString("Use arrowkey left and arrowkey right for movement").X - 50, 175), Color.Red);
                spriteBatch.DrawString(smallText, "Use arrowkey down for Crouching", new Vector2(Window.ClientBounds.Width - smallText.MeasureString("Use arrowkey down for Crouching").X - 50, 200), Color.Red);
                spriteBatch.DrawString(smallText, "Press L for punch and K for kick", new Vector2(Window.ClientBounds.Width - smallText.MeasureString("Press L for punch and K for kick").X - 50, 225), Color.Red);
            }

            //Display winner
            if(theWinner == "f1")
            {
                //spriteBatch.Draw(w1, new Rectangle(120, 80, 600, 40), Color.White);
                spriteBatch.DrawString(text, "Fighter 1 has won!", new Vector2(Window.ClientBounds.Width / 2 - text.MeasureString("Fighter 1 has won!").X / 2, 100), Color.Magenta);
                spriteBatch.DrawString(text, "Press R to restart!", new Vector2(Window.ClientBounds.Width / 2 - text.MeasureString("Press R to restart!").X / 2, 200), Color.Magenta);
                restart = true;
            }
            else if(theWinner == "f2")
            {
                spriteBatch.DrawString(text, "Fighter 2 has won!", new Vector2(Window.ClientBounds.Width / 2 - text.MeasureString("Fighter 2 has won!").X / 2, 100), Color.Magenta);
                spriteBatch.DrawString(text, "Press R to restart!", new Vector2(Window.ClientBounds.Width / 2 - text.MeasureString("Press R to restart!").X / 2, 200), Color.Magenta);
                restart = true;
                //spriteBatch.Draw(w2, new Rectangle(120, 80, 600, 40), Color.White);
            }

//#if DEBUG
//            spriteBatch.DrawString(text, "time: " + f1.Delay.ElapsedMilliseconds.ToString(), new Vector2(100, 100), Color.Magenta);
//#endif
            //Health bar
            if (!newGame)
            {
                spriteBatch.Draw(healthText, new Rectangle(10, 10, f1.Health * 3, 30), Color.White);
                spriteBatch.Draw(dmgText, new Rectangle(310 - (300 - (f1.Health * 3)), 10, 300 - (f1.Health * 3), 30), Color.White);

                spriteBatch.Draw(healthText, new Rectangle(490 + ((100 - f2.Health) * 3), 10, f2.Health * 3, 30), Color.White);
                spriteBatch.Draw(dmgText, new Rectangle(490, 10, 300 - (f2.Health * 3), 30), Color.White);
            }

            foreach (SpriteObject obj in allObjects)
            {
                obj.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
