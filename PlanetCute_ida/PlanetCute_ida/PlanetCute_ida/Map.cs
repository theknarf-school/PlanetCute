using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PlanetCute_ida
{
    class Map
    {
        public struct Position { public Position(int x, int y) { this.x = x; this.y = y; } public int x; public int y; }
        
        private int        _width;
        private int        _height;
        private int[,]     _map;
        private Position[] _spawnpoints;

        public int width  { get { return this._width;  } }
        public int height { get { return this._height; } }
        public int numberOfSpawnpoints { get { return this._spawnpoints.Length; } }

        //Bugs
        private Position[] _spawnPointsBug;
        public int numberOfSpawnPointsBug { get { return this._spawnPointsBug.Length; } }

        public Position getSpawnPointBug(int p)
        {
            return this._spawnPointsBug[p];
        }

        public int getTileID(int x, int y)
        {
            return this._map[x, y];
        }

        public Position getSpawnpoint(int p)
        {
            return this._spawnpoints[p];
        }

        private int[] readline(TextReader reader)
        {
            List<int> values = new List<int>();

            while (values.Count < 1)
            {
                string line = reader.ReadLine();
                string[] bits = line.Split(' ');

                int result;

                for (int i = 0; i < bits.Length; i++)
                {
                    if (int.TryParse(bits[i], out result))
                    {
                        values.Add(result);
                    }
                }
            }

            return values.ToArray();
        }

        public void loadMap(String filename)
        {
            if (File.Exists(filename))
            {
                using (TextReader reader = File.OpenText(filename))
                {
                    // Get map size
                    int[] mapSize = readline(reader);

                    this._width = mapSize[0];
                    this._height = mapSize[1];

                    this._map = new int[this._width, this._height];

                    // Get tiles
                    for (int x = 0; x < this._width; x++)
                    {
                        int[] tilesInX = readline(reader);

                        for (int y = 0; y < this._height; y++)
                        {
                            this._map[x, y] = tilesInX[y];
                        }
                    }

                    // Get number of spawnpoints
                    int nSpawnPoints = readline(reader)[0];
                    this._spawnpoints = new Position[nSpawnPoints];

                    // Load in spawnpoints
                    for (int i = 0; i < nSpawnPoints; i++)
                    {
                        int[] xy = readline(reader);
                        this._spawnpoints[i] = new Position(xy[0], xy[1]);
                    }

                    //Get number of spawnpoints for bug
                    int nSpawnPointsBug = readline(reader)[0];
                    this._spawnPointsBug = new Position[nSpawnPointsBug];

                    // Load in spawnpoints for bug
                    for (int i = 0; i < nSpawnPointsBug; i++)
                    {
                        int[] xy = readline(reader);
                        this._spawnPointsBug[i] = new Position(xy[0], xy[1]);
                    }
                }
            }
        }
    }
}
