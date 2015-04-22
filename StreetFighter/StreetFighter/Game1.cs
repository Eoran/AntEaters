using Microsoft.Xna.Framework;
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

        public Game1()
            : base()
        {
            graphics = new GraphicsDeviceManager(this);
            allObjects = new List<SpriteObject>();
            collidingObjects = new List<SpriteObject>();


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
            allObjects.Add(f1 = new Fighter1(new Vector2(100, 350), 4));

            allObjects.Add(f2 = new Fighter2(new Vector2(700, 350), 4));

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

            background = Content.Load<Texture2D>("background");

            // TODO: use this.Content to load your game content here
            healthText = Content.Load<Texture2D>(@"Health");
            dmgText = Content.Load<Texture2D>(@"Dmg");



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
            foreach (SpriteObject obj in allObjects)
            {
                obj.Update(gameTime);
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

            //Health bar
            spriteBatch.Draw(healthText, new Rectangle(10, 10, f1.Health * 3, 30), Color.White);


            foreach (SpriteObject obj in allObjects)
            {
                obj.Draw(spriteBatch);
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
