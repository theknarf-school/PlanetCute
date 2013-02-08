using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PlanetCute_ida
{
    class ActiveElements : Clickable
    {
        protected Tile type;
        public int x;
        public int y;
        public int life;

        public ActiveElements(Tile type) 
        {
            this.type = type;
        }

        public Rectangle GetCollitionBox()
        {
            return new Rectangle(x,
                                 y + type.getSprite().Height / 2,
                                 type.getSprite().Width,
                                 type.getSprite().Width);
        }

        public void looseLife()
        {
            this.life--;
        }


        public void Click(Rectangle mouse)
        {
            if (mouse.Intersects(GetCollitionBox()))
                looseLife();
        }
    }
}
