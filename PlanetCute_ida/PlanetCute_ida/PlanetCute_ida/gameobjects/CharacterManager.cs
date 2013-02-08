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
    /// Handels spawning new Characters
    /// </summary>
    class CharacterManager : GameObject, Clickable
    {
        // The Tiles holding the diffrent character graphics
        Tile[] charachterTiles = new Tile[5];

        // Number of charachters in game
        int charachters = 0;

        // Number of total spawned characters
        int spawned = 0;

        // An array of Characters
        Character[] c = new Character[10];

        // A random used to spawn chracters
        Random r = new Random();

        // The map to get spawnpoints
        Map map;

        // A life class to deal damage to
        Life life;

        /// <summary>
        /// Constructs a new Chracter Manager
        /// </summary>
        /// <param name="Content">An attribute used to load graphics</param>
        /// <param name="map">A map to get spawnpoints</param>
        /// <param name="life">A variable to deal damage to</param>
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

        /// <summary>
        /// Spawn a new chracter
        /// </summary>
        public void spawn()
        {
            // Ensures that you can't spawn more than 10 carachters (0..9)
            if (charachters < 9)
            {
                charachters++;  // Increase character count
                spawned++;      // Increase total spawned character count
                
                // Get the graphics
                Tile type = charachterTiles[r.Next(charachterTiles.Length)];

                // Creates a new carachter
                c[charachters] = new Character(type);
                c[charachters].speed = spawned / 6 + 1;

                // Find spawnpoint
                int spoint = r.Next(map.numberOfSpawnpoints);

                c[charachters].x = charachterTiles[0].getSprite().Width * map.getSpawnpoint(spoint).x;
                c[charachters].y = charachterTiles[0].getSprite().Height / 2 * map.getSpawnpoint(spoint).y;
            }
        }
        
        /// <summary>
        /// Deletes the characters if they leave the screen on the right side and deals damage
        /// Updates the characters
        /// Spawns new charactes
        /// </summary>
        /// <param name="gameTime"></param>
        public void Update(GameTime gameTime)
        {
            // Deletes the characters if they leave the screen on the right side and deals damage
            for (int i = 0; i <= charachters; i++)
            {
                if (c[i].x > 101 * 7)
                {
                    Delete(i);
                    i--;
                    life.looseLife();
                }
            }

            // Updates the characters
            for (int i = 0; i <= charachters; i++)
                c[i].Update();

            // Spawns new charactes
            if (r.NextDouble() * 100 < 1.2)
                spawn();
        }

        /// <summary>
        /// Deletes a Character
        /// </summary>
        /// <param name="obj"></param>
        private void Delete(int obj)
        {
            c[obj] = c[charachters];
            charachters--;
        }

        /// <summary>
        /// Draws all the characters
        /// </summary>
        /// <param name="spriteBatch"></param>
        /// <param name="gameTime"></param>
        public void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            for(int i = 0; i <= charachters; i++)
                c[i].Draw(spriteBatch, gameTime);
        }

        /// <summary>
        /// Deletes a character when you click on it
        /// </summary>
        /// <param name="mouse"></param>
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
