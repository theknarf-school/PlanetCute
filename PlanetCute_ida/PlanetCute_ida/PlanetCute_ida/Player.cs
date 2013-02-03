using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace PlanetCute_ida
{
    class Player
    {
        MouseState prevMouseState;
        Rectangle collisionMouse;

        public virtual void Update()
        {
            const int size = 10;

            MouseState mouseState = Mouse.GetState();
            if (mouseState.X != prevMouseState.X ||
                mouseState.Y != prevMouseState.Y)
                collisionMouse = new Rectangle(mouseState.X-size/2, mouseState.Y-size/2, size/2, size/2);
            prevMouseState = mouseState;

        }
    }
}
