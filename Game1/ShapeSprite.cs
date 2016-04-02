using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tetris;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace Game1
{
    public class ShapeSprite : DrawableGameComponent
    {
        private IShape shape;
        private Scoreboard score;
        private int counterMoveDown = 0;
        private KeyboardState oldState;
        private int counterInput;
        private int threshold = 20;
        private Game game;
        private SpriteBatch spriteBatch;
        private Texture2D filledBlock;

        public ShapeSprite(Game1 game, IShape shape, Scoreboard score) : base(game)
        {
            this.game = game;
            this.score = score;
            this.shape = shape;
        }

        public override void Initialize()
        {
            oldState = Keyboard.GetState();
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            filledBlock = game.Content.Load<Texture2D>("FilledBlock");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            checkInput();
            counterMoveDown++;
            if (counterMoveDown > (11 - score.Level) * 3)
            {
                shape.MoveDown();
                counterMoveDown = 0;
            }
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            for (int i = 0; i < shape.Length; i++)
            {
                spriteBatch.Draw(filledBlock, new Vector2(200 + shape[i].Position.Y * 20, 20 + shape[i].Position.X * 20),
                    new Color(shape[i].Color.R, shape[i].Color.G, shape[i].Color.B, shape[i].Color.A));
            }
            spriteBatch.End();
            base.Draw(gameTime);
        }

        private void checkInput()
        {
            KeyboardState newState = Keyboard.GetState();

            if (newState.IsKeyDown(Keys.Left))
            {
                if (oldState.IsKeyDown(Keys.Left))
                {
                    counterInput++;
                    if (counterInput > threshold)
                    {
                        shape.MoveLeft();
                    }
                }
                else
                {
                    shape.MoveLeft();
                    //reset counter
                    counterInput = 0;
                }
            }


            if (newState.IsKeyDown(Keys.Right))
            {
                if (oldState.IsKeyDown(Keys.Right))
                {
                    counterInput++;
                    if (counterInput > threshold)
                    {
                        shape.MoveRight();
                    }
                }
                else
                {
                    shape.MoveRight();
                    //reset counter
                    counterInput = 0;
                }
            }

            if ((oldState.IsKeyUp(Keys.Down)) && (newState.IsKeyDown(Keys.Down)))
            {
                shape.Drop();
                counterInput = 0;
            }

            if ((oldState.IsKeyUp(Keys.Space)) && (newState.IsKeyDown(Keys.Space)))
            {
                shape.Rotate();
                counterInput = 0;
            }

            oldState = newState;
        }
    }
}
