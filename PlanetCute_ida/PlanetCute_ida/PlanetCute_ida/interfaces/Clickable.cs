using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PlanetCute_ida
{
    /// <summary>
    /// An interface to tell that the object can be clicked on
    /// </summary>
    interface Clickable
    {
        void Click(Rectangle mouse);
    }
}
