using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PlanetCute_ida
{
    class Life : GameObject
    {
        Texture2D heart;
        Texture2D gameover;
        GraphicsDeviceManager gdm;
        
        private double _rotate;
        public double rotate { get { return _rotate; } set { _rotate = value % (2 * Math.PI); } }

        private int _numberOfLifes;
        public int numberOfLifes { get { return _numberOfLifes; } 
                                set {
                                     if (value >= 0)
                                     {
                                        _numberOfLifes = value;
                                     }
                                 }
        }

        public Life(Texture2D heart, Texture2D gameover, GraphicsDeviceManager gdm)
        {
            this.heart = heart;
            this.gameover = gameover;
            this.gdm = gdm;
        }

        public virtual void Update(GameTime gameTime)
        { }

        public virtual void Draw(SpriteBatch spriteBatch)
        {
            for (int i = 0; i < numberOfLifes; i++)
            {
                spriteBatch.Draw(heart, 
                    new Vector2(
                        (heart.Width * i/2),
                        (0)), 
                        null, Color.White, (float)_rotate, Vector2.Zero, 0.5f, SpriteEffects.None, 0);
            }
            if (_numberOfLifes == 0)
            {
                spriteBatch.Draw(gameover, 
                                 new Vector2(
                                             (this.gdm.PreferredBackBufferWidth-gameover.Width)/2,
                                             (this.gdm.PreferredBackBufferHeight-gameover.Height)/2),
                                 Color.White);
            }
        }

    }
}
