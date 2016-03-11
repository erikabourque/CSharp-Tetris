using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris
{
    // Author: Georgi Veselinov Kichev, Erika Bourque
    // Date: 10/03/2016
    // Version: 3.0

    public class Block
    {
        private IBoard board;
        private Color colour;
        Point point;

        // Constructors
        // Default constructor.
        public Block()
        {
            colour = Color.FromName("Black");
            point.X = 0;
            point.Y = 0;
        }

        // 3 Param constructors, requires an IBoard object.
        public Block(Color colour, Point point, IBoard board)
        {
            this.colour = colour;
            this.point = point;
            this.board = board;
        }

        // Returns the color of the block. Getter only.
        public Color Color
        {
            get { return colour; }
        }

        // Provides a getter and setting for the position of the block.
        public Point Position
        {
            get { return point; }
            set { point = value; }
        }

        // Checks if the space to the left of the block on the board is empty.
        public bool TryMoveLeft()
        {
            if (point.Y <= 0)
                return false;
            if (board[point.X, point.Y - 1].Equals(Color.FromName("Black")))
                return true;

            return false;
        }

        // Checks if the space to the right of the block on the board is empty.
        public bool TryMoveRight()
        {
            if (point.Y >= (board.GetLength(1) - 1))
                return false;
            if (board[point.X, point.Y + 1].Equals(Color.FromName("Black")))
                return true;

            return false;
        }

        // Checks if the space below the block on the board is empty.
        public bool TryMoveDown()
        {
            if (point.X >= (board.GetLength(0) - 1))
                return false;
            if (board[point.X + 1, point.Y].Equals(Color.FromName("Black")))
                return true;

            return false;
        }

        // Checks if the end position of a given rotation is empty.
        public bool TryRotate(Point offset)
        {
            if (point.X + offset.X < board.GetLength(0)
                && point.X + offset.X >= 0
                && point.Y + offset.Y < board.GetLength(1)
                && point.Y + offset.Y >= 0
                && board[point.X + offset.X, point.Y + offset.Y].Equals(Color.FromName("Black")))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        // Moves the block to the left.
        public void MoveLeft()
        {
            point.Y--;
        }

        // Moves the block to the right.
        public void MoveRight()
        {
            point.Y++;
        }

        // Moves the block down.
        public void MoveDown()
        {
            point.X++;
        }

        // Moves the block using the given offset.
        public void Rotate(Point offset)
        {
            point.X = point.X + offset.X;
            point.Y = point.Y + offset.Y;
        }
    }
}