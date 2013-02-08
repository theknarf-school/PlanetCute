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

        Queue<String> allMaps = new Queue<String>();

        //Game data
        List<GameObject> gameobjects;
        Clickmanager clickmanager;

        StatusScreen ss;
        
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
            this.Window.Title = "Planet Cute - Hit 'n' for next lever if you win the current one";
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            allMaps.Enqueue("map1.txt");
            allMaps.Enqueue("map2.txt");
            newgame((string)allMaps.Dequeue());    
        }

        private void newgame(String mapPath)
        {
            Map map = new Map();
            CharacterManager cmanager;
            Background background;
            Player player;
            BugManager bmanger;
            Gems gems;
            Life life;

            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // Load map
            map.loadMap(@"maps/" + mapPath);

            ss = new StatusScreen(Content, graphics);

            //Background
            background = new Background(Content, map);

            //Life
            life = new Life(Content.Load<Texture2D>(@"images/Heart"),
                            Content.Load<Texture2D>(@"images/Game Over"),
                            ss);
            life.life = 5;

            //Gems
            gems = new Gems(Content, graphics, ss);

            cmanager = new CharacterManager(Content, map, life);
            bmanger = new BugManager(Content, map, gems);

            // Add stuff to the clickmanager and initialize player
            clickmanager = new Clickmanager();
            clickmanager.Add(cmanager);
            clickmanager.Add(bmanger);
            player = new Player(clickmanager, ss);

            // Add stuff to gameobjects
            gameobjects = new List<GameObject>();
            gameobjects.Add(background);
            gameobjects.Add(cmanager);
            gameobjects.Add(player);
            gameobjects.Add(bmanger);
            gameobjects.Add(life);
            gameobjects.Add(gems);
            gameobjects.Add(ss);
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

            if (Keyboard.GetState().IsKeyDown(Keys.N))
            {
                if(allMaps.Count>0&&this.ss.GameWon)
                    newgame((string)allMaps.Dequeue()); 
            }

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
                go.Draw(spriteBatch, gameTime);
            }

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
