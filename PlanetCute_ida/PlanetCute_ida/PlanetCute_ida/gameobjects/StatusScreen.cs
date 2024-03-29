﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace PlanetCute_ida
{
    /// <summary>
    /// A class to print out 'game over' and 'game won' messages among other things
    /// </summary>
    class StatusScreen : GameObject
    {
        private int Status = 0;             // Is the game won or lost or playing?
        private GraphicsDeviceManager gdm;  // Used to get window width and height
        private bool last;                  // Is it the last level?

        // Graphics
        private Tile tGameover;
        private Tile tGamewon;
        private Tile tGamewonAll;
        private Tile tEscape;
        private Tile tNext;

        // Abstractions over the Status variable
        public bool GameOver { get { return Status == -1; } set { if (Status == 0 && value == true) Status = -1; } }
        public bool GameWon  { get { return Status == 1; }  set { if (Status == 0 && value == true) Status = 1; } }
        public bool Playing { get { return Status == 0; } }

        public StatusScreen(ContentManager Content, GraphicsDeviceManager gdm, bool last)
        {
            tGameover   = new Tile(Content, @"images/Game Over", 0);
            tGamewon    = new Tile(Content, @"images/Game Win", 0);
            tGamewonAll = new Tile(Content, @"images/Game won all", 0);
            tEscape     = new Tile(Content, @"images/Game Escape", 0);
            tNext       = new Tile(Content, @"images/press n for next level", 0); 
            this.gdm = gdm;
            this.last = last;
        }

        public void Update(GameTime gameTime) {}

        /// <summary>
        /// Draws the correct graphics
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="gameTime"></param>
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
            else if (GameWon && !last)
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
            else if (GameWon && last)
            {
                spriteBatch.Draw(tGamewonAll.getSprite(),
                                new Vector2(
                                            (this.gdm.PreferredBackBufferWidth - tGamewonAll.getSprite().Width) / 2,
                                            (this.gdm.PreferredBackBufferHeight - tGamewonAll.getSprite().Height) / 2),
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
