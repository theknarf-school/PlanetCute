using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace PlanetCute_ida
{
    class CharacterManager
    {
        Tile[] charachterTiles = new Tile[5];
        int charachters = 0;
        int spawned = 0;
        Character[] c = new Character[10];
        Random r = new Random();

        public CharacterManager(ContentManager Content)
        {
            charachterTiles[0] = new Tile(Content, @"images/Character Boy", 0);
            charachterTiles[1] = new Tile(Content, @"images/Character Cat Girl", 0);
            charachterTiles[2] = new Tile(Content, @"images/Character Horn Girl", 0);
            charachterTiles[3] = new Tile(Content, @"images/Character Pink Girl", 0);
            charachterTiles[4] = new Tile(Content, @"images/Character Princess Girl", 0);

            charachters--;
            newC();
        }

        public void newC()
        {
            if (charachters < 9)
            {
                charachters++;
                spawned++;
                c[charachters] = new Character(charachterTiles);
                c[charachters].y = charachterTiles[0].getSprite().Height * 2;
                c[charachters].speed = spawned/5+1;
            }
        }
        
        public void Update()
        {
            for (int i = 0; i <= charachters; i++)
            {
                if (c[i].x > 101 * 7)
                {
                    c[i] = c[charachters];
                    charachters--;
                    i--;
                }
            }

            for (int i = 0; i <= charachters; i++)
                c[i].Update();

            if (r.NextDouble() * 100 < 1.2)
                newC();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for(int i = 0; i <= charachters; i++)
                c[i].Draw(spriteBatch);
        }
    }
}
