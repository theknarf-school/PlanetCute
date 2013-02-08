using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PlanetCute_ida
{
    class Bug : GameObject
    {
        private Tile bug;
        public int x;
        public int y;
        public int spawnTime;
        public int lifeTime;
        public float size = 0.5f;

        public Bug(Tile bug) 
        {
            this.bug = bug;
        }

        public virtual void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bug.getSprite(),
                                new Vector2(
                                            x + ((1-size)*bug.getSprite().Width)/2,
                                            y + bug.offset + ((1 - size) * bug.getSprite().Height) / 2
                                            ),
                                null, Color.White, 0, Vector2.Zero, size, SpriteEffects.None, 0
                            );
        }
    }
}
