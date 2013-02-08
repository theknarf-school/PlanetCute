using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PlanetCute_ida
{
    /// <summary>
    /// A character class used by charactermanager to manage characters
    /// </summary>
    class Character : ActiveElements
    {
        // The speed to move at
        public int speed {get; set;}

        /// <summary>
        /// Construct a new Character based on a Tile
        /// </summary>
        /// <param name="type">The Tile to use</param>
        public Character(Tile type) : base(type) { }

        /// <summary>
        /// Moves the character towards right based on this.speed (or left is speed is negative)
        /// </summary>
        public void Update()
        {
            this.x += speed;
        }

        /// <summary>
        /// Looses life when you click it
        /// </summary>
        public override void Click(Rectangle mouse)
        {
            if (mouse.Intersects(GetCollitionBox()))
                looseLife();
        }
    }
}
