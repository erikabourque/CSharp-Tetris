using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris
{
    // Author: Georgi Veselinov Kichev
    // Date: 10/03/2016
    // Version: 2.0
    public class ShapeI : Shape
    {
        int length = 4;
        IBoard board;

        // Constructor, requires IBoard object.
        public ShapeI(IBoard board)
        {
            blocks = new Block[4];
            rotationOffset = new Point[2, 4];
            currentRotation = 0;
            CreateRotationArray();
            this.board = board;
            blocks[0] = new Block(Color.FromName("Yellow"), new Point(0, 3), board);
            blocks[1] = new Block(Color.FromName("Yellow"), new Point(0, 4), board);
            blocks[2] = new Block(Color.FromName("Yellow"), new Point(0, 5), board);
            blocks[3] = new Block(Color.FromName("Yellow"), new Point(0, 6), board);
        }

        // Returns the length of the blocks array. Getter only.
        public override int Length
        {
            get { return length; }
        }

        // Indexer. Getter only.
        public override Block this[int index]
        {
            get { return blocks[index]; }
        }

        // Fills the rotationOffset array with appropriate offsets.
        private void CreateRotationArray()
        {
            //first rotation
            rotationOffset[0, 0] = new Point(2,2);
            rotationOffset[0, 1] = new Point(1,1);
            rotationOffset[0, 2] = new Point(0,0);
            rotationOffset[0, 3] = new Point(-1,-1);
            //second rotation
            rotationOffset[1, 0] = new Point(-2,-2);
            rotationOffset[1, 1] = new Point(-1,-1);
            rotationOffset[1, 2] = new Point(0,0);
            rotationOffset[1, 3] = new Point(1,1);
        }

        // Moves the shape to the left if possible.
        public override void MoveLeft()
        {
            if (currentRotation == 1)
            {
                if (blocks[0].TryMoveLeft() && blocks[1].TryMoveLeft())
                {
                    if (blocks[2].TryMoveLeft() && blocks[3].TryMoveLeft())
                    {
                        blocks[0].MoveLeft();
                        blocks[1].MoveLeft();
                        blocks[2].MoveLeft();
                        blocks[3].MoveLeft();
                    }
                }
            }
            else
            {
                if(blocks[0].TryMoveLeft())
                {
                    blocks[0].MoveLeft();
                    blocks[1].MoveLeft();
                    blocks[2].MoveLeft();
                    blocks[3].MoveLeft();
                }
            }
        }

        // Moves the shape to the right if possible.
        public override void MoveRight()
        {
            if (currentRotation == 1)
            {
                if (blocks[0].TryMoveRight() && blocks[1].TryMoveRight())
                {
                    if (blocks[2].TryMoveRight() && blocks[3].TryMoveRight())
                    {
                        blocks[0].MoveRight();
                        blocks[1].MoveRight();
                        blocks[2].MoveRight();
                        blocks[3].MoveRight();
                    }
                }
            }
            else
            {
                if(blocks[3].TryMoveRight())
                {
                    blocks[0].MoveRight();
                    blocks[1].MoveRight();
                    blocks[2].MoveRight();
                    blocks[3].MoveRight();
                }
            }
        }

        // Moves the shape down one row if possible.  Can fire the addtopile event.
        public override void MoveDown()
        {
            if (currentRotation == 1)
            {
                if (blocks[3].TryMoveDown())
                {
                    blocks[0].MoveDown();
                    blocks[1].MoveDown();
                    blocks[2].MoveDown();
                    blocks[3].MoveDown();
                }
                else
                {
                    // Means reached the pile
                    OnJoinPile();
                }
            }
            else
            {
                if (blocks[0].TryMoveDown() && blocks[1].TryMoveDown())
                {
                    if (blocks[2].TryMoveDown() && blocks[3].TryMoveDown())
                    {
                        blocks[0].MoveDown();
                        blocks[1].MoveDown();
                        blocks[2].MoveDown();
                        blocks[3].MoveDown();
                    }
                    else
                    {
                        // Means reached the pile
                        OnJoinPile();
                    }
                }
                else
                {
                    // Means reached the pile
                    OnJoinPile();
                }
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

        // Rotates the shape according to its offsets if possible.
        public override void Rotate()
        {
            if (currentRotation == 0)
            {
                currentRotation++;
                if (blocks[0].TryRotate(rotationOffset[0,0]) && blocks[1].TryRotate(rotationOffset[0, 1]) && blocks[3].TryRotate(rotationOffset[0, 3]))
                {
                    blocks[0].Rotate(rotationOffset[0, 0]);
                    blocks[1].Rotate(rotationOffset[0, 1]);
                    blocks[3].Rotate(rotationOffset[0, 3]);
                }
            }
            else
            {
                currentRotation = 0;
                if (blocks[0].TryRotate(rotationOffset[1, 0]) && blocks[1].TryRotate(rotationOffset[1, 1]) && blocks[3].TryRotate(rotationOffset[1, 3]))
                {
                    blocks[0].Rotate(rotationOffset[1, 0]);
                    blocks[1].Rotate(rotationOffset[1, 1]);
                    blocks[3].Rotate(rotationOffset[1, 3]);
                }
            }
        }

        // Returns the shape to its starting position and rotation.
        public override void Reset()
        {
            blocks[0].Position = new Point(0, 3);
            blocks[1].Position = new Point(0, 4);
            blocks[2].Position = new Point(0, 5);
            blocks[3].Position = new Point(0, 6);
        }
    }
}
