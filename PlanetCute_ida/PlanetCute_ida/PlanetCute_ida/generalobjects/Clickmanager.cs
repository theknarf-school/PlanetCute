using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;

namespace PlanetCute_ida
{
    /// <summary>
    /// A wrapper around a List of Clickable's. When you call the click method it sends the call to all the Clickables in the List
    /// </summary>
    class Clickmanager : Clickable
    {
        private List<Clickable> clickables = new List<Clickable>();

        public void Add(Clickable item)
        {
            clickables.Add(item);
        }

        public void Click(Rectangle mouse)
        {
            foreach (Clickable item in clickables)
                item.Click(mouse);
        }
    }
}
