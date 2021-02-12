using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Game_Project_1
{
    public class GameProject1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private Asteroid[] asteroids;
        private SpaceShip spaceShip;

        private SpriteFont bangers;
        private SpriteFont sBangers;

        //private Texture2D ball;

        /// <summary>
        /// A game accomplishing the requirements of Game Project 1
        /// </summary>
        public GameProject1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
        }

        /// <summary>
        /// Initializes the game
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here
            System.Random rand = new System.Random();
            asteroids = new Asteroid[]
            {
                new Asteroid(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height), new Vector2((float)rand.NextDouble(), (float)rand.NextDouble()), GraphicsDevice),
                new Asteroid(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height), new Vector2((float)rand.NextDouble(), (float)rand.NextDouble()), GraphicsDevice),
                new Asteroid(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height), new Vector2((float)rand.NextDouble(), (float)rand.NextDouble()), GraphicsDevice),
                new Asteroid(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height), new Vector2((float)rand.NextDouble(), (float)rand.NextDouble()), GraphicsDevice),
                new Asteroid(new Vector2((float)rand.NextDouble() * GraphicsDevice.Viewport.Width, (float)rand.NextDouble() * GraphicsDevice.Viewport.Height), new Vector2((float)rand.NextDouble(), (float)rand.NextDouble()), GraphicsDevice),
            };
            spaceShip = new SpaceShip();

            base.Initialize();
        }

        /// <summary>
        /// Loads content for the game
        /// </summary>
        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here
            foreach (var asteroid in asteroids) asteroid.LoadContent(Content);
            spaceShip.LoadContent(Content);
            //ball = Content.Load<Texture2D>("ball");
            bangers = Content.Load<SpriteFont>("bangers");
            sBangers = Content.Load<SpriteFont>("smallerbangers");
        }

        /// <summary>
        /// Updates the game world
        /// </summary>
        /// <param name="gameTime">The game time</param>
        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            spaceShip.Update(gameTime);

            // Detect and process collisions
            foreach(var asteroid in asteroids)
            {
                asteroid.Update(gameTime);
                if (asteroid.Bounds.CollidesWith(spaceShip.Bounds)) Exit();
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// Draws the game world
        /// </summary>
        /// <param name="gameTime">The game time</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.DarkBlue);

            // TODO: Add your drawing code here
            _spriteBatch.Begin();

            // Draws each asteroid
            foreach (var asteroid in asteroids)
            {
                asteroid.Draw(gameTime, _spriteBatch);
                /*
                // Creates a visual representation of the asteroid hitbox
                var rect = new Rectangle((int)(asteroid.Bounds.Center.X - asteroid.Bounds.Radius), (int)(asteroid.Bounds.Center.Y - asteroid.Bounds.Radius), (int)(2*asteroid.Bounds.Radius), (int)(2*asteroid.Bounds.Radius));
                _spriteBatch.Draw(ball, rect, Color.White);
                */
            }

            /*
            // Creates a visual representation of the spaceship hitbox (but isn't working right now)
            var rectS = new Rectangle((int)(spaceShip.Bounds.Center.X - spaceShip.Bounds.Radius), (int)(spaceShip.Bounds.Center.Y - spaceShip.Bounds.Radius), (int)(2*spaceShip.Bounds.Radius), (int)(2*spaceShip.Bounds.Radius));
            */

            // Draws the spaceship
            spaceShip.Draw(gameTime, _spriteBatch);

            /*
            // Draws the ball representing the spaceship hitbox
            _spriteBatch.Draw(ball, rectS, Color.White);
            */

            // Draws the text
            _spriteBatch.DrawString(bangers, "Avoid the Asteroids!!!", new Vector2(0, 0), Color.White);
            _spriteBatch.DrawString(bangers, $"{gameTime.TotalGameTime:c}", new Vector2(0, 50), Color.White);
            _spriteBatch.DrawString(sBangers, "(or hit the Asteroids if you want the game to end)", new Vector2(0, 100), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
