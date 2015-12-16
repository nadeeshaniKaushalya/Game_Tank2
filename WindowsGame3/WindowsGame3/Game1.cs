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

namespace WindowsGame3
{
    /// <summary>
    /// This is the main type for your game
    /// </summary>
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;
        Map map;
        Texture2D texture;
        //Rectangle rectangle;
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
            graphics.PreferredBackBufferWidth =820;
            graphics.PreferredBackBufferHeight = 620;
            map = new Map();
            base.Initialize();

            graphics.IsFullScreen = false;
            graphics.ApplyChanges();
            Window.Title = "Tank Game";
        }

        /// <summary>
        /// LoadContent will be called once per game and is the place to load
        /// all of your content.
        /// </summary>
        protected override void LoadContent()
        {
            // Create a new SpriteBatch, which can be used to draw textures.
            spriteBatch = new SpriteBatch(GraphicsDevice);
            Tile.Content = Content;
            //rectangle = new Rectangle( 1,1,texture.Width,texture.Height);
            map.Genarate(new int[,]{
                {4,4,4,2,4,2,4,3,4,1},
                {3,4,4,4,4,4,4,2,4,4},
                {4,3,4,4,4,2,4,4,4,2},
                {1,4,4,4,3,4,4,4,4,4},
                {4,4,4,2,4,1,4,4,4,4},
                {3,1,2,4,4,2,4,2,3,4},
                {4,4,3,2,1,4,4,1,4,4},
                {2,4,4,4,4,4,4,3,2,4},
                {4,3,4,4,4,2,4,4,4,2},
                {4,4,4,2,4,1,4,4,4,4},

            }, 50);

            texture = Content.Load<Texture2D>("TankRush");
            // TODO: use this.Content to load your game content here
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

            // TODO: Add your update logic here

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.SlateGray);

            // TODO: Add your drawing code here
            spriteBatch.Begin();
            map.Draw(spriteBatch);
            //spriteBatch.Draw(texture, rectangle, Color.White);
            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
