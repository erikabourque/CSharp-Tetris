using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris
{
    public class ShapeL: Shape
    {
        int length = 4;
        IBoard board;

        public ShapeL(IBoard board)
        {
            this.board = board;
            blocks[0] = new Block(Color.FromName("Red"), new Point(0, 4), board);
            blocks[1] = new Block(Color.FromName("Red"), new Point(0, 5), board);
            blocks[2] = new Block(Color.FromName("Red"), new Point(0, 6), board);
            blocks[3] = new Block(Color.FromName("Red"), new Point(1, 4), board);
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
            rotationOffset[0, 0] = new Point(1, 1);
            rotationOffset[0, 1] = new Point(0, 0);
            rotationOffset[0, 2] = new Point(-1, -1);
            rotationOffset[0, 3] = new Point(0, 2);
            //second rotation
            rotationOffset[1, 0] = new Point(-1, 1);
            rotationOffset[1, 1] = new Point(0, 0);
            rotationOffset[1, 2] = new Point(1, -1);
            rotationOffset[1, 3] = new Point(2, 0);
            //third rotation
            rotationOffset[2, 0] = new Point(1, 1);
            rotationOffset[2, 1] = new Point(0, 0);
            rotationOffset[2, 2] = new Point(1,1);
            rotationOffset[2, 3] = new Point(0, -2);
            //fourth rotation
            rotationOffset[3, 0] = new Point(1, -1);
            rotationOffset[3, 1] = new Point(0, 0);
            rotationOffset[3, 2] = new Point(-1, 1);
            rotationOffset[3, 3] = new Point(2, 0);
        }

        public override void MoveLeft()
        {
            if (currentRotation == 0)
            {
                if (blocks[0].TryMoveLeft() && blocks[3].TryMoveLeft())
                {
                    blocks[0].MoveLeft();
                    blocks[1].MoveLeft();
                    blocks[2].MoveLeft();
                    blocks[3].MoveLeft();
                }
            }
            else if(currentRotation == 1)
            {
                if (blocks[0].TryMoveLeft() && blocks[1].TryMoveLeft() && blocks[2].TryMoveLeft())
                {
                    blocks[0].MoveLeft();
                    blocks[1].MoveLeft();
                    blocks[2].MoveLeft();
                    blocks[3].MoveLeft();
                }
            }
            else if(currentRotation == 2)
            {
                if (blocks[2].TryMoveLeft() && blocks[3].TryMoveLeft())
                {
                    blocks[0].MoveLeft();
                    blocks[1].MoveLeft();
                    blocks[2].MoveLeft();
                    blocks[3].MoveLeft();
                }
            }
            else
            {
                if (blocks[0].TryMoveLeft() && blocks[1].TryMoveLeft() && blocks[3].TryMoveLeft())
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
            if (currentRotation == 0)
            {
                if (blocks[2].TryMoveRight() && blocks[3].TryMoveRight())
                {
                    blocks[0].MoveRight();
                    blocks[1].MoveRight();
                    blocks[2].MoveRight();
                    blocks[3].MoveRight();
                }
            }
            else if(currentRotation == 1)
            {
                if (blocks[1].TryMoveRight() && blocks[2].TryMoveRight() && blocks[3].TryMoveRight())
                {
                    blocks[0].MoveRight();
                    blocks[1].MoveRight();
                    blocks[2].MoveRight();
                    blocks[3].MoveRight();
                }
            }
            else if (currentRotation == 2)
            {
                if (blocks[0].TryMoveRight() && blocks[3].TryMoveRight())
                {
                    blocks[0].MoveRight();
                    blocks[1].MoveRight();
                    blocks[2].MoveRight();
                    blocks[3].MoveRight();
                }
            }
            else
            {
                if (blocks[0].TryMoveRight() && blocks[1].TryMoveRight() && blocks[2].TryMoveRight())
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
            if (currentRotation == 0)
            {
                if (blocks[1].TryMoveDown() && blocks[2].TryMoveDown() && blocks[3].TryMoveDown())
                {
                    blocks[0].MoveDown();
                    blocks[1].MoveDown();
                    blocks[2].MoveDown();
                    blocks[3].MoveDown();
                }
            }
            else if(currentRotation == 1)
            {
                if (blocks[0].TryMoveDown() && blocks[3].TryMoveDown())
                {
                    blocks[0].MoveDown();
                    blocks[1].MoveDown();
                    blocks[2].MoveDown();
                    blocks[3].MoveDown();
                }
            }
            else if (currentRotation == 2)
            {
                if (blocks[0].TryMoveDown() && blocks[1].TryMoveDown() && blocks[2].TryMoveDown())
                {
                    blocks[0].MoveDown();
                    blocks[1].MoveDown();
                    blocks[2].MoveDown();
                    blocks[3].MoveDown();
                }
            }
            else
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

        public override void Drop()
        {
            int position = 19;
            if (currentRotation == 0)
            {
                for (int i = blocks[3].Position.X; i < 20; i++)
                {
                    if (!(board[i - 1, blocks[1].Position.Y].Equals(Color.FromName("Black"))) || !(board[i - 1, blocks[2].Position.Y].Equals(Color.FromName("Black"))) && !(board[i, blocks[3].Position.Y].Equals(Color.FromName("Black"))))
                    {
                        position = i - 1;
                        break;
                    }
                }
                blocks[0].Position = new Point(position - 1, blocks[0].Position.Y);
                blocks[1].Position = new Point(position - 1, blocks[1].Position.Y);
                blocks[2].Position = new Point(position - 1, blocks[2].Position.Y);
                blocks[3].Position = new Point(position, blocks[3].Position.Y);
            }
            else if(currentRotation == 1)
            {
                for (int i = blocks[3].Position.X; i < 20; i++)
                {
                    if (!(board[i - 1, blocks[0].Position.Y].Equals(Color.FromName("Black"))) || !(board[i - 1, blocks[3].Position.Y].Equals(Color.FromName("Black"))))
                    {
                        position = i - 1;
                        break;
                    }
                }
                blocks[0].Position = new Point(position, blocks[0].Position.Y);
                blocks[1].Position = new Point(position - 1, blocks[1].Position.Y);
                blocks[2].Position = new Point(position - 2, blocks[2].Position.Y);
                blocks[3].Position = new Point(position, blocks[3].Position.Y);
            }
            else if(currentRotation == 2)
            {
                for (int i = blocks[0].Position.X; i < 20; i++)
                {
                    if (!(board[i, blocks[0].Position.Y].Equals(Color.FromName("Black"))) || !(board[i, blocks[1].Position.Y].Equals(Color.FromName("Black"))) && !(board[i, blocks[2].Position.Y].Equals(Color.FromName("Black"))))
                    {
                        position = i - 1;
                        break;
                    }
                }
                blocks[0].Position = new Point(position, blocks[0].Position.Y);
                blocks[1].Position = new Point(position, blocks[1].Position.Y);
                blocks[2].Position = new Point(position, blocks[2].Position.Y);
                blocks[3].Position = new Point(position - 1, blocks[3].Position.Y);
            }
            else
            {
                for (int i = blocks[2].Position.X; i < 20; i++)
                {
                    if (!(board[i, blocks[0].Position.Y].Equals(Color.FromName("Black"))) || !(board[i - 2, blocks[3].Position.Y].Equals(Color.FromName("Black"))))
                    {
                        position = i - 1;
                        break;
                    }
                }
                blocks[0].Position = new Point(position, blocks[0].Position.Y);
                blocks[1].Position = new Point(position - 1, blocks[1].Position.Y);
                blocks[2].Position = new Point(position - 2, blocks[2].Position.Y);
                blocks[3].Position = new Point(position - 2, blocks[3].Position.Y);
            }
        }

        public override void Rotate()
        {
            currentRotation++;
            if(currentRotation == 4)
            {
                currentRotation = 0;
            }

            if (blocks[0].TryRotate(rotationOffset[currentRotation, 0]) && blocks[2].TryRotate(rotationOffset[currentRotation, 2]) && blocks[3].TryRotate(rotationOffset[currentRotation, 3]))
            {
                blocks[0].Rotate(rotationOffset[currentRotation, 0]);
                blocks[2].Rotate(rotationOffset[currentRotation, 2]);
                blocks[3].Rotate(rotationOffset[currentRotation, 3]);
            }

        }

        public override void Reset()
        {
            blocks[0].Position = new Point(0, 4);
            blocks[1].Position = new Point(0, 5);
            blocks[2].Position = new Point(0, 6);
            blocks[3].Position = new Point(1, 4);
        }
    }
}
