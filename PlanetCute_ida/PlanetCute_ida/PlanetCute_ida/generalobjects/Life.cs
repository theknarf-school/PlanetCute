using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PlanetCute_ida
{
    class Life : ActiveElements
    {
        Tile gameover;
        GraphicsDeviceManager gdm;
        
        public int numberOfLifes { 
                                   get { return life; } 
                                   set { if (value >= 0) life = value; }
                                 }

        public Life(Texture2D heart, Texture2D gameover, GraphicsDeviceManager gdm) : base(new Tile(heart, 0))
        {
            this.gameover = new Tile(gameover, 0);
            this.gdm = gdm;
            this.size = 0.5f;
            this.moveBasedOnSize = false;
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < numberOfLifes; i++)
            {
                this.x = type.getSprite().Width * i / 2;
                base.Draw(spriteBatch);
            }

            if (numberOfLifes == 0)
            {
                spriteBatch.Draw(gameover.getSprite(),
                                 new Vector2(
                                             (this.gdm.PreferredBackBufferWidth  - gameover.getSprite().Width) / 2,
                                             (this.gdm.PreferredBackBufferHeight - gameover.getSprite().Height) / 2),
                                 Color.White);
            }
        }

    }
}
