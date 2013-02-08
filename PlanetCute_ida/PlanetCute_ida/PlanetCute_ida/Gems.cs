using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace PlanetCute_ida
{
    class Gems : ActiveElements
    {
        Tile[] tGems = new Tile[3];
        int gemsFound = 0;
        GraphicsDeviceManager gdm;

        public int numberOfGems { get { return gemsFound; } }

        public Gems(ContentManager Content, GraphicsDeviceManager gdm) : base(null)
        {
            tGems[0] = new Tile(Content, @"images/Gem Blue",   0);
            tGems[1] = new Tile(Content, @"images/Gem Green",  0);
            tGems[2] = new Tile(Content, @"images/Gem Orange", 0);
            this.y = -60;
            this.gdm = gdm;
            this.type = tGems[0];
            this.size = 0.5f;
        }

        public void findGem()
        {
            if(gemsFound<tGems.Length) gemsFound++;
        }

        public Tile getNextGem()
        {
            return tGems[gemsFound];
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            for (int i = 0; i < gemsFound; i++)
            {
                this.x = gdm.PreferredBackBufferWidth - tGems[i].getSprite().Width * (i+1);
                this.type = tGems[i];
                base.Draw(spriteBatch, gameTime);
            }
        }
    }
}
