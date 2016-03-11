using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    // Author: Erika Bourque
    // Date: 29/02/2016
    // Version: 2.0

    public class Scoreboard
    {
        // Instance Variables
        private int linesCleared = 0;
        private int level = 1;
        private int score = 0;

        // Constructors
        // Private to force instantiation with IBoard object
        private Scoreboard(){ }

        // Adds itself to an IBoard's lines cleared event.
        public Scoreboard(IBoard board)
        {
            if (board == null)
            {
                throw new NullReferenceException("Scoreboard constructor error. Board is null.");
            }

            board.LinesCleared += incrementLinesCleared;
        }

        // Properties
        public int Level
        {
            get
            {
                return level;
            }
        }

        public int Lines
        {
            get
            {
                return linesCleared;
            }
        }

        public int Score
        {
            get
            {
                return score;
            }
        }

        // Event Handler
        private void incrementLinesCleared(int num)
        {
            // Validation
            if ((num < 1) || (num > 4))
            {
                throw new ArgumentException("Scoreboard error. Invalid number of lines cleared: " + num);
            }

            // Increasing lines
            linesCleared = linesCleared + num;

            // Recalculating score
            if (num == 4)
            {
                score = score + 800;
            }
            else
            {
                score = score + (num * 100);
            }

            // Recalculating level, always minimum of 1.
            level = Math.Min((linesCleared / 10) + 1, 10);
        }


    }
}
