using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PlanetCute_ida
{
    class Character
    {
        private Tile type;
        
        public int speed {get; set;}
        public int x { get; set; }
        public int y { get; set; }

        public Character(Tile[] sprites)
        {
            Random r = new Random();
            type = sprites[r.Next(sprites.Length)];
        }

        public Rectangle GetCollitionBox()
        {
            return new Rectangle(x, y, type.getSprite().Width, type.getSprite().Width);
        }

        public void Update()
        {
            this.x += speed;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(   type.getSprite(),
                                new Vector2(x,y),
                                Color.White
                            );
        }
    }
}
