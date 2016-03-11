using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tetris
{
    // Author: Erika Bourque
    // Date: 10/03/2016
    // Version: 3.0

    public class ShapeT : Shape
    {
        IBoard board;

        // Constructor, requires IBoard object.
        public ShapeT(IBoard board)
        {
            if (board == null)
            {
                throw new NullReferenceException("ShapeT constructor error.  Board is null: " + board);
            }

            this.board = board;
            blocks = new Block[4];

            // Filling block array
            blocks[0] = new Block(Color.FromName("Purple"), new Point(0, 4), board);
            blocks[1] = new Block(Color.FromName("Purple"), new Point(0, 5), board);
            blocks[2] = new Block(Color.FromName("Purple"), new Point(0, 6), board);
            blocks[3] = new Block(Color.FromName("Purple"), new Point(1, 5), board);

            // Filling rotationOffset array
            CreateRotationArray();

            // Initializing current rotation
            currentRotation = 0;
        }

        // Fills the rotationOffset array with appropriate offsets.
        private void CreateRotationArray()
        {
            rotationOffset = new Point[4, 4];

            // blocks[1] is the block that never moves, rotation point

            // First Rotation
            rotationOffset[1, 0] = new Point(-1, 1);
            rotationOffset[1, 1] = new Point(0, 0);
            rotationOffset[1, 2] = new Point(1, -1);
            rotationOffset[1, 3] = new Point(-1, -1);

            // Second Rotation
            rotationOffset[2, 0] = new Point(1, 1);
            rotationOffset[2, 1] = new Point(0, 0);
            rotationOffset[2, 2] = new Point(-1, -1);
            rotationOffset[2, 3] = new Point(-1, 1);

            // Third Rotation
            rotationOffset[3, 0] = new Point(1, -1);
            rotationOffset[3, 1] = new Point(0, 0);
            rotationOffset[3, 2] = new Point(-1, 1);
            rotationOffset[3, 3] = new Point(1, 1);

            // Fourth Rotation, return to initial positions
            rotationOffset[0, 0] = new Point(-1, -1);
            rotationOffset[0, 1] = new Point(0, 0);
            rotationOffset[0, 2] = new Point(1, 1);
            rotationOffset[0, 3] = new Point(1, -1);
        }

        // Indexer. Getter only.
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

        // Returns the length of the blocks array. Getter only.
        public override int Length
        {
            get
            {
                return blocks.Length;
            }
        }

        // Makes the shape move down as many times as possible.
        // Fires addtopile event.
        public override void Drop()
        {
            bool canDrop = true;

            while (canDrop)
            {
                // Checking if its possible, returns if it can't
                for (int i = 0; i < blocks.Length; i++)
                {
                    if (!blocks[i].TryMoveDown())
                    {
                        canDrop = false;
                    }
                }

                if (canDrop)
                {
                    // Reaching here means all trys successful
                    for (int i = 0; i < blocks.Length; i++)
                    {
                        blocks[i].MoveDown();
                    }
                }
            }

            // Means reached the pile.
            OnJoinPile();
        }

        // Moves the shape down one row if possible.  Can fire the addtopile event.
        public override void MoveDown()
        {
            bool canDrop = true;
            // Checking if its possible, prevents if it can't
            for (int i = 0; i < blocks.Length; i++)
            {
                if (!blocks[i].TryMoveDown())
                {
                    canDrop = false;
                }
            }

            if (canDrop)
            {
                // Reaching here means all trys successful
                for (int i = 0; i < blocks.Length; i++)
                {
                    blocks[i].MoveDown();
                }
            }
            else
            {
                // Means reached the pile
                OnJoinPile();
            }
        }

        // Moves the shape to the left if possible.
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
            for (int i = 0; i < blocks.Length; i++)
            {
                blocks[i].MoveLeft();
            }
        }

        // Moves the shape to the right if possible.
        public override void MoveRight()
        {
            // Checking if its possible, returns if it can't
            for (int i = 0; i < blocks.Length; i++)
            {
                if (!blocks[i].TryMoveRight())
                {
                    return;
                }
            }

            // Reaching here means all trys successful
            for (int i = 0; i < blocks.Length; i++)
            {
                blocks[i].MoveRight();
            }
        }

        // Returns the shape to its starting position and rotation
        public override void Reset()
        {
            blocks[0].Position = new Point(0, 4);
            blocks[1].Position = new Point(0, 5);
            blocks[2].Position = new Point(0, 6);
            blocks[3].Position = new Point(1, 5);

            currentRotation = 0;
        }

        // Rotates the shape according to its offsets if possible.
        public override void Rotate()
        {
            bool canRotate = true;
            int newRotation = currentRotation + 1;

            if (newRotation == 4)
            {
                newRotation = 0;
            }

            // Check if all pieces can rotate
            for (int i = 0; i < blocks.Length; i++)
            {
                if (!blocks[i].TryRotate(rotationOffset[newRotation, i]))
                {
                    canRotate = false;
                }
            }

            if (canRotate)
            {
                // Rotate each piece
                for (int i = 0; i < blocks.Length; i++)
                {
                    blocks[i].Rotate(rotationOffset[newRotation, i]);
                }

                // Make new rotation the current rotation
                currentRotation = newRotation;
            }
        }
    }
}
