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
using TiaraFramework.Component;

namespace WalkSheetEZTester
{
    public class Game1 : Microsoft.Xna.Framework.Game
    {
        GraphicsDeviceManager graphics;
        SpriteBatch spriteBatch;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content1";

            graphics.PreferredBackBufferWidth = 7 * 32;
            graphics.PreferredBackBufferHeight = 5 * 32;
            graphics.IsFullScreen = false;
            Window.AllowUserResizing = false;

            IsMouseVisible = true;
        }

        protected override void Initialize()
        {
            base.Initialize();
            Components.Add(new StageManager(this, StageIndex.WalkSheetEZTester));
            Tool.Game = this;
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
        }

        protected override void UnloadContent()
        {
        }

        protected override void Update(GameTime gameTime)
        {
            if (this.IsActive)
                base.Update(gameTime);
            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();
        }

        protected override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
        }
    }

}
