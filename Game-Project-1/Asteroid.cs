using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace Game_Project_1
{
    /// <summary>
    /// A class representing an asteroid
    /// </summary>
    public class Asteroid
    {
        private Vector2 position;

        private Vector2 velocity;

        private GraphicsDevice graphics;

        private Texture2D texture;

        private BoundingCircle bounds;
        /// <summary>
        /// The bounding volume of the sprite
        /// </summary>
        public BoundingCircle Bounds => bounds;

        /// <summary>
        /// Creates a new asteroid sprite
        /// </summary>
        /// <param name="position">The position of the sprite in the game</param>
        public Asteroid(Vector2 position, Vector2 velocity, GraphicsDevice graphics)
        {
            this.position = position;
            this.velocity = velocity;
            this.graphics = graphics;
            this.bounds = new BoundingCircle(position - new Vector2(-60, -50), 50);
        }

        /// <summary>
        /// Loads the sprite texture using the provided ContentManager
        /// </summary>
        /// <param name="content">The ContentManager to load with</param>
        public void LoadContent(ContentManager content)
        {
            texture = content.Load<Texture2D>("sheet");
        }

        /// <summary>
        /// Updates the sprite's position based on random velocity
        /// </summary>
        /// <param name="gameTime">The game time</param>
        public void Update(GameTime gameTime)
        {
            position += (float)gameTime.ElapsedGameTime.TotalSeconds * velocity * 60;

            if (position.X > graphics.Viewport.Width || position.X < graphics.Viewport.X) velocity.X *= -1;
            if (position.Y > graphics.Viewport.Height || position.Y < graphics.Viewport.Y) velocity.Y *= -1;

            bounds.Center = new Vector2(position.X, position.Y);
        }

        /// <summary>
        /// Draws the sprite using the supplied SpriteBatch
        /// </summary>
        /// <param name="gameTime">The game time</param>
        /// <param name="spriteBatch">The SpriteBatch to render with</param>
        public void Draw(GameTime gameTime, SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(texture, position, new Rectangle(0, 516, 118, 102), Color.White, 0, new Vector2(60, 50), 1.0f, SpriteEffects.None, 0);
        }
    }
}
