using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris
{
    public class Block
    {
        private IBoard board;
        private Color colour;
        Point point;

        public Block()
        {
            colour = Color.FromName("Black");
            point.X = 0;
            point.Y = 0;
        }

        public Block(Color colour, Point point, IBoard board)
        {
            this.colour = colour;
            this.point = point;
            this.board = board;
        }

        public Color Color
        {
            get { return colour; }
        }

        public Point Position
        {
            get { return point; }
            set { point = value; }
        }

        public bool TryMoveLeft()
        {
            if (point.Y < 0)
                return false;
            if (board[point.X, point.Y - 1].Equals(Color.FromName("Black")))
                return true;

            return false;
        }
        public bool TryMoveRight()
        {
            if (point.Y > 10)
                return false;
            if (board[point.X, point.Y + 1].Equals(Color.FromName("Black")))
                return true;

            return false;
        }
        public bool TryMoveDown()
        {
            if(point.X > 20)
                return false;
            if (board[point.X + 1, point.Y].Equals(Color.FromName("Black")))
                return true;

            return false;
        }
        public bool TryRotate(Point offset)
        {
            if (point.X + offset.X < 20 && point.X + offset.X >= 0 && board[point.X + offset.X, point.Y].Equals(Color.FromName("Black")))
            {
                if (point.Y + offset.Y < 10 && point.Y + offset.Y >= 0 && board[point.X, point.Y + offset.Y].Equals(Color.FromName("Black")))
                    return true;
            }

            return false;
        }
        public void MoveLeft()
        {
            point.Y--;
        }
        public void MoveRight()
        {
            point.Y++;
        }
        public void MoveDown()
        {
            point.X++;
        }
        public void Rotate(Point offset)
        {
            point.X = point.X + offset.X;
            point.Y = point.Y + offset.Y;
        }
    }
}