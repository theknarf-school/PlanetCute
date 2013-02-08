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
using PlanetCute_ida;

namespace PlanetCute_ida
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        //Game data
        List<GameObject> gameobjects = new List<GameObject>();
        Clickmanager clickmanager = new Clickmanager();

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";

            graphics.PreferredBackBufferHeight = 600;
            graphics.PreferredBackBufferWidth = 101 * 7;
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            this.IsMouseVisible = true;
            this.Window.Title = "Planet Cute - Level 1";
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            Life life;
            Map map = new Map();
            CharacterManager c;
            Background background;
            Player player;
            BugManager b;

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            
            // Load map
            map.loadMap(@"maps/map1.txt");

            //Background
            background = new Background(Content, map);

            //Life
            life = new Life(Content.Load<Texture2D>(@"images/Heart"), 
                            Content.Load<Texture2D>(@"images/Game Over"),
                            graphics);
            life.numberOfLifes = 5;
            
            c = new CharacterManager(Content, map, life);
            b = new BugManager(Content, map);

            clickmanager.Add(c);
            player = new Player(clickmanager);

            gameobjects.Add(background);
            gameobjects.Add(c);
            gameobjects.Add(player);
            gameobjects.Add(b);
            gameobjects.Add(life);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// all content.
        /// </summary>
        protected override void UnloadContent()
        {
            // TODO: Unload any non ContentManager content here
        }

        /// <summary>
        /// Allows the game to run logic such as updating the world,
        /// checking for collisions, gathering input, and playing audio.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Update(GameTime gameTime)
        {
            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            foreach (GameObject go in gameobjects)
            {
                go.Update(gameTime);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.LightBlue);
            spriteBatch.Begin();

            foreach (GameObject go in gameobjects)
            {
                go.Draw(spriteBatch);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
