﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GameDevProject
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Camera2d camera;
        Hero hero;

        //variabele voor levels aan te maken
        AllLevels levels;

        //variable om camera te kunnen krijgen
        public static int screenHeight;
        public static int screenWidth;

        float elapsedTime, timescale;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            timescale = 0.7f;
            base.Initialize();
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);

            // TODO: use this.Content to load your game content here

            // alle levels initiëren
            levels = new AllLevels(Content);

            NextLevel();

            
        }

        private void NextLevel()
        {
            if(levels.huidigLevel is Level)
            {
                // hero aanmaken
                hero = new Hero(Content, levels.huidigLevel);

                hero._bediening = new BedieningPijltjes();
            }

            levels.CreateWorld();
            
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
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
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            // TODO: Add your update logic here
            elapsedTime = gameTime.ElapsedGameTime.Milliseconds;
            elapsedTime *= timescale;
            if (levels.huidigLevel is Level)
            {
                hero.Update(elapsedTime, gameTime);
            }

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.White);

            // TODO: Add your drawing code here
            if (levels.huidigLevel is Level)
            {
                spriteBatch.Begin();
                //level tekenen          
                levels.DrawWorld(spriteBatch);
                //hero tekenen
                hero.Draw(spriteBatch);

                spriteBatch.End();
            }


            base.Draw(gameTime);
        }
    }
}