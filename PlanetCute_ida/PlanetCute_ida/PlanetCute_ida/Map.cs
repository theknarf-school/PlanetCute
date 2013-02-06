using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PlanetCute_ida
{
    class Map
    {
        public struct Position { public int x; public int y; }
        
        private int        _width;
        private int        _height;
        private int[,]     _map;
        private Position[] _spawnpoints;

        public int width  { get { return this._width;  } }
        public int height { get { return this._height; } }
        public int numberOfSpawnpoints { get { return this._spawnpoints.Length; } }

        public int getTileID(int x, int y)
        {
            return this._map[x, y];
        }

        public Position getSpawnpoint(int p)
        {
            return this._spawnpoints[p];
        }

        public void loadMap(String filename)
        {
            if (File.Exists(filename))
            {
                using (TextReader reader = File.OpenText(filename))
                {
                    // Get map size
                    string mapSize = reader.ReadLine();
                    string[] bits = mapSize.Split(' ');

                    this._width  = int.Parse(bits[0]);
                    this._height = int.Parse(bits[1]);

                    this._map = new int[this._width, this._height];

                    // Get tiles
                    for (int x = 0; x < this._width; x++)
                    {
                        string tilesInX = reader.ReadLine();
                        string[] bits2 = tilesInX.Split(' ');

                        for (int y = 0; y < this._height; y++)
                        {
                            this._map[x, y] = int.Parse(bits2[y]);
                        }
                    }

                    // Get number of spawnpoints
                    int nSpawnPoints = int.Parse(reader.ReadLine());

                    this._spawnpoints = new Position[nSpawnPoints];

                    // Load in spawnpoints
                    for (int i = 0; i < nSpawnPoints; i++)
                    {
                        string[] xy = reader.ReadLine().Split(' ');

                        Position tmp = new Position();
                        tmp.x = int.Parse(xy[0]);
                        tmp.y = int.Parse(xy[1]);

                        this._spawnpoints[i] = tmp;   
                    }
                }
            }
        }
    }
}
