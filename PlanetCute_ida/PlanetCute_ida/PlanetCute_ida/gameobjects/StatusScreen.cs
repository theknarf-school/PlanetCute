using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace PlanetCute_ida
{
    class StatusScreen : GameObject
    {
        private int Status = 0;
        private GraphicsDeviceManager gdm;

        private Tile tGameover;
        private Tile tGamewon;
        private Tile tEscape;
        private Tile tNext;

        public bool GameOver { get { return Status == -1; } set { if (Status == 0 && value == true) Status = -1; } }
        public bool GameWon  { get { return Status == 1; }  set { if (Status == 0 && value == true) Status = 1; } }
        public bool Playing { get { return Status == 0; } }

        public StatusScreen(ContentManager Content, GraphicsDeviceManager gdm)
        {
            tGameover = new Tile(Content, @"images/Game Over", 0);
            tGamewon  = new Tile(Content, @"images/Game Win", 0);
            tEscape   = new Tile(Content, @"images/Game Escape", 0);
            tNext     = new Tile(Content, @"images/press n for next level", 0); 
            this.gdm = gdm;
        }

        public void Update(GameTime gameTime)
        {

        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            if (GameOver)
            {
                spriteBatch.Draw(tGameover.getSprite(),
                                 new Vector2(
                                             (this.gdm.PreferredBackBufferWidth  - tGameover.getSprite().Width) / 2,
                                             (this.gdm.PreferredBackBufferHeight - tGameover.getSprite().Height) / 2),
                                 Color.White);
            }
            else if (GameWon)
            {
                spriteBatch.Draw(tGamewon.getSprite(),
                                 new Vector2(
                                             (this.gdm.PreferredBackBufferWidth - tGamewon.getSprite().Width) / 2,
                                             (this.gdm.PreferredBackBufferHeight - tGamewon.getSprite().Height) / 2),
                                 Color.White);

                spriteBatch.Draw(tNext.getSprite(),
                                 new Vector2(
                                             (this.gdm.PreferredBackBufferWidth  - tNext.getSprite().Width) / 2,
                                             this.gdm.PreferredBackBufferHeight /2 + tNext.getSprite().Height * 2),
                                 Color.White);
            }

            if (!Playing)
            {
                spriteBatch.Draw(tEscape.getSprite(),
                                  new Vector2(
                                                 (this.gdm.PreferredBackBufferWidth - tEscape.getSprite().Width) / 2,
                                                 this.gdm.PreferredBackBufferHeight / 2 + tEscape.getSprite().Height),
                                     Color.White);
            }
        }
    }
}
