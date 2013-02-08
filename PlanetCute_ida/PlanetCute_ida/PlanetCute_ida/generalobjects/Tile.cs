using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace PlanetCute_ida
{
    /// <summary>
    /// A Tile, an wrapper around some graphics with a draw method
    /// </summary>
    class Tile
    {
        Texture2D sprite;
        int offsetX;

        public int offset { get { return offsetX; } }

        /// <summary>
        /// Initialize using a ContentManager and a filename
        /// </summary>
        /// <param name="Content"></param>
        /// <param name="name"></param>
        /// <param name="offset"></param>
        public Tile(ContentManager Content, String name, int offset)
        {
            this.sprite = Content.Load<Texture2D>(name);
            this.offsetX = offset;
        }

        /// <summary>
        /// Initialize using a sprite
        /// </summary>
        /// <param name="sprite"></param>
        /// <param name="offset"></param>
        public Tile(Texture2D sprite, int offset)
        {
            this.sprite = sprite;
            this.offsetX = offset;
        }

        /// <summary>
        /// Draws the sprite
        /// </summary>
        /// <param name="spriteBatch">something to draw with</param>
        /// <param name="x">the x position to draw</param>
        /// <param name="y">the y position to draw</param>
        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            spriteBatch.Draw(   sprite,
                                new Vector2(
                                            sprite.Width * x,
                                            sprite.Height * y / 2 + this.offsetX
                                            ),
                                Color.White);
        }

        /// <summary>
        /// Returns the sprite
        /// </summary>
        /// <returns>The sprite</returns>
        public Texture2D getSprite()
        {
            return this.sprite;
        }
    }
}
