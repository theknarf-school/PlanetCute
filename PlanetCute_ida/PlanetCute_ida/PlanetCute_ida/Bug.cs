using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PlanetCute_ida
{
    class Bug : GameObject
    {
        private Tile bug;
        public int x { get; set; }
        public int y { get; set; }

        public Bug(Tile bug) 
        {
            this.bug = bug;
        }

        public virtual void Update() { }

        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(bug.getSprite(),
                                new Vector2(x, y + bug.offset),
                                Color.White
                            );
        }
    }
}
