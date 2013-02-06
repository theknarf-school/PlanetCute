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
        Texture2D RoofNorthWest;
        Texture2D RoofNorth;
        Texture2D RoofNorthEast;
        Texture2D RoofWest;
        Texture2D BrownBlock;
        Texture2D RoofEast;
        Texture2D RoofSouthWest;
        Texture2D RoofSouth;
        Texture2D WindowTall;
        Texture2D RoofSouthEast;
        Texture2D WallBlockTall;
        Texture2D DoorTallClosed;
        Texture2D StoneBlock;

        Texture2D[] sprites = new Texture2D[13];

        const int mapWidth  = 7;
        const int mapHeight = 5;
        int[,] map = new int[mapWidth, mapHeight];

        public Background(Texture2D RoofNorthWest, Texture2D RoofNorth,
            Texture2D RoofNorthEast, Texture2D RoofWest, Texture2D BrownBlock,
            Texture2D RoofEast, Texture2D RoofSouthWest, Texture2D RoofSouth,
            Texture2D WindowTall, Texture2D RoofSouthEast, Texture2D WallBlockTall,
            Texture2D DoorTallClosed, Texture2D StoneBlock)
        {
            this.RoofNorthWest = RoofNorthWest;
            this.RoofNorth = RoofNorth;
            this.RoofNorthEast = RoofNorthEast;
            this.RoofWest = RoofWest;
            this.BrownBlock = BrownBlock;
            this.RoofEast = RoofEast;
            this.RoofSouthWest = RoofSouthWest;
            this.RoofSouth = RoofSouth;
            this.WindowTall = WindowTall;
            this.RoofSouthEast = RoofSouthEast;
            this.WallBlockTall = WallBlockTall;
            this.DoorTallClosed = DoorTallClosed;
            this.StoneBlock = StoneBlock;
        }

        public Background(ContentManager Content)
        {
            this.sprites[0] = Content.Load<Texture2D>(@"images/Roof North West");
            this.sprites[1] = Content.Load<Texture2D>(@"images/Roof North");
            this.sprites[2] = Content.Load<Texture2D>(@"images/Roof North East");
            this.sprites[3] = Content.Load<Texture2D>(@"images/Roof West");
            this.sprites[4] = Content.Load<Texture2D>(@"images/Brown Block");
            this.sprites[5] = Content.Load<Texture2D>(@"images/Roof East");
            this.sprites[6] = Content.Load<Texture2D>(@"images/Roof South West");
            this.sprites[7] = Content.Load<Texture2D>(@"images/Roof South");
            this.sprites[8] = Content.Load<Texture2D>(@"images/Window Tall");
            this.sprites[9] = Content.Load<Texture2D>(@"images/Roof South East");
            this.sprites[10] = Content.Load<Texture2D>(@"images/Wall Block Tall");
            this.sprites[11] = Content.Load<Texture2D>(@"images/Door Tall Closed");
            this.sprites[12] = Content.Load<Texture2D>(@"images/Stone Block");

            this.map[0, 0] = 0;
            this.map[0, 1] = 3;
            this.map[0, 2] = 6;
            this.map[0, 3] = 10;
            this.map[0, 4] = 12;

            for (int i = 1; i < 5; i++)
            {
                this.map[i, 0] = 1;
                this.map[i, 1] = 1;
                this.map[i, 2] = 7;
                this.map[i, 3] = 10;
                this.map[i, 4] = 12;
            }

            this.map[5, 0] = 1;
            this.map[5, 1] = 4;
            this.map[5, 2] = 8;
            this.map[5, 3] = 11;
            this.map[5, 4] = 12;
        }

        public void Update()
        {
        }

        public int getY(int y)
        {
            int[] arr = {4, 3, 0, 1, 2};
            return arr[y];
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int x = 0; x < mapWidth; x++)
            {
                for (int y = 0; y < mapHeight; y++)
                {
                    int tmpY = getY(y);
                    Texture2D sprite = this.sprites[map[x, tmpY]];

                    spriteBatch.Draw(
                                        sprite,
                                        new Vector2(
                                                    sprite.Width * x,
                                                    sprite.Height * tmpY / 2
                                                   ),
                                        Color.White);
                }
            }
            /*
            //Floor


            for (int i = 0; i < 7; i++)
            {
                spriteBatch.Draw(   StoneBlock,
                                    new Vector2(
                                        (StoneBlock.Width * i),
                                        (WallBlockTall.Height * 2) + (RoofNorth.Height / 6)),
                                   Color.White);
            }

            for (int i = 0; i < 5; i++)
            {
                spriteBatch.Draw(WallBlockTall,
                    new Vector2(
                        (WallBlockTall.Width * i),
                        (WallBlockTall.Height) + (RoofNorth.Height / 2)),
                        Color.White);
            }
            spriteBatch.Draw(DoorTallClosed,
                new Vector2(
                    (WallBlockTall.Width * 5),
                    (WindowTall.Height) + (RoofNorth.Height / 2) + 20),
                    Color.White);
            spriteBatch.Draw(WallBlockTall,
                new Vector2(
                    (WallBlockTall.Width * 6),
                    (WallBlockTall.Height) + (RoofNorth.Height / 2)),
                    Color.White);
            //Roof
            spriteBatch.Draw(RoofNorthWest, Vector2.Zero, Color.White);
            for (int i = 1; i < 6; i++)
            {
                spriteBatch.Draw(RoofNorth,
                    new Vector2(
                        (RoofNorth.Width * i),
                        (0)),
                        Color.White);
            }
            spriteBatch.Draw(RoofNorthEast,
                new Vector2(
                    (RoofNorthEast.Width * 6),
                    (0)),
                    Color.White);
            spriteBatch.Draw(RoofWest,
                new Vector2(
                    (0),
                    (RoofNorthWest.Height / 2)),
                    Color.White);
            for (int i = 1; i < 5; i++)
            {
                spriteBatch.Draw(BrownBlock,
                    new Vector2(
                        (BrownBlock.Width * i),
                        (RoofNorthWest.Height / 2)),
                        Color.White);
            }

            spriteBatch.Draw(RoofNorth,
                new Vector2(
                    (RoofNorth.Width * 5),
                    (RoofNorth.Height / 3) - 10),
                    Color.White);
            spriteBatch.Draw(RoofEast,
                new Vector2(
                    (RoofNorth.Width * 6),
                    (RoofNorth.Height / 2)),
                    Color.White);
            spriteBatch.Draw(RoofSouthWest,
                new Vector2(
                    (0),
                    (RoofNorth.Height)),
                    Color.White);
            for (int i = 1; i < 5; i++)
            {
                spriteBatch.Draw(RoofSouth,
                    new Vector2(
                        (RoofSouth.Width * i),
                        (RoofNorth.Height)),
                        Color.White);
            }
            spriteBatch.Draw(WindowTall,
                new Vector2(
                    (RoofSouth.Width * 5),
                    (RoofNorth.Height)),
                    Color.White);
            spriteBatch.Draw(RoofSouthEast,
                new Vector2(
                    (RoofSouth.Width * 6),
                    (RoofNorth.Height)),
                    Color.White);
             * */
        }
    }
}
