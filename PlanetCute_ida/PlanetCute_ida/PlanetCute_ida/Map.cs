using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace PlanetCute_ida
{
    class Map
    {
        private int _width;
        private int _height;
        private int[,] _map;

        public int width  { get { return this._width;  } }
        public int height { get { return this._height; } }

        public Map(int width, int height)
        {
            this._width = width;
            this._height = height;
            this._map = new int[width, height];
        }

        public int getTileID(int x, int y)
        {
            return this._map[x, y];
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
                }
            }
        }

        public void setUpStandardMap()
        {
            // Setting up the map
            this._map[0, 0] = 0;
            this._map[0, 1] = 3;
            this._map[0, 2] = 6;
            this._map[0, 3] = 10;
            this._map[0, 4] = 12;

            for (int i = 1; i < 5; i++)
            {
                this._map[i, 0] = 1;
                this._map[i, 1] = 4;
                this._map[i, 2] = 7;
                this._map[i, 3] = 10;
                this._map[i, 4] = 12;
            }

            this._map[5, 0] = 1;
            this._map[5, 1] = 13;
            this._map[5, 2] = 8;
            this._map[5, 3] = 11;
            this._map[5, 4] = 12;

            this._map[6, 0] = 2;
            this._map[6, 1] = 5;
            this._map[6, 2] = 9;
            this._map[6, 3] = 10;
            this._map[6, 4] = 12;
        }
    }
}
