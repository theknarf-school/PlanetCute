using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PlanetCute_ida
{
    class LooseLife
    {
        Texture2D heart;
        Vector2 position;

        public LooseLife(Texture2D heart, Vector2 position)
        {
            this.heart = heart;
            this.position = position;
        }

        public virtual void Update()
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 1; i < 5; i++)
            {

            }
        }

    }
}
