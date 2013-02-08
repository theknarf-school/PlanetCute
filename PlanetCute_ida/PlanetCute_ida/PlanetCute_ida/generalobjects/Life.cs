using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PlanetCute_ida
{
    class Life : ActiveElements
    {
        Tile gameover;
        GraphicsDeviceManager gdm;

        private bool gotHit = false;
        private double timeGotHit = 0;
        public int hitAnimationLength = 1000;
        public float tmpRotat = 0;
        
        public Life(Texture2D heart, Texture2D gameover, GraphicsDeviceManager gdm) : base(new Tile(heart, 0))
        {
            this.gameover = new Tile(gameover, 0);
            this.gdm = gdm;
            this.size = 0.5f;
            this.moveBasedOnSize = false;
            this.rotateVec = new Vector2(type.getSprite().Width / 2, type.getSprite().Height / 2);
        }

        public override void Update(GameTime gameTime)
        {
            if (this.gotHit)
            {
                double totalMilli = gameTime.TotalGameTime.TotalMilliseconds;

                if (this.timeGotHit == 0) this.timeGotHit = totalMilli;

                if (totalMilli - this.timeGotHit > this.hitAnimationLength)
                {
                    this.gotHit = false;
                    this.timeGotHit = 0;
                    this.rotate = 0;
                }
            }

            base.Update(gameTime);
        }

        public override void looseLife()
        {
            if (!this.gotHit)
            {
                this.gotHit = true;
                this.tmpRotat = 1;
            }
            base.looseLife();
        }

        public override void Draw(SpriteBatch spriteBatch, GameTime gameTime)
        {
            for (int i = 0; i < life; i++)
            {
                this.x = type.getSprite().Width * i / 2;

                if (this.gotHit)
                {
                    this.tmpRotat += (float)gameTime.ElapsedGameTime.Milliseconds / 300;
                    this.rotate = (float)Math.Sin(this.tmpRotat)/2;
                }

                base.Draw(spriteBatch, gameTime);
            }

            if (life == 0)
            {
                spriteBatch.Draw(gameover.getSprite(),
                                 new Vector2(
                                             (this.gdm.PreferredBackBufferWidth  - gameover.getSprite().Width) / 2,
                                             (this.gdm.PreferredBackBufferHeight - gameover.getSprite().Height) / 2),
                                 Color.White);
            }
        }

    }
}
