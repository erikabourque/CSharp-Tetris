using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;
using Tetris;

namespace Game1
{
    /// <summary>
    /// This is the main type for your game.
    /// </summary>
    public class Game1 : Game
    {
        private GraphicsDeviceManager graphics;
        private SpriteBatch spriteBatch;
        private BoardSprite boardSprite;
        private ShapeSprite shapeSprite;
        private ScoreSprite scoreSprite;

        private Song backgroundMusic;

        public Game1()
        {
            graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            this.Window.Title = "Tetris";

            graphics.PreferredBackBufferWidth = 450;
            graphics.PreferredBackBufferHeight = 450;
            graphics.ApplyChanges();
        }

        /// <summary>
        /// Allows the game to perform any initialization it needs to before starting to run.
        /// This is where it can query for any required services and load any non-graphic
        /// related content.  Calling base.Initialize will enumerate through any components
        /// and initialize them as well.
        /// </summary>
        protected override void Initialize()
        {
            Board board = new Board();
            Scoreboard score = new Scoreboard(board);

            board.GameOver += gameOver;

            boardSprite = new BoardSprite(this, board);
            shapeSprite = new ShapeSprite(this, board.Shape, score);
            scoreSprite = new ScoreSprite(this, score);
                                   
            Components.Add(boardSprite);
            Components.Add(shapeSprite);
            Components.Add(scoreSprite);

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

            backgroundMusic = Content.Load<Song>("OriginalTetrisTheme");
            MediaPlayer.IsRepeating = true;
            MediaPlayer.Play(backgroundMusic);
        }

        /// <summary>
        /// UnloadContent will be called once per game and is the place to unload
        /// game-specific content.
        /// </summary>
        protected override void UnloadContent()
        {

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

            base.Update(gameTime);
        }

        /// <summary>
        /// This is called when the game should draw itself.
        /// </summary>
        /// <param name="gameTime">Provides a snapshot of timing values.</param>
        protected override void Draw(GameTime gameTime)
        {
            Texture2D borderPixel = new Texture2D(GraphicsDevice, 1, 1);
            borderPixel.SetData(new[] { Color.White } );
            GraphicsDevice.Clear(Color.CornflowerBlue);

            spriteBatch.Begin();
            spriteBatch.Draw(borderPixel, new Rectangle(198, 18, 204, 404), Color.LightGray);
            spriteBatch.End();

            base.Draw(gameTime);
        }

        private void gameOver()
        {
            Components.Remove(shapeSprite);

            scoreSprite.GameOver();
        }
    }
}
