using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PlanetCute_ida
{
    class Life
    {
        Texture2D heart;
        
        private double _rotate;
        public double rotate { get { return _rotate; } set { _rotate = value % (2 * Math.PI); } } 

        public Life(Texture2D heart)
        {
            this.heart = heart;
        }

        public virtual void Update()
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch, int numberOfHearts)
        {
            for (int i = 0; i < numberOfHearts; i++)
            {
                spriteBatch.Draw(heart, 
                    new Vector2(
                        (heart.Width * i/2),
                        (0)), 
                        null, Color.White, (float)_rotate, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
            }
        }

    }
}
