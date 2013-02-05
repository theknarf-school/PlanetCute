using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace PlanetCute_ida
{
    class Sprite
    {
        Texture2D texture;
        Rectangle rectangle;
        
        public Sprite(Texture2D newTexture, Rectangle newRectangle)
        {
            this.texture = newTexture;
            this.rectangle = newRectangle;
        }

        public void Update()
        {
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
        }
    }
}
