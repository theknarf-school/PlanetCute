using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PlanetCute_ida
{
    class Bug
    {
        private Tile type;
        
        public int x { get; set; }
        public int y { get; set; }

        public Bug(Tile bug)
        {
            type = bug;
        }

        public void Update()
        { }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(   type.getSprite(),
                                new Vector2(x,y),
                                null, Color.White, 0, Vector2.Zero, 0.5f, SpriteEffects.None, 0
                            );
        }
    }
}
