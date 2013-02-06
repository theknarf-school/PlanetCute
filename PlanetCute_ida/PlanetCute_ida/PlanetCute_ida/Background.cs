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
            this.RoofNorthWest = Content.Load<Texture2D>(@"images/Roof North West");
            this.RoofNorth = Content.Load<Texture2D>(@"images/Roof North");
            this.RoofNorthEast = Content.Load<Texture2D>(@"images/Roof North East");
            this.RoofWest = Content.Load<Texture2D>(@"images/Roof West");
            this.BrownBlock = Content.Load<Texture2D>(@"images/Brown Block");
            this.RoofEast = Content.Load<Texture2D>(@"images/Roof East");
            this.RoofSouthWest = Content.Load<Texture2D>(@"images/Roof South West");
            this.RoofSouth = Content.Load<Texture2D>(@"images/Roof South");
            this.WindowTall = Content.Load<Texture2D>(@"images/Window Tall");
            this.RoofSouthEast = Content.Load<Texture2D>(@"images/Roof South East");
            this.WallBlockTall = Content.Load<Texture2D>(@"images/Wall Block Tall");
            this.DoorTallClosed = Content.Load<Texture2D>(@"images/Door Tall Closed");
            this.StoneBlock = Content.Load<Texture2D>(@"images/Stone Block");
        }

        public void Update()
        {
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            //Floor


            for (int i = 0; i < 7; i++)
            {
                spriteBatch.Draw(StoneBlock,
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
        }
    }
}
