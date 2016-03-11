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
    // Version: 2.0

    public class ShapeZ: Shape
    {
        IBoard board;

        // Constructor, requires IBoard object.
        public ShapeZ(IBoard board)
        {
            this.board = board;
            blocks = new Block[4];
            blocks[0] = new Block(Color.FromName("Cyan"), new Point(0, 4), board);
            blocks[1] = new Block(Color.FromName("Cyan"), new Point(0, 5), board);
            blocks[2] = new Block(Color.FromName("Cyan"), new Point(1, 5), board);
            blocks[3] = new Block(Color.FromName("Cyan"), new Point(1, 6), board);

            CreateRotationArray();
        }

        // Returns the length of the blocks array. Getter only.
        public override int Length
        {
            get { return blocks.Length; }
        }

        // Indexer. Getter only.
        public override Block this[int index]
        {
            get { return blocks[index]; }
        }

        // Fills the rotationOffset array with appropriate offsets.
        private void CreateRotationArray()
        {
            rotationOffset = new Point[2, 4];
            // First rotation
            rotationOffset[1, 0] = new Point(-1,1);
            rotationOffset[1, 1] = new Point(0,0);
            rotationOffset[1, 2] = new Point(-1,-1);
            rotationOffset[1, 3] = new Point(0, -2);
            // Second rotation, back to original position
            rotationOffset[0, 0] = new Point(1,-1);
            rotationOffset[0, 1] = new Point(0, 0);
            rotationOffset[0, 2] = new Point(1, 1);
            rotationOffset[0, 3] = new Point(0, 2);
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

        // Makes the shape move down as many times as possible.
        // Fires addtopile event.
        public override void Drop()
        {
            bool canDrop = true;

            while (canDrop)
            {
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
            }

            // Means reached the pile.
            OnJoinPile();
        }

        // Rotates the shape according to its offsets if possible.
        public override void Rotate()
        {
            bool canRotate = true;
            int newRotation = currentRotation + 1;

            if (newRotation == 2)
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

        // Returns the shape to its starting position and rotation
        public override void Reset()
        {
            blocks[0].Position = new Point(0, 4);
            blocks[1].Position = new Point(0, 5);
            blocks[2].Position = new Point(1, 5);
            blocks[3].Position = new Point(1, 6);
        }
    }
}
