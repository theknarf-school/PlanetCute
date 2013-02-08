using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PlanetCute_ida
{
    class Character : ActiveElements
    {
        public int speed {get; set;}

        public Character(Tile type) : base(type) { }

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
