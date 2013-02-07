using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace PlanetCute_ida
{
    class BugManager : GameObject
    {
        Map map;
        Random r = new Random();
        Bug[] b = new Bug[4];
        int bugs = 0;
        Tile enemy;
        int spoint;
        int nextSpawn = 0;

        public BugManager(ContentManager Content, Map map)
        {
            enemy = new Tile(Content, @"images/Enemy Bug", -20);
            this.map = map;
            bugs--;
            spawn();
        }


        public void spawn()
        {
            if (bugs < 4)
            {
                bugs++;

                b[bugs] = new Bug(enemy);
                spoint = r.Next(map.numberOfBugspawnpoints);


                if (spoint == 4)
                {
                    b[bugs].x = enemy.getSprite().Width * map.getBugSpawnpoint(spoint).x;
                    b[bugs].y = enemy.getSprite().Height / 2 * map.getBugSpawnpoint(spoint).y - 50;
                }
                else
                {
                    b[bugs].x = enemy.getSprite().Width * map.getBugSpawnpoint(spoint).x;
                    b[bugs].y = enemy.getSprite().Height / 2 * map.getBugSpawnpoint(spoint).y;
                }
                if (bugs == 2)
                    bugs-=2;
            }
        }


        public void Update()
        {
            nextSpawn += 1;
            if (nextSpawn == 150)
            {
                bugs--;
                spawn();

                nextSpawn = 0;
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i <= bugs; i++)
                b[i].Draw(spriteBatch);
        }

    }
}
