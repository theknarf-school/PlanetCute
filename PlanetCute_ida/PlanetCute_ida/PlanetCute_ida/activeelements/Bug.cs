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
    /// The bug class used by BugManager to spawn bugs and they later change into a gem when life goes to 0
    /// </summary>
    class Bug : ActiveElements
    {
        // The time the bug was spawned
        public int spawnTime;

        // How long the bug should live, 0 = unlimited
        public int lifeTime;

        /// <summary>
        /// Creates a new bug, all bugs are as standard half the size of the grapich file
        /// </summary>
        /// <param name="type"></param>
        public Bug(Tile type) : base(type) {
            size = 0.5f; // Sets another standard size for it
        }

        /// <summary>
        /// If you click it it looses life
        /// </summary>
        public override void Click(Rectangle mouse)
        {
            if (mouse.Intersects(GetCollitionBox()))
                looseLife();
        }
    }
}
