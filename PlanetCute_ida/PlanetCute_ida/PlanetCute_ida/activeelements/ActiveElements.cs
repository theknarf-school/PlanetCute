using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PlanetCute_ida
{
    class ActiveElements : Clickable, GameObject
    {
        protected Tile type;
        public int x;
        public int y;
        public int life = 1;
        public float size = 1f;
        public float rotate = 0f;
        public bool moveBasedOnSize = true;
        public Vector2 rotateVec = Vector2.Zero;

        public ActiveElements(Tile type) 
        {
            this.type = type;
        }

        public virtual void Update(GameTime gameTime)
        {
        }

        public virtual void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            spriteBatch.Draw(   
                                type.getSprite(),
                                new Vector2(
                                            x + ((1 - size) * type.getSprite().Width) / 2 * (moveBasedOnSize?1:0) + rotateVec.X/2,
                                            y + type.offset + ((1 - size) * type.getSprite().Height) / 2 * (moveBasedOnSize?1:0) + rotateVec.Y/2
                                            ),
                                null, Color.White, rotate, rotateVec, size, SpriteEffects.None, 0
                            );
        }

        public Rectangle GetCollitionBox()
        {
            return new Rectangle(x,
                                 y + type.getSprite().Height / 2,
                                 type.getSprite().Width,
                                 type.getSprite().Width);
        }

        public virtual void looseLife()
        {
            this.life--;
        }
        
        public virtual void Click(Rectangle mouse)
        {
        }
    }
}
