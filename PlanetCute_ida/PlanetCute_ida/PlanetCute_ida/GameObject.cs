﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace PlanetCute_ida
{
    interface GameObject
    {
        void Update();
        void Draw(SpriteBatch spriteBatch);
    }
}
