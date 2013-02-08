using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace PlanetCute_ida
{
    class Tile
    {
        Texture2D sprite;
        int offsetX;

        public int offset { get { return offsetX; } }

        public Tile(ContentManager Content, String name, int offset)
        {
            this.sprite = Content.Load<Texture2D>(name);
            this.offsetX = offset;
        }

        public Tile(Texture2D sprite, int offset)
        {
            this.sprite = sprite;
            this.offsetX = offset;
        }

        public void Draw(SpriteBatch spriteBatch, int x, int y)
        {
            spriteBatch.Draw(   sprite,
                                new Vector2(
                                            sprite.Width * x,
                                            sprite.Height * y / 2 + this.offsetX
                                            ),
                                Color.White);
        }

        public Texture2D getSprite()
        {
            return this.sprite;
        }
    }
}
