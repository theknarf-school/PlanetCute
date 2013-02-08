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
        Gems gems;

        public BugManager(ContentManager Content, Map map, Gems gems)
        {
            enemy = new Tile(Content, @"images/Enemy Bug", 0);
            this.map = map;
            this.gems = gems;
        }

        public void spawn(int gameTimeMillisec)
        {
            spoint = r.Next(map.numberOfBugspawnpoints);

            if (b[spoint] == null && this.gems.numberOfGems < 3)
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
                        // If the lifetime is 0 that is the same as they live forever
                        if (b[i].lifeTime != 0)
                            remove(i);
                    }
                }
            }
        }

        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            for (int i = 0; i < b.Length; i++)
                if(b[i] != null)
                    b[i].Draw(spriteBatch, gameTime);
        }

        private void remove(int i)
        {
            // Delete the bug
            b[i] = null;
        }

        public void Click(Rectangle mouse)
        {
            for (int i = 0; i < b.Length; i++)
                if (b[i] != null)
                {
                    b[i].Click(mouse);

                    if (b[i].life == 0)
                    {
                        // Spawns a gem instead
                        b[i].type = gems.getNextGem();
                    }
                    else if( b[i].life < 0)
                    {
                        // Remove it
                        gems.findGem();
                        remove(i);
                    }
                }
        }
    }
}
