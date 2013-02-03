using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;


namespace PlanetCute_ida
{
    /// <summary>
    /// This is a game component that implements IUpdateable.
    /// </summary>
    public class BackgroundManager : Microsoft.Xna.Framework.DrawableGameComponent
    {

        SpriteBatch spriteBatch;
        Background background;

        public BackgroundManager(Game game)
            : base(game)
        {
            // TODO: Construct any child components here
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(Game.GraphicsDevice);
            background = new Background(
            Game.Content.Load<Texture2D>(@"images/Roof North West"),
            Game.Content.Load<Texture2D>(@"images/Roof North"),
            Game.Content.Load<Texture2D>(@"images/Roof North East"),
            Game.Content.Load<Texture2D>(@"images/Roof West"),
            Game.Content.Load<Texture2D>(@"images/Brown Block"), 
            Game.Content.Load<Texture2D>(@"images/Roof East"),
            Game.Content.Load<Texture2D>(@"images/Roof South West"),
            Game.Content.Load<Texture2D>(@"images/Roof South"),
            Game.Content.Load<Texture2D>(@"images/Window Tall"),
            Game.Content.Load<Texture2D>(@"images/Roof South East"),
            Game.Content.Load<Texture2D>(@"images/Wall Block Tall"),
            Game.Content.Load<Texture2D>(@"images/Door Tall Closed"),
            Game.Content.Load<Texture2D>(@"images/Stone Block"));
        }

        /// <summary>
        /// Allows the game component to perform any initialization it needs to before starting
        /// to run.  This is where it can query for any required services and load content.
        /// </summary>
        public override void Initialize()
        {
            // TODO: Add your initialization code here

            base.Initialize();
        }

        /// <summary>
        /// Allows the game component to update itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        public override void Update(GameTime gameTime)
        {
            // TODO: Add your update code here

            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            background.Draw(spriteBatch);
            spriteBatch.End();

        }
    }
}
