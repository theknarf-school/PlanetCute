﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace PlanetCute_ida
{
    class Character
    {
        private Tile type;
        
        public int speed {get; set;}
        public int x { get; set; }
        public int y { get; set; }

        public Character(Tile[] sprites)
        {
            Random r = new Random();
            type = sprites[r.Next(sprites.Length)];
        }

        public void Update()
        {
            this.x += speed;
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            type.Draw(spriteBatch, this.x, this.y);
        }
    }
}
