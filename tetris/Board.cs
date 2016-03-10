using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Tetris
{
    // Author: Erika Bourque
    // Date: 09/03/2016
    // Version: 7.0

    public class Board : IBoard
    {
        // Instance Variables
        private Color[,] board = new Color[20, 10];
        private IShape shape;
        private IShapeFactory shapeFactory;

        // Constructor
        public Board()
        {
            // Fill board with black - default no-shape color
            for (int i = 0; i < board.GetLength(0); i++)
            {
                for (int j = 0; j < board.GetLength(1); j++)
                {
                    board[i, j] = Color.Black;
                }
            }

            // Creating proxy
            shapeFactory = new ShapeProxy(this);
            shape = (IShape)shapeFactory;

            // Creating a new shape and adding Board to its event.
            shapeFactory.DeployNewShape();
            shape.JoinPile += addToPile;
        }

        // Properties
        public IShape Shape
        {
            get
            {
                return shape;
            }
        }

        // Indexer
        public Color this[int i, int j]
        {
            get
            {
                if ((i > -1) && (i < 20) && (j > -1) && (j < 10))
                {
                    return board[i, j];
                }
                else
                {
                    throw new ArgumentException("Board error. Invalid coordinates for indexer: " + i + ", " + j);
                }
            }
        }

        // Events
        public event LinesClearedHandler LinesCleared;
        public event GameOverHandler GameOver;

        // Event Firing Methods
        protected void OnLinesCleared(int lines)
        {
            if (LinesCleared != null)
            {
                LinesCleared(lines);
            }
        }

        protected void OnGameOver()
        {
            if (GameOver != null)
            {
                GameOver();
            }
        }

        // Event Handler
        private void addToPile(IShape shape)
        {
            bool gameOver;
            int rowsCleared;
            Point coords;

            for (int i = 0; i < shape.Length; i++)
            {
                coords = shape[i].Position;
                board[coords.Y, coords.X] = shape[i].Color;
            }

            // Check for rows cleared
            rowsCleared = checkRowsCleared();

            if (rowsCleared > 0)
            {
                OnLinesCleared(rowsCleared);
            }

            // Check for a game over
            gameOver = verifyGameOver();

            if (gameOver)
            {
                OnGameOver();
            }

            shapeFactory.DeployNewShape();
        }

        // Methods
        // Assuming rank == dimension, 0(rows) or 1(cols) dimension
        public int GetLength(int rank)
        {
            if ((rank != 0) && (rank != 1))
            {
                throw new ArgumentException("Board GetLength error.  Rank is invalid number: " + rank);
            }

            return board.GetLength(rank);
        }

        // Checks if any of the starting area blocks are filled.
        private bool verifyGameOver()
        {
            // Check first row, middle blocks
            if ((board[0, 4] != Color.Black)
                || (board[0, 5] != Color.Black)
                || (board[0, 6] != Color.Black))
            {
                return true;
            }

            // Check second row, middle blocks
            if ((board[1, 4] != Color.Black)
                || (board[1, 5] != Color.Black)
                || (board[1, 6] != Color.Black))
            {
                return true;
            }

            return false;
        }

        private int checkRowsCleared()
        {
            int checkClearedRow = 19;
            int numCleared = 0;
            bool rowAllBlack = false;
            bool rowFilled;

            // Start from bottom, work way up
            while ((!rowAllBlack) && (checkClearedRow != -1))
            {
                // Give test variables default value
                rowFilled = true;
                rowAllBlack = true;

                // If it finds a black block, row is not filled
                // If it finds a colored block, row is not all black.
                for (int i = 0; i < board.GetLength(1); i++)
                {
                    if (board[checkClearedRow, i] == Color.Black)
                    {
                        // Block is black
                        rowFilled = false;
                    }
                    else
                    {
                        // Block is not black
                        rowAllBlack = false;
                    }
                }

                // If a row is filled, remove and move all rows down 1.
                // Loop will repeat with same row in order to prevent skipping it
                if (rowFilled)
                {
                    // Increase cleared count
                    numCleared++;

                    // Move all rows down one
                    moveRowsDown(checkClearedRow);
                }
                else
                {
                    // Row was not filled, check row above now.
                    checkClearedRow--;
                }
            }

            return numCleared;
        }

        // Moves all the rows down 1, starting at the given row
        // Given row is therefore overwritten.
        private void moveRowsDown(int startingRow)
        {
            bool rowAllBlack = false;
            int rowAbove = startingRow - 1;

            // If the row being move down is all black, stop after moving it
            // Tetris does not allow a block to "float" without support
            while ((!rowAllBlack) && (startingRow != 0))
            {
                // Default value of true, until proven otherwise
                rowAllBlack = true;

                for (int i = 0; i < board.GetLength(1); i++)
                {
                    board[startingRow, i] = board[rowAbove, i];

                    if (board[startingRow, i] != Color.Black)
                    {
                        rowAllBlack = false;
                    }
                }

                startingRow--;
                rowAbove--;
            }
        }
    }
}