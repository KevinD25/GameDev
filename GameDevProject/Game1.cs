﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

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
        Enemy enemy;
        Gui gui;
        Achtergrond achtergrond;
        SoundEffectInstance soundEffect;

        

        //variabele voor levels aan te maken
        AllLevels levels;
        Startscherm startscherm;
        Eindscherm eindscherm;

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

            // verander grootte van scherm
            graphics.PreferredBackBufferWidth = 400;
            graphics.PreferredBackBufferHeight = 300;
            //graphics.IsFullScreen = true;
            graphics.ApplyChanges();

            // geef hoogte en breedte van scherm aan variabele
            screenHeight = graphics.PreferredBackBufferHeight;
            screenWidth = graphics.PreferredBackBufferWidth;


           

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

            camera = new Camera2d();
            // alle levels initiëren
            levels = new AllLevels(Content);
            startscherm = new Startscherm(Content);
            eindscherm = new Eindscherm(Content);
            achtergrond = new Achtergrond(Content, camera);

            NextLevel();

            
        }

        private void NextLevel()
        {           
            if(levels.huidigLevel is Level)
            {
                
                hero = new Hero(Content, levels.huidigLevel);

                hero._bediening = new BedieningPijltjes();

                enemy = new Enemy(Content, levels.huidigLevel);
                enemy.createEnemies(Content);
                levels.huidigLevel.Hero = hero;
                levels.huidigLevel.Enemy = enemy;
                hero.levens = 3;
                gui = new Gui(Content);
            }
            if (levels.huidigLevel is Level1)
            {
                hero.collectedAcorns = 0;
            }

            
            soundEffect = levels.huidigLevel.song.CreateInstance();
            soundEffect.Volume = 0.1f;
            soundEffect.IsLooped = true;
            soundEffect.Play();
            
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
                enemy.Update(elapsedTime, gameTime);

                camera.Follow(hero);
                achtergrond.camera = camera;

                if (hero.collisionEndpoint)
                {
                    soundEffect.Stop();
                    levels.nextLevel();
                    NextLevel();
                }
                if(hero.levens == 0)
                {
                    soundEffect.Stop();
                    levels.restartGame();
                    NextLevel();
                }
            }
            else if(levels.huidigLevel is Startscherm)
            {
                if (levels.huidigLevel.CheckLevel())
                {
                    soundEffect.Stop();
                    levels.startGame();
                    NextLevel();
                }
            }
            else if(levels.huidigLevel is Eindscherm)
            {
                if (levels.huidigLevel.CheckLevel())
                {
                    soundEffect.Stop();
                    levels.restartGame();
                    NextLevel();           
                   
                }
                
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

                //achtergrond tekenen
                achtergrond.drawBackground(spriteBatch, GraphicsDevice);

                spriteBatch.Begin(transformMatrix: camera.Transform);    

                //level tekenen          
                levels.DrawWorld(spriteBatch);
                //hero tekenen
                hero.Draw(spriteBatch);

                //enemy tekenen
                enemy.Draw(spriteBatch);

                spriteBatch.End();


                gui.Draw(spriteBatch, hero);
            }
            else if (levels.huidigLevel is Startscherm)
            {
                startscherm.drawScreen(spriteBatch, GraphicsDevice);
            }
            else
            {
                eindscherm.drawScreen(spriteBatch, GraphicsDevice);
            }


            base.Draw(gameTime);
        }
    }
}
