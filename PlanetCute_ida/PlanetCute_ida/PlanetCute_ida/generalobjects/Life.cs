using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PlanetCute_ida
{
    /// <summary>
    /// Keeps count of life
    /// </summary>
    class Life : ActiveElements
    {
        Tile gameover;

        private bool gotHit = false;
        private double timeGotHit = 0;
        public double hitAnimationLength = 2 * Math.PI * 100;
        public float tmpRotat = 0;
        private StatusScreen ss;

        public Life(Texture2D heart, Texture2D gameover, StatusScreen ss) : base(new Tile(heart, 0))
        {
            this.gameover = new Tile(gameover, 0);
            this.size = 0.5f;
            this.moveBasedOnSize = false;
            this.rotateVec = new Vector2(type.getSprite().Width / 2, type.getSprite().Height / 2);
            this.ss = ss;
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

            if (this.life <= 0) this.ss.GameOver = true;

            base.Update(gameTime);
        }

        public override void looseLife()
        {
            if (this.ss.Playing)
            {
                if (!this.gotHit)
                {
                    this.gotHit = true;
                    this.tmpRotat = 1;
                }

                base.looseLife();
            }
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
        }

    }
}
