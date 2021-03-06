﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris
{
    // Author: Georgi Veselinov Kichev
    // Date: 10/03/2016
    // Version: 1.0
    public class ShapeO : Shape
    {
        int length = 4;
        IBoard board;

        // Constructor, requires IBoard object.
        public ShapeO(IBoard board)
        {
            blocks = new Block[4];
            this.board = board;
            blocks = new Block[4];
            blocks[0] = new Block(Color.FromName("Blue"), new Point(0, 4), board);
            blocks[1] = new Block(Color.FromName("Blue"), new Point(0, 5), board);
            blocks[2] = new Block(Color.FromName("Blue"), new Point(1, 4), board);
            blocks[3] = new Block(Color.FromName("Blue"), new Point(1, 5), board);
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

        // Returns the shape to its starting position and rotation.
        public override void Reset()
        {
            blocks[0].Position = new Point(0,4);
            blocks[1].Position = new Point(0,5);
            blocks[2].Position = new Point(1,4);
            blocks[3].Position = new Point(1,5);
        }

        // Rotating O results in same position, thus O does not rotate.
        public override void Rotate() { }
    }
}
