using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace PlanetCute_ida
{
    class BugManager : GameObject, Clickable
    {
        Map map;
        Random r = new Random();
        Bug[] b = new Bug[5];
        Tile enemy;
        int spoint;
        int nextSpawn = 0;

        public BugManager(ContentManager Content, Map map)
        {
            enemy = new Tile(Content, @"images/Enemy Bug", 0);
            this.map = map;
        }


        public void spawn(int gameTimeMillisec)
        {
            spoint = r.Next(map.numberOfBugspawnpoints);

            if (b[spoint] == null)
            {
                b[spoint] = new Bug(enemy);
                b[spoint].lifeTime = 10000;
                b[spoint].spawnTime = gameTimeMillisec;
                b[spoint].life = 2;

                b[spoint].x = enemy.getSprite().Width * map.getBugSpawnpoint(spoint).x;

                if (spoint == 4)
                {
                    b[spoint].y = enemy.getSprite().Height / 2 * map.getBugSpawnpoint(spoint).y - 50;
                }
                else
                {
                    b[spoint].y = enemy.getSprite().Height / 2 * map.getBugSpawnpoint(spoint).y;
                }
            }
        }


        public void Update(GameTime gameTime)
        {
            nextSpawn += 1;
            if (nextSpawn == 300)
            {
                spawn((int)gameTime.TotalGameTime.TotalMilliseconds);
                nextSpawn = 0;
            }
            
            // if to much time has gone, delete them
            for(int i = 0; i < b.Length; i++)
            {
                if (b[i] != null)
                {
                    Bug bug = b[i];
                    if (gameTime.TotalGameTime.TotalMilliseconds - bug.spawnTime > bug.lifeTime)
                    {
                        b[i] = null;
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < b.Length; i++)
                if(b[i] != null)
                    b[i].Draw(spriteBatch);
        }

        private void remove(int i)
        {
            b[i] = null;
        }

        public void Click(Rectangle mouse)
        {
            for (int i = 0; i < b.Length; i++)
                if (b[i] != null)
                {
                    b[i].Click(mouse);
                    if (b[i].life <= 0)
                        remove(i);
                }
        }
    }
}
