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

        public virtual void Click(Rectangle mouse)
        {
            if (mouse.Intersects(GetCollitionBox()))
                looseLife();
        }
    }
}
