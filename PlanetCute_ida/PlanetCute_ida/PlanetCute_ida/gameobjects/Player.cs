using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;

namespace PlanetCute_ida
{
    /// <summary>
    /// A player class currently only used to handle mouse clicks
    /// </summary>
    class Player : GameObject, Clickable
    {
        private MouseState prevMouseState;
        private Rectangle collisionMouse;
        private const int size = 10;
        private Clickmanager cm;
        private StatusScreen ss;

        public Player(Clickmanager cm, StatusScreen ss)
        {
            this.cm = cm;
            this.ss = ss;
        }

        public virtual void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();

            if (mouseState.X != prevMouseState.X ||
                mouseState.Y != prevMouseState.Y)
                collisionMouse = new Rectangle(mouseState.X, mouseState.Y, size, size);

            if (mouseState.LeftButton == ButtonState.Released && prevMouseState.LeftButton == ButtonState.Pressed)
                Click(collisionMouse);

            prevMouseState = mouseState;
        }

        public void Click(Rectangle mouse)
        {
            if(this.ss.Playing)
                cm.Click(mouse);
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
        }
    }
}
