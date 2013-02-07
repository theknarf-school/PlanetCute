using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace PlanetCute_ida 
{
    class BugManager : GameObject
    {
        Tile bugTiles;
        Bug[] bugs = new Bug[4];
        Random random = new Random();
        Map map;

        public BugManager(ContentManager Content, Map map)
        {
            bugTiles = new Tile(Content, @"images/Enemy Bug", 0);

            this.map = map;
        }

        public void spawn()
        {
            bugs[0] = new Bug(bugTiles);

            int spoint = random.Next(map.numberOfSpawnPointsBug);

            if (map.getSpawnPointBug(spoint).x == 5)
            {
                bugs[0].x = bugTiles.getSprite().Width * map.getSpawnPointBug(spoint).x + 30;
                bugs[0].y = bugTiles.getSprite().Height / 2 * map.getSpawnPointBug(spoint).y;
            }
            else
            {
                bugs[0].x = bugTiles.getSprite().Width * map.getSpawnPointBug(spoint).x + 30;
                bugs[0].y = bugTiles.getSprite().Height / 2 * map.getSpawnPointBug(spoint).y + 30;
            }
        }
        
        public void Update()
        {
            if (random.Next(60) == 0)
            {
                spawn();
            }

        }

        public void Draw(SpriteBatch spriteBatch)
        {
            for(int i = 0; i < bugs.Length; i++)
                if(bugs[i] != null)
                    bugs[i].Draw(spriteBatch);
        }
    }
}
