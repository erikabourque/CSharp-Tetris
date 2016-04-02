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
    public class ScoreSprite : DrawableGameComponent
    {
        private Scoreboard score;

        private Game game;
        private SpriteBatch spriteBatch;

        private SpriteFont font;

        public ScoreSprite(Game game, Scoreboard score) : base(game)
        {
            this.game = game;
            this.score = score;
        }

        public override void Initialize()
        {
            base.Initialize();
        }

        protected override void LoadContent()
        {
            spriteBatch = new SpriteBatch(GraphicsDevice);
            font = game.Content.Load<SpriteFont>("scoreFont");
            base.LoadContent();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
        }

        public override void Draw(GameTime gameTime)
        {
            spriteBatch.Begin();
            spriteBatch.DrawString(font, "Player Score: " + score.Score, new Vector2(0, 20), Color.White);
            spriteBatch.DrawString(font, "Current Level: " + score.Level, new Vector2(0, 30), Color.White);
            spriteBatch.DrawString(font, "Total Lines cleared: " + score.Lines, new Vector2(0, 40), Color.White);
            spriteBatch.DrawString(font, "Time: " + gameTime.TotalGameTime.Minutes
                + ":" + gameTime.TotalGameTime.Seconds
                + ":" + gameTime.TotalGameTime.Milliseconds,
                new Vector2(0, 50), Color.White);

            spriteBatch.End();
            base.Draw(gameTime);
        }
    }
}
