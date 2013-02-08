using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace PlanetCute_ida
{
    class CharacterManager : GameObject, Clickable
    {
        Tile[] charachterTiles = new Tile[5];
        int charachters = 0;
        int spawned = 0;
        Character[] c = new Character[10];
        Random r = new Random();
        Map map;
        Life life;

        public CharacterManager(ContentManager Content, Map map, Life life)
        {
            charachterTiles[0] = new Tile(Content, @"images/Character Boy", 0);
            charachterTiles[1] = new Tile(Content, @"images/Character Cat Girl", 0);
            charachterTiles[2] = new Tile(Content, @"images/Character Horn Girl", 0);
            charachterTiles[3] = new Tile(Content, @"images/Character Pink Girl", 0);
            charachterTiles[4] = new Tile(Content, @"images/Character Princess Girl", 0);

            this.map = map;
            this.life = life;

            charachters--;
            spawn();
        }

        public void spawn()
        {
            if (charachters < 9)
            {
                charachters++;
                spawned++;

                Random r = new Random();
                Tile type = charachterTiles[r.Next(charachterTiles.Length)];

                c[charachters] = new Character(type);
                c[charachters].speed = spawned / 5 + 1;

                int spoint = r.Next(map.numberOfSpawnpoints);

                c[charachters].x = charachterTiles[0].getSprite().Width * map.getSpawnpoint(spoint).x;
                c[charachters].y = charachterTiles[0].getSprite().Height / 2 * map.getSpawnpoint(spoint).y;
            }
        }
        
        public void Update(GameTime gameTime)
        {
            for (int i = 0; i <= charachters; i++)
            {
                if (c[i].x > 101 * 7)
                {
                    Delete(i);
                    i--;
                    life.numberOfLifes--;
                }
            }

            for (int i = 0; i <= charachters; i++)
                c[i].Update();

            if (r.NextDouble() * 100 < 1.2)
                spawn();
        }

        private void Delete(int obj)
        {
            c[obj] = c[charachters];
            charachters--;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for(int i = 0; i <= charachters; i++)
                c[i].Draw(spriteBatch);
        }

        public void Click(Rectangle mouse)
        {
            for (int i = charachters; i >= 0; i--)
            {
                c[i].Click(mouse);

                if (c[i].life <= 0)
                {
                    Delete(i);
                    return;
                }
            }
        }
    }
}
