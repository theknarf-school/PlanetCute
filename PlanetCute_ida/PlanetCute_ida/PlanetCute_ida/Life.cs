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

        public Life(Texture2D heart)
        {
            this.heart = heart;
        }

        public virtual void Update()
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch, int hearth)
        {
            for (int i = 0; i < hearth; i++)
            {
                spriteBatch.Draw(heart, 
                    new Vector2(
                        (heart.Width * i/2),
                        (0)), 
                        null, Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
            }
        }

    }
}
