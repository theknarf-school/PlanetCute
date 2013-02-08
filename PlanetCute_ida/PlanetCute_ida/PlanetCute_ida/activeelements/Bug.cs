using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PlanetCute_ida
{
    /// <summary>
    /// 
    /// </summary>
    class Bug : ActiveElements
    {
        public int spawnTime;
        public int lifeTime;

        public Bug(Tile type) : base(type) {
            size = 0.5f; // Sets another standard size for it
        }

        public override void Click(Rectangle mouse)
        {
            if (mouse.Intersects(GetCollitionBox()))
                looseLife();
        }
    }
}
