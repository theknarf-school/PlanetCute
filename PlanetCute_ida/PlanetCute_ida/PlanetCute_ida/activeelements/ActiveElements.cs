using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PlanetCute_ida
{
    /// <summary>
    /// An base class used for a lot of the elements in the game to make it easier for them
    /// </summary>
    abstract class ActiveElements : Clickable, GameObject
    {
        // The picture that are to be drawn
        public Tile type;

        // The x and y position of to draw on
        public int x;
        public int y;

        // How many life the object have
        public int life = 1;

        // The size to draw the object in, 1f is the size of the Tile (0.5f is halv the size, etc)
        public float size = 1f;

        // Rotation of the Tile, and a center of rotation vector
        public float rotate = 0f;
        public Vector2 rotateVec = Vector2.Zero;

        public bool moveBasedOnSize = true;
        
        /// <summary>
        /// Construct a new ActiveElement with a give Tile
        /// </summary>
        /// <param name="type">The Tile to construct the ActiveElement with</param>
        public ActiveElements(Tile type) 
        {
            this.type = type;
        }

        /// <summary>
        /// An empty Update method, to be extended by subclasses if wanted to
        /// </summary>
        /// <param name="gameTime"></param>
        public virtual void Update(GameTime gameTime)
        {
        }

        /// <summary>
        /// A basic Draw method to draw the Tile sprite depending on some variables
        /// </summary>
        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            // The x are calculated depending on these options
            //   - The actual x position saved in this.x
            //   - if moveBasedOnSize is on then it compensates for the movment happening when you resize the object
            //   - If you have another center of rotation than Vector.zero the x compensates for it

            // The same goes for y, just that the offset from the Tile is also added on

            spriteBatch.Draw(   
                                type.getSprite(),
                                new Vector2(
                                            x + ((1 - size) * type.getSprite().Width) / 2 * (moveBasedOnSize?1:0) + rotateVec.X/2,
                                            y + type.offset + ((1 - size) * type.getSprite().Height) / 2 * (moveBasedOnSize?1:0) + rotateVec.Y/2
                                            ),
                                null, Color.White, rotate, rotateVec, size, SpriteEffects.None, 0
                            );
        }

        /// <summary>
        /// A method for getting a collition box for the object
        /// </summary>
        /// <returns>Returns a collition box</returns>
        public Rectangle GetCollitionBox()
        {
            return new Rectangle(x,
                                 y + type.getSprite().Height / 2,
                                 type.getSprite().Width,
                                 type.getSprite().Width);
        }

        /// <summary>
        /// A method for loosing life, negative life is allowed and are used in practice
        /// </summary>
        public virtual void looseLife()
        {
            this.life--;
        }
        
        /// <summary>
        /// The clickmethod from Clickable, to be extended if the subclass wants to
        /// </summary>
        /// <param name="mouse"></param>
        public virtual void Click(Rectangle mouse)
        {
        }
    }
}
