using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PlanetCute_ida
{
    class Bug : ActiveElements, GameObject
    {
        public int spawnTime;
        public int lifeTime;
        public float size = 0.5f;

        public Bug(Tile type) : base(type) { }

        public virtual void Update(GameTime gameTime)
        {
            
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(type.getSprite(),
                                new Vector2(
                                            x + ((1-size)*type.getSprite().Width)/2,
                                            y + type.offset + ((1 - size) * type.getSprite().Height) / 2
                                            ),
                                null, Color.White, 0, Vector2.Zero, size, SpriteEffects.None, 0
                            );
        }
    }
}
