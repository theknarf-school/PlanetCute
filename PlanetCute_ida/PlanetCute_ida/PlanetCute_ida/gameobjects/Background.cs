using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;

namespace PlanetCute_ida
{
    /// <summary>
    /// The Background class draws the background based on a map
    /// </summary>
    class Background : GameObject
    {
        // The Tile files for all the graphics used
        Tile[] tSprites = new Tile[15];

        // The map used to draw the background
        Map mMap;

        /// <summary>
        /// Initialize the Background with a map
        /// </summary>
        /// <param name="Content">An argument used to load in graphics</param>
        /// <param name="map">The map used to draw graphics</param>
        public Background(ContentManager Content, Map map)
        {
            // Loading in sprites
            this.tSprites[0]  = new Tile(Content, @"images/Roof North West",    0);
            this.tSprites[1]  = new Tile(Content, @"images/Roof North",         0);
            this.tSprites[2]  = new Tile(Content, @"images/Roof North East",    0);
            this.tSprites[3]  = new Tile(Content, @"images/Roof West",          0);
            this.tSprites[4]  = new Tile(Content, @"images/Brown Block",        0);
            this.tSprites[5]  = new Tile(Content, @"images/Roof East",          0);
            this.tSprites[6]  = new Tile(Content, @"images/Roof South West",    0);
            this.tSprites[7]  = new Tile(Content, @"images/Roof South",         0);
            this.tSprites[8]  = new Tile(Content, @"images/Window Tall",        0);
            this.tSprites[9]  = new Tile(Content, @"images/Roof South East",    0);
            this.tSprites[10] = new Tile(Content, @"images/Wall Block Tall",    0);
            this.tSprites[11] = new Tile(Content, @"images/Door Tall Closed",   20);
            this.tSprites[12] = new Tile(Content, @"images/Stone Block",        20);
            this.tSprites[13] = new Tile(Content, @"images/Roof North",         -40);
            this.tSprites[14] = new Tile(Content, @"images/Grass Block",        50);

            this.mMap = map;
        }
        
        /// <summary>
        /// Used to get the drawing order of Tiles correct
        /// </summary>
        /// <param name="y">The y from the for loop</param>
        /// <returns>The correct horizontal drawing order</returns>
        public int transformY(int y)
        {
            int[] arr = { 4, 3, 0, 1, 2 };
            if (y >= arr.Length)
            {
                return y;
            }
            else return arr[y];
        }

        public void Update(GameTime gameTime)
        {
        }

        /// <summary>
        /// Draws all the background Tiles
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="gameTime"></param>
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            for (int x = 0; x < this.mMap.width; x++)
            {
                for (int y = 0; y < this.mMap.height; y++)
                {
                    Tile sprite = this.tSprites[this.mMap.getTileID(x, transformY(y))];

                    // Drawing each tile
                    sprite.Draw(spriteBatch, x, transformY(y));
                }
            }
        }
    }
}
