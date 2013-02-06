using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Input;


namespace PlanetCute_ida
{
    class Background
    {
        Tile[] tSprites = new Tile[14];
        
        const int mapWidth  = 7;
        const int mapHeight = 5;
        int[,] map = new int[mapWidth, mapHeight];

        public Background(ContentManager Content)
        {
            // Loading in sprites
            this.tSprites[0]  = new Tile(Content, @"images/Roof North West",    0);
            this.tSprites[1]  = new Tile(Content, @"images/Roof North",         0);
            this.tSprites[2]  = new Tile(Content, @"images/Roof North East",    0);
            this.tSprites[3]  = new Tile(Content, @"images/Roof West",          0);
            this.tSprites[4]  = new Tile(Content, @"images/Brown Block",        0);
            this.tSprites[5]  = new Tile(Content, @"images/Roof East",          0);
            this.tSprites[6]  = new Tile(Content, @"images/Roof South West",    0);
            this.tSprites[7]  = new Tile(Content, @"images/Roof South",         0);
            this.tSprites[8]  = new Tile(Content, @"images/Window Tall",        0);
            this.tSprites[9]  = new Tile(Content, @"images/Roof South East",    0);
            this.tSprites[10] = new Tile(Content, @"images/Wall Block Tall",    0);
            this.tSprites[11] = new Tile(Content, @"images/Door Tall Closed",   20);
            this.tSprites[12] = new Tile(Content, @"images/Stone Block",        20);
            this.tSprites[13] = new Tile(Content, @"images/Roof North",         -40);

            // Setting up the map
            this.map[0, 0] = 0;
            this.map[0, 1] = 3;
            this.map[0, 2] = 6;
            this.map[0, 3] = 10;
            this.map[0, 4] = 12;

            for (int i = 1; i < 5; i++)
            {
                this.map[i, 0] = 1;
                this.map[i, 1] = 4;
                this.map[i, 2] = 7;
                this.map[i, 3] = 10;
                this.map[i, 4] = 12;
            }

            this.map[5, 0] = 1;
            this.map[5, 1] = 13;
            this.map[5, 2] = 8;
            this.map[5, 3] = 11;
            this.map[5, 4] = 12;

            this.map[6, 0] = 2;
            this.map[6, 1] = 5;
            this.map[6, 2] = 9;
            this.map[6, 3] = 10;
            this.map[6, 4] = 12;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            int[] arr = { 4, 3, 0, 1, 2 };
            
            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    int tmpY = arr[y];
                    Tile sprite = this.tSprites[map[x, tmpY]];

                    // Drawing each tile
                    sprite.Draw(spriteBatch, x, tmpY);
                }
            }
        }
    }
}
