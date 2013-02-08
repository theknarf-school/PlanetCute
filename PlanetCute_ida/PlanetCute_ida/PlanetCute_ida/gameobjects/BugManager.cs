using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Content;

namespace PlanetCute_ida
{
    /// <summary>
    /// The bug manager handles spawning and deleting bugs
    /// It also tells the Gems class when you succsessfully kills a bug and click the gem
    /// </summary>
    class BugManager : GameObject, Clickable
    {
        // The map to use, the spawnpoints are gotten from here
        Map map;

        // A random used to spawn
        Random r = new Random();

        // The bugs
        Bug[] b = new Bug[5];

        // The Tile of the bug
        Tile enemy;

        // Used for keeping track of waiting time until next spawn
        int nextSpawn = 0;

        // The Gems class, used to get gems graphics and alert it on bug kills
        Gems gems;

        /// <summary>
        /// Constructs a new Bug Manager
        /// </summary>
        /// <param name="Content">An attribute used to load graphics</param>
        /// <param name="map">The map used to find spawnpoints</param>
        /// <param name="gems">The Gems class used to get gems graphics and alert on bug kills</param>
        public BugManager(ContentManager Content, Map map, Gems gems)
        {
            enemy = new Tile(Content, @"images/Enemy Bug", 0);
            this.map = map;
            this.gems = gems;
            this.b = new Bug[map.numberOfBugspawnpoints];
        }

        /// <summary>
        /// Spawns a new bug
        /// </summary>
        public void spawn(int gameTimeMillisec)
        {
            int spoint = r.Next(map.numberOfBugspawnpoints);

            if (b[spoint] == null && this.gems.numberOfGems < 3)
            {
                b[spoint] = new Bug(enemy);
                b[spoint].lifeTime = 10000;
                b[spoint].spawnTime = gameTimeMillisec;
                b[spoint].life = 20;

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

        /// <summary>
        /// Calls spawn to spawn new bugs and kills old ones
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            // Spawns new bug
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

        /// <summary>
        /// Draws the bugs
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="gameTime"></param>
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            for (int i = 0; i < b.Length; i++)
                if(b[i] != null)
                    b[i].Draw(spriteBatch, gameTime);
        }

        /// <summary>
        /// Removes a bug
        /// </summary>
        /// <param name="i"></param>
        private void remove(int i)
        {
            // Delete the bug
            b[i] = null;
        }

        /// <summary>
        /// Deals damage on click, makes it into a gem on zero life and remove the gem on click
        /// </summary>
        /// <param name="mouse"></param>
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
