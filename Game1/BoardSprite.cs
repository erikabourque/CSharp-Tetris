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
    class BoardSprite: DrawableGameComponent
    {
        private IBoard board;
        private Game game;
        private SpriteBatch spriteBatch;

        // Instead of constantly recreating the vectors
        // Array of vectors to know where to place the grid of blocks
        private Vector2[,] vectors = new Vector2[20, 10];

        // to render
        private Texture2D emptyBlock;
        private Texture2D filledBlock;

        public BoardSprite(Game game, IBoard board): base(game)
        {
            this.game = game;
            this.board = board;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            emptyBlock = game.Content.Load<Texture2D>("EmptyBlock");
            filledBlock = game.Content.Load<Texture2D>("FilledBlock");

            int width = emptyBlock.Width;
            int height = emptyBlock.Height;
            // Buffer so that the grid isn't stuck on one side
            int xBuffer = 200;
            int yBuffer = 50;

            // Filling vector array for block image locations
            // i represents y on a grid and j represents x on a grid 
            for (int i = 0; i < vectors.GetLength(0); i++)
            {
                for (int j = 0; j < vectors.GetLength(1); j++)
                {
                    vectors[i, j] = new Vector2(xBuffer + (width * j), yBuffer + (height * i));
                }
            }

            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            Color blockColor;
            
            spriteBatch.Begin();

            for (int i = 0; i < vectors.GetLength(0); i++)
            {
                for (int j = 0; j < vectors.GetLength(1); j++)
                {
                    blockColor = new Color(board[i, j].R, board[i, j].G, board[i, j].B, board[i, j].A);

                    if (blockColor == Color.Black)
                    {
                        spriteBatch.Draw(emptyBlock, vectors[i, j], Color.White);
                    }
                    else
                    {
                        spriteBatch.Draw(filledBlock, vectors[i, j], blockColor);
                    }
                }
            }

            spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
