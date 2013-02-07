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
        int spawned = 0;
        int bugs = 0;
        Tile enemy;

        public BugManager(ContentManager Content, Map map)
        {
            enemy = new Tile(Content, @"images/Enemy Bug", -20);
            this.map = map;       
            spawn();
        }


        public void spawn()
        {
            if (bugs < 4)
            {
                bugs++;


                int spoint = r.Next(map.numberOfBugspawnpoints);
                b[spoint] = new Bug(enemy);
                if (b[spoint] == null)
                {
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
                }
            }
        }

        public void Update()
        {
            if (r.NextDouble() * 100 < 1.2)
                spawn();
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i <= bugs; i++)
                b[i].Draw(spriteBatch);
        }

    }
}
