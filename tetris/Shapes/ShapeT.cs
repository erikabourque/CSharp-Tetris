using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    class ShapeT : Shape
    {
        IBoard board;

        public ShapeT(IBoard board)
        {
            rotationOffset = new Point[2, 4];
            currentRotation = 0;
            CreateRotationArray();
            this.board = board;
            blocks[0] = blocks[0] = new Block(Color.FromName("Purple"), new Point(0, 3), board);
            blocks[0] = blocks[1] = new Block(Color.FromName("Purple"), new Point(0, 4), board);
            blocks[0] = blocks[2] = new Block(Color.FromName("Purple"), new Point(0, 5), board);
            blocks[0] = blocks[3] = new Block(Color.FromName("Purple"), new Point(1, 4), board);
        }

        private void CreateRotationArray()
        {
            rotationOffset = new Point[4, 4];

            // blocks[1] is the block that never moves, rotation point

            // First Rotation
            rotationOffset[0, 0] = new Point(1,-1);
            rotationOffset[0, 1] = new Point(0,0);
            rotationOffset[0, 2] = new Point(-1,1);
            rotationOffset[0, 3] = new Point(-1,-1);

            // Second Rotation
            rotationOffset[1, 0] = new Point(1,1);
            rotationOffset[1, 1] = new Point(0, 0);
            rotationOffset[1, 2] = new Point(-1,-1);
            rotationOffset[1, 3] = new Point(1,-1);

            // Third Rotation
            rotationOffset[2, 0] = new Point(-1,1);
            rotationOffset[2, 1] = new Point(0,0);
            rotationOffset[2, 2] = new Point(1,-1);
            rotationOffset[2, 3] = new Point(1,1);

            // Fourth Rotation
            rotationOffset[3, 0] = new Point(-1, -1);
            rotationOffset[3, 1] = new Point(0, 0);
            rotationOffset[3, 2] = new Point(1, 1);
            rotationOffset[3, 3] = new Point(-1, 1);
        }

        public override Block this[int index]
        {
            get
            {
                if ((index > -1) && (index < blocks.Length))
                {
                    return blocks[index];
                }
                else
                {
                    throw new ArgumentException("ShapeT error. Invalid coordinates for indexer: " + index);
                }
            }
        }

        public override int Length
        {
            get
            {
                return blocks.Length;
            }
        }

        public override void Drop()
        {
            throw new NotImplementedException();
        }

        public override void MoveDown()
        {
            throw new NotImplementedException();
        }

        public override void MoveLeft()
        {
            // Checking if its possible, returns if it can't
            for (int i = 0; i < blocks.Length; i++)
            {
                if (!blocks[i].TryMoveLeft())
                {
                    return;
                }
            }

            // Reaching here means all trys successful
        }

        public override void MoveRight()
        {
            throw new NotImplementedException();
        }

        public override void Reset()
        {
            throw new NotImplementedException();
        }

        public override void Rotate()
        {
            throw new NotImplementedException();
        }
    }
}
