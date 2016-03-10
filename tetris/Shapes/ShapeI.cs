using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris
{
    public class ShapeI : Shape
    {
        int length = 4;
        IBoard board;

        public ShapeI(IBoard board )
        {
            blocks[0] = new Block(Color.FromName("Yellow"), new Point(0, 3), board);
            blocks[1] = new Block(Color.FromName("Yellow"), new Point(0, 4), board);
            blocks[2] = new Block(Color.FromName("Yellow"), new Point(0, 5), board);
            blocks[3] = new Block(Color.FromName("Yellow"), new Point(0, 6), board);
        }

        public override int Length
        {
            get { return length; }
        }

        public override Block this[int index]
        {
            get { return blocks[index]; }
        }

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
                }
            }
        }

        public override void Drop()
        {
            int position = 19;
            if (currentRotation == 1)
            {
                Point lastBlock = blocks[3].Position;
                for (int i = lastBlock.X; i < 20; i++)
                {
                    if (!(board[i, lastBlock.Y].Equals(Color.FromName("Black"))))
                    {
                        position = i - 1;
                        break;
                    }
                }
                blocks[0].Position = new Point(position - 3, blocks[0].Position.Y);
                blocks[1].Position = new Point(position - 2, blocks[1].Position.Y);
                blocks[2].Position = new Point(position - 1, blocks[2].Position.Y);
                blocks[3].Position = new Point(position, blocks[3].Position.Y);
            }
            else
            {
                for (int i = blocks[0].Position.X; i < 20; i++)
                {
                    if ((board[i, blocks[0].Position.Y].Equals(Color.FromName("Black"))) || !(board[i, blocks[1].Position.Y].Equals(Color.FromName("Black"))))
                    {
                        if (board[i, blocks[2].Position.Y].Equals(Color.FromName("Black")) && board[i, blocks[3].Position.Y].Equals(Color.FromName("Black")))
                        {
                            position = i - 1;
                            break;
                        }
                    }
                }
                blocks[0].Position = new Point(position, blocks[0].Position.Y);
                blocks[1].Position = new Point(position, blocks[1].Position.Y);
                blocks[2].Position = new Point(position, blocks[2].Position.Y);
                blocks[3].Position = new Point(position, blocks[3].Position.Y);
            }
        }

        public override void Rotate()
        {
            if (currentRotation == 0)
            {
                currentRotation++;
                if (blocks[0].TryRotate(rotationOffset[1,0]) && blocks[2].TryRotate(rotationOffset[1, 2]) && blocks[3].TryRotate(rotationOffset[1, 3]))
                {
                    blocks[0].Rotate(rotationOffset[1, 0]);
                    blocks[2].Rotate(rotationOffset[2, 0]);
                    blocks[3].Rotate(rotationOffset[3, 0]);
                }
            }
            else
            {
                currentRotation = 0;
                if (blocks[0].TryRotate(rotationOffset[0, 0]) && blocks[2].TryRotate(rotationOffset[0, 2]) && blocks[3].TryRotate(rotationOffset[0, 3]))
                {
                    blocks[0].Rotate(rotationOffset[0, 0]);
                    blocks[2].Rotate(rotationOffset[0, 2]);
                    blocks[3].Rotate(rotationOffset[0, 3]);
                }
            }
        }

        public override void Reset()
        {
            blocks[0].Position = new Point(0, 3);
            blocks[1].Position = new Point(0, 4);
            blocks[2].Position = new Point(0, 5);
            blocks[3].Position = new Point(0, 6);
        }
    }
}
